using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System.IO;

using KuroGUI.Handlers;

namespace KuroGUI
{
    public partial class MainGUI : MetroForm
    {
        public List<SocketTextChannel> SelectedChannels = new List<SocketTextChannel>();
        private int PresenceIndex = 0;
        public int? SelectedDMIndex { get; set; }
        private int? GreetingIndex { get; set; }
        private int? SFWFolderIndex { get; set; }
        private int? NSFWFolderIndex { get; set; }

        public MainGUI()
        {
            InitializeComponent();
        }

        private async void MainGUI_Load(object sender, EventArgs e)
        {
            await Global.Start();
            await ControlHandler.ShowSettingsValueAsync();
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                await Global.Kuro.ConnectAsync(TokenBox.Text.Trim());
                Global.Kuro.Client.Ready += async() =>
                {
                    await ControlHandler.AddTabsAsync();
                };
                Program.UserInterface.ConnectedMessageAddButton.Enabled = true;
                Program.UserInterface.FileSendButton.Enabled = true;
                Program.UserInterface.ConnectButton.Enabled = false;
                Program.UserInterface.DisconnectButton.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error happened while logging in!" + ex.Message);
            }
        }

        private async void DisconnectButton_Click(object sender, EventArgs e)
        {
            this.SelectedDMIndex = null;
            Global.Kuro.Disconnect();
            await ControlHandler.ResetTabsAsync();
            Program.UserInterface.Text = "KuroUI";
            Program.UserInterface.Refresh();
        }
        //Guild and GuildChannel Stuff
        public async void ChannelSelectionChanged(object s, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                Regex r = new Regex(@"\[(.*?)\]");
                SocketTextChannel SelectedChannel = Global.Kuro.Client.Guilds.Where(z => z.Name.Trim() == r.Match(e.Item.Text.Trim()).Groups[1].Value.Trim()).FirstOrDefault().Channels.Where(k => k.Name == e.Item.Text.Substring(e.Item.Text.LastIndexOf("#") + 1)).FirstOrDefault() as SocketTextChannel;
                if (SelectedChannels.Count != 0)
                {
                    int Findindex = SelectedChannels.FindIndex(k => k.Guild.Name == SelectedChannel.Guild.Name);
                    if (Findindex > -1)
                    {
                        SelectedChannels[Findindex] = SelectedChannel;
                    }
                    else
                    {
                        SelectedChannels.Add(SelectedChannel);
                    }
                }
                else
                {
                    SelectedChannels.Add(SelectedChannel);
                }
                Program.UserInterface.Text = "[" + SelectedChannel.Guild.Name + "] " + "#" + SelectedChannel.Name;
                Program.UserInterface.Refresh();
                IEnumerable<IMessage> messages = await (Global.Kuro.Client.GetChannel(SelectedChannel.Id) as SocketTextChannel).GetMessagesAsync(60).Flatten<IMessage>();
                await ControlHandler.ClearAsync(SelectedChannel.Guild.Name);
                for (int i = messages.Count() - 1; i >= 0; i--)
                {
                    IMessage message = messages.ElementAt(i);
                    string Guild = (message.Channel as SocketGuildChannel).Guild.Name;
                    await ControlHandler.LogCacheAsync("[" + message.Timestamp.LocalDateTime + "] " + "#" + message.Channel.Name + " | " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content), Guild);
                }
            }
        }

        public void ChatOutBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
        public async void ChatInBox_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
            SocketTextChannel ch = SelectedChannels.Find(o => o.Guild.Name == tabControl1.SelectedTab.Text);
            if (ch != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    await SendMessageAsync(((MetroTextBox)sender).Text.Trim(), ch.Id);
                    ((MetroTextBox)sender).Text = "";
                }
            }
        }
        private async Task SendMessageAsync(string message, ulong ChannelID)
        {
            await (Global.Kuro.Client.GetChannel(ChannelID) as SocketTextChannel).SendMessageAsync(message);
        }

        public void SendFileGuildChannel(object sender, EventArgs e)
        {
            if (SelectedChannels.Count > 0)
            {
                OpenFileDialog file = new OpenFileDialog()
                {
                    Multiselect = false
                };
                file.FileOk += async (o, ev) =>
                {
                    await (Global.Kuro.Client.GetChannel(SelectedChannels.Find(k => k.Guild.Name == tabControl1.SelectedTab.Text).Id) as SocketTextChannel).SendFileAsync(file.InitialDirectory + file.FileName, string.Empty);
                };
                file.ShowDialog();
            }
        }

        //General Stuff
        public void richTextBox_TextChanged(object sender, EventArgs e)
        {
            ((RichTextBox)sender).SelectionStart = ((RichTextBox)sender).Text.Length;
            ((RichTextBox)sender).ScrollToCaret();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name != "DMTabPage")
            {
                SocketTextChannel ch = SelectedChannels.Find(o => o.Guild.Name == tabControl1.SelectedTab.Text);
                if (ch != null)
                {
                    Program.UserInterface.Text = "[" + ch.Guild.Name + "] " + "#" + ch.Name;
                    Program.UserInterface.Refresh();
                }
            }
            else if (tabControl1.SelectedTab.Name == "DMTabPage")
            {
                if (SelectedDMIndex != null)
                {
                    SocketDMChannel ch = Global.Kuro.Client.DMChannels.Where(u => DMListView.Items[(int)SelectedDMIndex].Text == u.Recipient.Username).FirstOrDefault();
                    if (ch != null)
                    {
                        Program.UserInterface.Text = "[PRIVATE] " + "#" + ch.Recipient.Username;
                        Program.UserInterface.Refresh();
                    }
                }
            }
        }


        private void MainGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TokenSaveCheck.Checked) Global.SettingsHandler.Settings.SavedToken = TokenBox.Text.Trim();
            Global.SettingsHandler.SaveSettings();
        }


        //Settings Stuff
        private void PresenceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PresenceIndex = PresenceBox.SelectedIndex;
        }

        private async void SetGameButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SetGameTextBox.Text.Trim()))
            {
                UserStatus Status = (UserStatus)(Enum.GetValues(typeof(UserStatus)).GetValue(PresenceIndex));
                string Game = SetGameTextBox.Text.Trim();
                Global.SettingsHandler.Settings.Game = Game;
                Global.SettingsHandler.Settings.GameStatus = Status;
                await Global.Kuro.Client.SetStatusAsync(Status);
                await Global.Kuro.Client.SetGameAsync(Game);
                Global.SettingsHandler.SaveSettings();
            }
        }

        private async void ConnectedMessageAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserJoinMessageBox.Text) && !string.IsNullOrWhiteSpace(UserJoinChannelsComboBox.Text))
            {
                Regex getserver = new Regex(@"\[(.*?)\] #(\S*)");
                string GuildName = getserver.Match(UserJoinChannelsComboBox.Text).Groups[1].Value;
                string ChannelName = getserver.Match(UserJoinChannelsComboBox.Text).Groups[2].Value;

                if (Global.SettingsHandler.Settings.GreetMessages.FindIndex(u =>u.GuildName == GuildName && u.ChannelName == ChannelName) == -1)
                {
                    foreach (SocketGuild guild in Global.Kuro.Client.Guilds)
                    {
                        if (guild.Name == GuildName)
                        {
                            foreach (SocketTextChannel channel in guild.TextChannels)
                            {
                                if (channel.Name == ChannelName)
                                {
                                    Global.SettingsHandler.Settings.GreetMessages.Add(new GreetMessage(guild.Id, channel.Id, UserJoinMessageBox.Text.Trim(), guild.Name, channel.Name));
                                    Global.SettingsHandler.SaveSettings();
                                    await ControlHandler.ShowSettingsValueAsync();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("This Guild already has a Greeting message! Please remove that before procceeding.");
                }
            }
        }

        private void MessagesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GreetingIndex = MessagesListView.SelectedIndices.Cast<int>().FirstOrDefault();
        }

        private async void RemoveGreetMessageButton_Click(object sender, EventArgs e)
        {
            if (GreetingIndex != null)
            {
                Global.SettingsHandler.Settings.GreetMessages.RemoveAt((int)GreetingIndex);
                Global.SettingsHandler.SaveSettings();
                await ControlHandler.ShowSettingsValueAsync();
            }
        }

        private async void OwnerButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(OwnerIDBox.Text))
            {
                if (ulong.TryParse(OwnerIDBox.Text, out ulong r))
                {
                    Global.SettingsHandler.Settings.OwnerID = r;
                    Global.SettingsHandler.SaveSettings();
                    await ControlHandler.ShowSettingsValueAsync();
                }
            }
        }

        private async void SFWAddFolder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SFWPicsTextBox.Text))
            {
                if (Directory.Exists(SFWPicsTextBox.Text.Trim()))
                {
                    Global.SettingsHandler.Settings.SFWFolders.Add(SFWPicsTextBox.Text.Trim());
                    Global.SettingsHandler.SaveSettings();
                    await ControlHandler.ShowSettingsValueAsync();
                    Global.SettingsHandler.ReadPictures();
                    SFWPicsTextBox.Text = string.Empty;
                }
            }
        }

        private async void NSFWAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NSFWPicsTextBox.Text))
            {
                if (Directory.Exists(NSFWPicsTextBox.Text.Trim()))
                {
                    Global.SettingsHandler.Settings.NSFWFolders.Add(NSFWPicsTextBox.Text.Trim());
                    Global.SettingsHandler.SaveSettings();
                    await ControlHandler.ShowSettingsValueAsync();
                    Global.SettingsHandler.ReadPictures();
                    NSFWPicsTextBox.Text = string.Empty;
                }
            }
        }

        private async void RemoveSFWButton_Click(object sender, EventArgs e)
        {
            if (SFWFolderIndex != null)
            {
                Global.SettingsHandler.Settings.SFWFolders.RemoveAt((int)SFWFolderIndex);
                Global.SettingsHandler.SaveSettings();
                await ControlHandler.ShowSettingsValueAsync();
                Global.SettingsHandler.ReadPictures();
            }
        }

        private async void NSFWRemoveButton_Click(object sender, EventArgs e)
        {
            if (NSFWFolderIndex != null)
            {
                Global.SettingsHandler.Settings.NSFWFolders.RemoveAt((int)NSFWFolderIndex);
                Global.SettingsHandler.SaveSettings();
                await ControlHandler.ShowSettingsValueAsync();
                Global.SettingsHandler.ReadPictures();
            }
        }

        private void SFWPicsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SFWFolderIndex = SFWPicsListView.SelectedIndices.Cast<int>().FirstOrDefault();
        }

        private void NSFWPicsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            NSFWFolderIndex = NSFWPicsListView.SelectedIndices.Cast<int>().FirstOrDefault();
        }

        private async void SankakuLoginButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SankakuPasswordTextBox.Text) || !string.IsNullOrWhiteSpace(SankakuUserNameTextBox.Text))
            {
                Global.SankakuClient.Username = SankakuUserNameTextBox.Text.Trim();
                Global.SankakuClient.Password = SankakuPasswordTextBox.Text.Trim();
                Global.SettingsHandler.Settings.SankakuUserName = SankakuUserNameTextBox.Text.Trim();
                Global.SettingsHandler.Settings.SankakuPassword = SankakuPasswordTextBox.Text.Trim();
                if (!Global.SankakuClient.Login())
                {
                    MessageBox.Show("Could not log in to Sankaku!");
                }
                else
                {
                    await ControlHandler.LogAsync("[SANKAKU] Logged in to Sankaku!");
                    Program.UserInterface.SankakuLoginButton.Enabled = false;
                    Program.UserInterface.SankakuPasswordTextBox.Enabled = false;
                    Program.UserInterface.SankakuUserNameTextBox.Enabled = false;
                    Global.SettingsHandler.SaveSettings();
                    await ControlHandler.ShowSettingsValueAsync();
                }
            }
        }

        private void osuapikeyButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(osuapikeyTextBox.Text.Trim()))
            {
                Global.SettingsHandler.Settings.osuAPIKey = osuapikeyTextBox.Text.Trim();
            }
        }

        //DM Part
        private async void DMSelectionChanged(object s, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                DMUploadButton.Enabled = true;
                SelectedDMIndex = DMListView.SelectedIndices.Cast<int>().FirstOrDefault();
                SocketDMChannel SelectedDMChannel = Global.Kuro.Client.DMChannels.Where(u => u.Recipient.Username + "#" + u.Recipient.Discriminator == DMListView.SelectedItems[0].Text).FirstOrDefault();
                Program.UserInterface.Text = "[PRIVATE] " + "#" + SelectedDMChannel.Recipient.Username;
                Program.UserInterface.Refresh();
                IEnumerable<IMessage> messages = await (Global.Kuro.Client.GetChannel(SelectedDMChannel.Id) as SocketDMChannel).GetMessagesAsync(60).Flatten<IMessage>();
                await ControlHandler.ClearDMAsync();
                for (int i = messages.Count() - 1; i >= 0; i--)
                {
                    IMessage message = messages.ElementAt(i);
                    await ControlHandler.LogDMAsync("[" + message.Timestamp.LocalDateTime + "] " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content));
                }
            }
        }

        private void SendFileDMChannel(object sender, EventArgs e)
        {
            if (Global.Kuro.Client.DMChannels.Count > 0)
            {
                OpenFileDialog file = new OpenFileDialog()
                {
                    Multiselect = false
                };
                file.FileOk += async (o, ev) =>
                {
                    SocketDMChannel ch = Global.Kuro.Client.DMChannels.Where(u => u.Recipient.Username + "#" + u.Recipient.Discriminator == DMListView.Items[(int)SelectedDMIndex].Text).FirstOrDefault();
                    await ch?.SendFileAsync(file.InitialDirectory + file.FileName, string.Empty);
                };
                file.ShowDialog();
            }
        }

        private async void DMTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectedDMIndex != null)
                {
                    SocketDMChannel ch = Global.Kuro.Client.DMChannels.Where(u => u.Recipient.Username + "#" + u.Recipient.Discriminator == DMListView.Items[(int)SelectedDMIndex].Text).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(DMInTextBox.Text.Trim()))
                    {
                        await ch?.SendMessageAsync(DMInTextBox.Text.Trim());
                        DMInTextBox.Text = string.Empty;
                    }
                }
            }
        }

        private void DMListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DMInTextBox_Click(object sender, EventArgs e)
        {

        }
    }
}
