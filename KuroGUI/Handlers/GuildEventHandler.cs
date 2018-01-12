using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuroGUI.Handlers;

namespace KuroGUI.Handlers
{
    public class GuildEventHandler
    {
        public GuildEventHandler() { }
        public Task Log(LogMessage msg)
        {
            ControlHandler.LogAsync(msg.Source + " " + msg.Message);
            return Task.CompletedTask;
        }

        public async Task MessageReceived(SocketMessage message)
        {
            string Guild = message.Channel is SocketDMChannel ? "PRIVATE" : (message.Channel as SocketGuildChannel).Guild.Name;
            if (Guild != "PRIVATE")
            {
                if (Program.UserInterface.SelectedChannels.Count != 0 && Program.UserInterface.SelectedChannels.IndexOf(message.Channel as SocketTextChannel) > -1)
                {
                    SocketTextChannel ch = Program.UserInterface.SelectedChannels[Program.UserInterface.SelectedChannels.IndexOf(message.Channel as SocketTextChannel)];
                    if (message.Channel.Name == ch.Name && Guild == ch.Guild.Name)
                    {
                        await ControlHandler.LogAsync("[" + message.Timestamp.LocalDateTime + "] " + "#" + message.Channel.Name + " | " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content), Guild);
                    }
                    else
                    {
                        await ControlHandler.LogAsync("[" + message.Timestamp.LocalDateTime + "] " + "#" + message.Channel.Name + " | " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content));
                    }
                }
                else
                {
                    await ControlHandler.LogAsync("[" + message.Timestamp.LocalDateTime + "] " + "#" + message.Channel.Name + " | " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content));
                }
            }
            else
            {
                Program.UserInterface.DMListView.Invoke(new Action(async() =>
                {
                    SocketDMChannel Channel = message.Channel as SocketDMChannel;
                    await ControlHandler.LogAsync("[" + message.Timestamp.LocalDateTime + "] PRIVATE/" + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content));
                    if (Program.UserInterface.DMListView.Items.IndexOf(Program.UserInterface.DMListView.FindItemWithText(Channel.Recipient.Username +"#"+ Channel.Recipient.Discriminator)) == -1)
                    {
                        await ControlHandler.AddNewDM(Channel.Recipient.Username + "#" + Channel.Recipient.Discriminator);
                    }
                    if (Program.UserInterface.SelectedDMIndex != null) {
                        if ((int)Program.UserInterface.SelectedDMIndex == Program.UserInterface.DMListView.Items.IndexOf(Program.UserInterface.DMListView.FindItemWithText(Channel.Recipient.Username + "#" + Channel.Recipient.Discriminator)))
                        {
                            await ControlHandler.LogDMAsync("[" + message.Timestamp.LocalDateTime + "] " + message.Author + ": " + (message.Attachments.Count != 0 ? "[" + message.Attachments.FirstOrDefault().Url + "] " + message.Content : message.Content));
                        }
                    }
                }));
            }
        }

        public async Task ClientReady()
        {
            await ControlHandler.LogAsync("[CONNECTED] Successfully connected to Discord!");
            await Global.SettingsHandler.RefreshGuildChangesAsync();
            Program.UserInterface.ConnectButton.Invoke(new Action(() =>
            {
                Program.UserInterface.ConnectButton.Enabled = false;
            }));
            await Global.Kuro.Client.SetGameAsync(Global.SettingsHandler.Settings.Game);
        }

        public async Task ChannelUpdate(SocketChannel UpdatedChannel)
        {
            if (!(UpdatedChannel is SocketDMChannel))
            {
                await ControlHandler.ResetTabsAsync();
                await Global.SettingsHandler.RefreshGuildChangesAsync();
                await ControlHandler.AddTabsAsync();
            }
        }

        public async Task GreetNewUser(SocketGuildUser NewUser)
        {
            if (Global.SettingsHandler.Settings.GreetMessages.FindIndex(k => k.GuildID == NewUser.Guild.Id) > -1)
            {
                ulong GuildID = Global.SettingsHandler.Settings.GreetMessages.Find(k => k.GuildID == NewUser.Guild.Id).GuildID;
                GreetMessage msg = Global.SettingsHandler.Settings.GreetMessages.Find(u => u.GuildID == GuildID);
                SocketTextChannel GreetChannel = (SocketTextChannel)Global.Kuro.Client.GetChannel(msg.ChannelID);
                string msgtosend = msg.Message.Replace("{UserName}", NewUser.Username).Replace("{UserMention}", NewUser.Mention).Replace("{GuildName}", GreetChannel.Guild.Name);
                await GreetChannel.SendMessageAsync(msgtosend);
            }
        }

        public async Task ChannelModified(SocketChannel OldChannel, SocketChannel NewChannel)
        {
            await ControlHandler.ResetTabsAsync();
            await Global.SettingsHandler.RefreshGuildChangesAsync();
            await ControlHandler.AddTabsAsync();
        }

        public async Task GuildJoinLeave(SocketGuild Guild)
        {
            await ControlHandler.ResetTabsAsync();
            await Global.SettingsHandler.RefreshGuildChangesAsync();
            await ControlHandler.AddTabsAsync();
        }

        public async Task GuildModifed(SocketGuild OldGuild, SocketGuild NewGuild)
        {
            await ControlHandler.ResetTabsAsync();
            await Global.SettingsHandler.RefreshGuildChangesAsync();
            await ControlHandler.AddTabsAsync();
        }

    }
}
