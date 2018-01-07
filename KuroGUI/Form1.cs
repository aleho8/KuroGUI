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

using KuroGUI.Handlers;

namespace KuroGUI
{
    public partial class MainGUI : MetroForm
    {
        private List<SocketTextChannel> SelectedChannels = new List<SocketTextChannel>();
        private int PresenceIndex = 0;
        public MainGUI()
        {
            InitializeComponent();
        }

        private async void MainGUI_Load(object sender, EventArgs e)
        {
            await Global.Start();
            if (!string.IsNullOrEmpty(Global.Settingshandler.Settings.SavedToken))
            {
                TokenBox.Text = Global.Settingshandler.Settings.SavedToken;
                TokenSaveCheck.Checked = true;
            }
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                await Global.Kuro.ConnectAsync(TokenBox.Text.Trim());
                Global.Kuro.Client.Ready += () =>
                {
                    tabControl1.Invoke(new Action(() =>
                    {
                        foreach (SocketGuild g in Global.Kuro.Client.Guilds)
                        {
                            ListView lv = new ListView()
                            {
                                View = View.List,
                                Size = ChannelListView.Size,
                                Location = ChannelListView.Location,
                                ForeColor = ChannelListView.ForeColor,
                                BackColor = ChannelListView.BackColor
                            };
                            MetroButton bt = new MetroButton()
                            {
                                Name = "FileSendButton",
                                Text = "Upload Image",
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Size = FileSendButton.Size,
                                Location = FileSendButton.Location
                            };
                            bt.Click += FileSendButton_Click;
                            lv.ItemSelectionChanged += ChannelSelectionChanged;
                            RichTextBox rtb = new RichTextBox()
                            {
                                ReadOnly = true,
                                ScrollBars = RichTextBoxScrollBars.Vertical,
                                Name = "ChatOutBox",
                                Cursor = ChatOutBox.Cursor,
                                Size = ChatOutBox.Size,
                                Location = ChatOutBox.Location,
                                Font = ChatOutBox.Font,
                                BackColor = ChatOutBox.BackColor,
                                ForeColor = ChatOutBox.ForeColor,
                                BorderStyle = System.Windows.Forms.BorderStyle.None
                            };
                            rtb.LinkClicked += ChatOutBox_LinkClicked;
                            rtb.TextChanged += richTextBox_TextChanged;
                            MetroTextBox tb = new MetroTextBox()
                            {
                                Name = "ChatInBox",
                                Size = ChatInBox.Size,
                                Location = ChatInBox.Location,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                WaterMark = "Chat Message",

                            };
                            tb.KeyUp += ChatInBox_KeyUp;
                            TabPage tp = new MetroTabPage()
                            {
                                Text = g.Name,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Theme = MetroFramework.MetroThemeStyle.Dark
                            };
                            tabControl1.TabPages.Add(tp);
                            tp.Controls.Add(lv);
                            tp.Controls.Add(bt);
                            tp.Controls.Add(rtb);
                            tp.Controls.Add(tb);

                            foreach (SocketGuildChannel ch in g.Channels)
                            {
                                if (ch is SocketTextChannel)
                                {
                                    lv.Items.Add("[" + g.Name + "] #" + ch.Name);
                                }
                            }
                        }
                        tabControl1.Refresh();
                    }));
                    return Task.CompletedTask;
                };
                Global.Kuro.Client.Ready += ClientReady;
                Global.Kuro.Client.MessageReceived += MessageReceived;
                Global.Kuro.Client.Log += Log;
                Program.UserInterface.FileSendButton.Enabled = true;
                Program.UserInterface.ConnectButton.Enabled = false;
                Program.UserInterface.DisconnectButton.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error happened while logging in!" + ex.Message);
            }
        }
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            ((RichTextBox)sender).SelectionStart = ((RichTextBox)sender).Text.Length;
            ((RichTextBox)sender).ScrollToCaret();
        }
        private async void ChannelSelectionChanged(object s, ListViewItemSelectionChangedEventArgs e)
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
                IEnumerable<IMessage> messages = await (Global.Kuro.Client.GetChannel(SelectedChannel.Id) as SocketTextChannel).GetMessagesAsync(40).Flatten<IMessage>();
                await LogHandler.Clear(SelectedChannel.Guild.Name);
                for (int i = messages.Count() - 1; i >= 0; i--)
                {
                    IMessage message = messages.ElementAt(i);
                    string Guild = (message.Channel as SocketGuildChannel).Guild.Name;
                    await LogHandler.LogCache("[" + message.Timestamp.LocalDateTime + "] " + "#" + message.Channel.Name + " | " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content), Guild);
                }
            }
        }
        private Task Log(LogMessage msg)
        {
            LogHandler.Log(msg.Source + " " + msg.Message);
            return Task.CompletedTask;
        }
        private Task MessageReceived(SocketMessage message)
        {
            string Guild = message.Channel is SocketDMChannel ? "PRIVATE" : (message.Channel as SocketGuildChannel).Guild.Name;
            if (SelectedChannels.Count != 0 && SelectedChannels.IndexOf(message.Channel as SocketTextChannel) > -1)
            {
                SocketTextChannel ch = SelectedChannels[SelectedChannels.IndexOf(message.Channel as SocketTextChannel)];
                if (message.Channel.Name == ch.Name && Guild == ch.Guild.Name)
                {
                    LogHandler.Log("[" + message.Timestamp.LocalDateTime + "] " + "#" + message.Channel.Name + " | " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content), Guild);
                }
                else
                {
                    LogHandler.Log("[" + message.Timestamp.LocalDateTime + "] " + "#" + message.Channel.Name + " | " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content));
                }
            }
            else
            {
                LogHandler.Log("[" + message.Timestamp.LocalDateTime + "] " + "#" + message.Channel.Name + " | " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content));
            }
            return Task.CompletedTask;
        }
        private async Task ClientReady()
        {
            await LogHandler.Log("[CONNECTED] Successfully connected to Discord!");
            await Global.Settingshandler.RefreshChangedNames();
            Program.UserInterface.ConnectButton.Invoke(new Action(() =>
            {
                ConnectButton.Enabled = false;
            }));
            Program.UserInterface.ChannelListView.Invoke(new Action(() =>
            {
                foreach (SocketGuild guild in Global.Kuro.Client.Guilds)
                {
                    foreach (SocketGuildChannel ch in guild.Channels)
                    {
                        if (ch is SocketTextChannel)
                        {
                            Program.UserInterface.ChannelListView.Items.Add("[" + guild.Name + "] #" + ch.Name);
                        }
                    }
                }
            }));
            await Global.Kuro.Client.SetGameAsync("owo >.>");
            await (Global.Kuro.Client.GetChannel(384783449229361185) as SocketTextChannel).SendMessageAsync("`Connected to Discord!`");
        }
        private void ChatOutBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
        private async void ChatInBox_KeyUp(object sender, KeyEventArgs e)
        {
            SocketTextChannel ch = SelectedChannels.Find(o => o.Guild.Name == tabControl1.SelectedTab.Text);
            if (ch != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    await SendMessageAsync(((MetroTextBox)sender).Text.Trim(), ch.Id);
                    ((MetroTextBox)sender).Text = "";
                }
            }
        }
        private async Task SendMessageAsync(string message, ulong ChannelID)
        {
            await (Global.Kuro.Client.GetChannel(ChannelID) as SocketTextChannel).SendMessageAsync(message);
        }
        private async Task SendFileAsync(string file, ulong ChannelID)
        {
            await (Global.Kuro.Client.GetChannel(ChannelID) as SocketTextChannel).SendFileAsync(file, string.Empty);
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            Global.Kuro.Disconnect();
            Program.UserInterface.ConnectButton.Enabled = true;
            Program.UserInterface.DisconnectButton.Enabled = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SocketTextChannel ch = SelectedChannels.Find(o => o.Guild.Name == tabControl1.SelectedTab.Text);
            if (ch != null)
            {
                Program.UserInterface.Text = "[" + ch.Guild.Name + "] " + "#" + ch.Name;
                Program.UserInterface.Refresh();
            }
        }

        private void FileSendButton_Click(object sender, EventArgs e)
        {
            if (SelectedChannels.Count > 0)
            {
                OpenFileDialog file = new OpenFileDialog()
                {
                    Multiselect = false
                };
                file.FileOk += async (o, ev) =>
                {
                    Console.WriteLine(file.InitialDirectory + file.FileName);
                    await SendFileAsync(file.InitialDirectory + file.FileName, SelectedChannels.Find(k => k.Guild.Name == tabControl1.SelectedTab.Text).Id);
                };
                file.ShowDialog();
            }
        }

        private void MainGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TokenSaveCheck.Checked) Global.Settingshandler.Settings.SavedToken = TokenBox.Text.Trim();
            Global.Settingshandler.SaveSettings();
        }

        private void PresenceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PresenceIndex = PresenceBox.SelectedIndex == -1 ? 0 : PresenceBox.SelectedIndex;
        }

        private async void SetGameButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SetGameTextBox.Text.Trim()))
            {
                UserStatus Status = (UserStatus)(Enum.GetValues(typeof(UserStatus)).GetValue(PresenceIndex));
                string Game = SetGameTextBox.Text.Trim();
                Global.Settingshandler.Settings.Game = Game;
                Global.Settingshandler.Settings.GameStatus = Status;
                await Global.Kuro.Client.SetStatusAsync(Status);
                await Global.Kuro.Client.SetGameAsync(Game);
            }
        }
    }
}
