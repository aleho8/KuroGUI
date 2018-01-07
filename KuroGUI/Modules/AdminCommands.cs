using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using KuroGUI.Privileges;
using KuroGUI.Handlers;
using Discord.WebSocket;

namespace KuroGUI.Modules
{
    public class AdminCommands : ModuleBase<SocketCommandContext>
    {

        private readonly CommandService Service;
        public AdminCommands(CommandService _service)
        {
            Service = _service;
        }

        [Command("addbl"), Alias("addblacklist"), Summary("Adds the channel to the blacklist so the bot won't see commands in them."), IsAdmin()]
        public async Task BlackListAdd(ulong ChannelID = 0)
        {
            SocketTextChannel BLChannel = ChannelID != 0 ? Global.Kuro.Client.GetChannel(ChannelID) as SocketTextChannel : Context.Channel as SocketTextChannel;
            if (await PermHandler.AddBlackList(BLChannel, Context.User.Username))
            {
                await Context.Channel.SendMessageAsync("Added `" + BLChannel.Id + "` to the BlackListed channels!");
            }
            else
            {
                await Context.Channel.SendMessageAsync("This channel is already blacklisted!");
            }
        }
        [Command("rembl"), Alias("removeblacklist"), Summary("Removes the channel from the blacklist so the bot will see commands in them."), IsAdmin()]
        public async Task BlackListRemove(ulong ChannelID = 0)
        {
            SocketTextChannel BLChannel = ChannelID != 0 ? Global.Kuro.Client.GetChannel(ChannelID) as SocketTextChannel : Context.Channel as SocketTextChannel;
            if (await PermHandler.RemoveBlackList(BLChannel))
            {
                await Context.Channel.SendMessageAsync("Removed `" + ChannelID + "` from the BlackListed channels!");
            }
            else
            {
                await Context.Channel.SendMessageAsync("This channel is not blacklisted!");
            }
        }
        [Command("addad"), Alias("addadmin"), Summary("Adds the user to the blacklist so the bot won't see commands in them."), IsAdmin()]
        public async Task AdminAdd(SocketUser NewAdmin)
        {

            if (await PermHandler.AddAdmin(NewAdmin.Username, NewAdmin.Id, Context.User.Username))
            {
                await Context.Channel.SendMessageAsync("Added `" + NewAdmin.Mention + "` to my Admins!");
            }
            else
            {
                await Context.Channel.SendMessageAsync("This user is already an admin!");
            }
        }
        [Command("remad"), Alias("removeadmin"), Summary("Removes the admin from the Adminlist so they will have less permissions and commands to use."), IsAdmin()]
        public async Task AdminRemove(SocketUser OldAdmin)
        {

            if (await PermHandler.RemoveAdmin(OldAdmin.Id))
            {
                await Context.Channel.SendMessageAsync("Removed `" + OldAdmin.Mention + "` from the admin list!");
            }
            else
            {
                await Context.Channel.SendMessageAsync("The specified user is not an admin!");
            }
        }
    }
}
