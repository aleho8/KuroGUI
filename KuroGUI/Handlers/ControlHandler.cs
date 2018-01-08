using Discord.WebSocket;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuroGUI.Handlers
{
    public static class ControlHandler
    {
        public static Task LogAsync(string Message, string GuildName = "")
        {
            if (GuildName != "")
            {
                Program.UserInterface.tabControl1.Invoke(new Action(() =>
                {
                    foreach (TabPage t in Program.UserInterface.tabControl1.TabPages)
                    {
                        if (t.Text.Trim() == GuildName && GuildName != "PRIVATE")
                        {
                            RichTextBox frtb = (RichTextBox)t.Controls.Find("ChatOutBox", false).FirstOrDefault();
                            while (frtb.TextLength + Message.Length >= frtb.MaxLength)
                            {
                                frtb.Text = frtb.Text.Substring(frtb.Text.IndexOf("\n") + 1);
                            }
                            frtb.AppendText("\n" + Message);
                        }
                    }
                }));
            }
            Program.UserInterface.ChatOutBox.Invoke(new Action(() =>
            {
                Program.UserInterface.ChatOutBox.AppendText("\n" + Message);
            }));
            return Task.CompletedTask;
        }
        public static Task ClearAsync(string GuildName)
        {
            Program.UserInterface.tabControl1.Invoke(new Action(() =>
            {
                foreach (TabPage t in Program.UserInterface.tabControl1.TabPages)
                {
                    if (t.Text.Trim() == GuildName && GuildName != "PRIVATE")
                    {
                        ((RichTextBox)t.Controls.Find("ChatOutBox", false).FirstOrDefault()).Text = "";
                    }
                }
            }));
            return Task.CompletedTask;
        }
        public static Task LogCacheAsync(string Message, string GuildName)
        {
            Program.UserInterface.tabControl1.Invoke(new Action(() =>
            {
                foreach (TabPage t in Program.UserInterface.tabControl1.TabPages)
                {
                    if (t.Text.Trim() == GuildName)
                    {
                        RichTextBox frtb = (RichTextBox)t.Controls.Find("ChatOutBox", false).FirstOrDefault();
                        while (frtb.TextLength + Message.Length >= frtb.MaxLength)
                        {
                            frtb.Text = frtb.Text.Substring(frtb.Text.IndexOf("\n") + 1);
                        }
                        frtb.AppendText("\n" + Message);
                    }
                }
            }));
            return Task.CompletedTask;
        }

        public static Task ShowSettingsValueAsync()
        {
            Program.UserInterface.SettingsPage.Invoke(new Action(() =>
            {
            Program.UserInterface.AdminListView.Invoke(new Action(() =>
            {
                Program.UserInterface.AdminListView.Items.Clear();
                foreach (AdminUser admin in Global.SettingsHandler.Settings.Admins)
                {
                    Program.UserInterface.AdminListView.Items.Add(admin.Username);
                }
            }));
            Program.UserInterface.BlackListView.Invoke(new Action(() =>
            {
                Program.UserInterface.BlackListView.Items.Clear();
                foreach (BlackListedChannel channel in Global.SettingsHandler.Settings.BlackListChannels)
                {
                    Program.UserInterface.BlackListView.Items.Add(new ListViewItem(new string[] { channel.Guild, channel.Channel, channel.Id.ToString() }));
                }
            }));
            Program.UserInterface.SetGameTextBox.Invoke(new Action(() =>
            {
                Program.UserInterface.SetGameTextBox.Text = Global.SettingsHandler.Settings.Game;
            }));
            Program.UserInterface.MessagesListView.Invoke(new Action(() =>
            {
                Program.UserInterface.MessagesListView.Items.Clear();
                Console.WriteLine(Global.SettingsHandler.Settings.GreetMessages.Count);
                foreach (GreetMessage msg in Global.SettingsHandler.Settings.GreetMessages)
                {
                    Program.UserInterface.MessagesListView.Items.Add(new ListViewItem(new string[] { msg.GuildName, msg.ChannelName, msg.Message }));
                }
            }));
            Program.UserInterface.OwnerIDBox.Invoke(new Action(() => { Program.UserInterface.OwnerIDBox.Text = Global.SettingsHandler.Settings.OwnerID.ToString(); }));
            }));
            return Task.CompletedTask;
        }

        public static Task ResetTabsAsync()
        {
            Program.UserInterface.tabControl1.Invoke(new Action(() =>
            {
                for (int i = 2; i < Program.UserInterface.tabControl1.TabCount;)
                {
                    try
                    {
                        Program.UserInterface.tabControl1.TabPages[i].Dispose();
                    }
                    catch { }
                }
            }));
            Program.UserInterface.ChannelListView.Invoke(new Action(() => { Program.UserInterface.ChannelListView.Items.Clear(); }));
            Program.UserInterface.MessagesListView.Invoke(new Action(() => { Program.UserInterface.MessagesListView.Items.Clear(); }));
            Program.UserInterface.UserJoinChannelsComboBox.Invoke(new Action(() => { Program.UserInterface.UserJoinChannelsComboBox.Items.Clear(); }));
            Program.UserInterface.ConnectedMessageAddButton.Invoke(new Action(() => {
                if (Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Connected || Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Connecting)
                {
                    Program.UserInterface.ConnectedMessageAddButton.Enabled = true;
                }
                else if (Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Disconnected || Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Disconnecting)
                {
                    Program.UserInterface.ConnectedMessageAddButton.Enabled = false;
                }
            }));
            Program.UserInterface.FileSendButton.Invoke(new Action(() => { Program.UserInterface.FileSendButton.Enabled = false; }));
            Program.UserInterface.ConnectButton.Invoke(new Action(() => {
                if (Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Connected || Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Connecting)
                {
                    Program.UserInterface.ConnectButton.Enabled = false;
                }
                else if (Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Disconnected || Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Disconnecting)
                {
                    Program.UserInterface.ConnectButton.Enabled = true;
                }
                else
                {
                    Console.WriteLine("wtfwtfwtf");
                }
            }));
            Program.UserInterface.DisconnectButton.Invoke(new Action(() => {
                if (Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Connected || Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Connecting)
                {
                    Program.UserInterface.DisconnectButton.Enabled = true;
                }
                else if (Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Disconnected || Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Disconnecting)
                {
                    Program.UserInterface.DisconnectButton.Enabled = false;
                }
            }));
            ControlHandler.LogAsync("[LOGHANDLER] Reset controls!");
            return Task.CompletedTask;
        }

        public static Task AddTabsAsync()
        {
            if (Global.Kuro.Client.ConnectionState == Discord.ConnectionState.Connected)
            {
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
            }
            Program.UserInterface.tabControl1.Invoke(new Action(() =>
            {
               Program.UserInterface.UserJoinChannelsComboBox.Invoke(new Action(() =>
                {
                    foreach (SocketGuild g in Global.Kuro.Client.Guilds)
                    {
                        ListView lv = new ListView()
                        {
                            View = View.List,
                            Size = Program.UserInterface.ChannelListView.Size,
                            Location = Program.UserInterface.ChannelListView.Location,
                            ForeColor = Program.UserInterface.ChannelListView.ForeColor,
                            BackColor = Program.UserInterface.ChannelListView.BackColor
                        };
                        MetroButton bt = new MetroButton()
                        {
                            Name = "FileSendButton",
                            Text = "Upload Image",
                            Style = MetroFramework.MetroColorStyle.Blue,
                            Theme = MetroFramework.MetroThemeStyle.Dark,
                            Size = Program.UserInterface.FileSendButton.Size,
                            Location = Program.UserInterface.FileSendButton.Location
                        };
                        bt.Click += Program.UserInterface.FileSendButton_Click;
                        lv.ItemSelectionChanged += Program.UserInterface.ChannelSelectionChanged;
                        RichTextBox rtb = new RichTextBox()
                        {
                            ReadOnly = true,
                            ScrollBars = RichTextBoxScrollBars.Vertical,
                            Name = "ChatOutBox",
                            Cursor = Program.UserInterface.ChatOutBox.Cursor,
                            Size = Program.UserInterface.ChatOutBox.Size,
                            Location = Program.UserInterface.ChatOutBox.Location,
                            Font = Program.UserInterface.ChatOutBox.Font,
                            BackColor = Program.UserInterface.ChatOutBox.BackColor,
                            ForeColor = Program.UserInterface.ChatOutBox.ForeColor,
                            BorderStyle = System.Windows.Forms.BorderStyle.None
                        };
                        rtb.LinkClicked += Program.UserInterface.ChatOutBox_LinkClicked;
                        rtb.TextChanged += Program.UserInterface.richTextBox_TextChanged;
                        MetroTextBox tb = new MetroTextBox()
                        {
                            Name = "ChatInBox",
                            Size = Program.UserInterface.ChatInBox.Size,
                            Location = Program.UserInterface.ChatInBox.Location,
                            Style = MetroFramework.MetroColorStyle.Blue,
                            Theme = MetroFramework.MetroThemeStyle.Dark,
                            WaterMark = "Chat Message",

                        };
                        tb.KeyUp += Program.UserInterface.ChatInBox_KeyUp;
                        TabPage tp = new MetroTabPage()
                        {
                            Text = g.Name,
                            Style = MetroFramework.MetroColorStyle.Blue,
                            Theme = MetroFramework.MetroThemeStyle.Dark
                        };
                        Program.UserInterface.tabControl1.TabPages.Add(tp);
                        tp.Controls.Add(lv);
                        tp.Controls.Add(bt);
                        tp.Controls.Add(rtb);
                        tp.Controls.Add(tb);

                        foreach (SocketGuildChannel ch in g.Channels)
                        {
                            if (ch is SocketTextChannel)
                            {
                                Program.UserInterface.UserJoinChannelsComboBox.Items.Add("[" + g.Name + "] #" + ch.Name);
                                lv.Items.Add("[" + g.Name + "] #" + ch.Name);
                            }
                        }
                    }
                    Program.UserInterface.tabControl1.Refresh();
                }));
            }));
            return Task.CompletedTask;
        }

    }
}
