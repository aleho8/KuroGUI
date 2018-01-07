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
using Newtonsoft.Json;

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
        [Command("addbl"), Alias("addblacklist"), Summary("Adds the channel to the blacklist so the bot won't see commands in them.")]
        public async Task BlackListAdd(ulong ChannelID = 0)
        {
            if (PermHandler.IsAdmin(Context.User.Id))
            {
                try
                {
                    SocketTextChannel BLChannel = ChannelID != 0 ? Global.Kuro.Client.GetChannel(ChannelID) as SocketTextChannel : Context.Channel as SocketTextChannel;
                    PermHandler.AddBlackList(BLChannel, Context.User.Username);
                    await Context.Channel.SendMessageAsync("Added `" + BLChannel.Id + "` to the BlackListed channels!");
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync("Error: `" + e.Message + "`");
                }
            }
        }
        [Command("rembl"), Alias("removeblacklist"), Summary("Removes the channel from the blacklist so the bot will see commands in them.")]
        public async Task BlackListRemove(ulong ChannelID = 0)
        {
            if (PermHandler.IsAdmin(Context.User.Id))
            {
                try
                {
                    PermHandler.RemoveBlackList(ChannelID == 0 ? Global.Kuro.Client.GetChannel(ChannelID) as SocketTextChannel : Context.Channel as SocketTextChannel);
                    await Context.Channel.SendMessageAsync("Removed `" + ChannelID + "` from the BlackListed channels!");
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync("Error: `" + e.Message + "`");
                }
            }
        }
        [Command("addad"), Alias("addadmin"), Summary("Adds the user to the blacklist so the bot won't see commands in them.")]
        public async Task AdminAdd(SocketUser NewAdmin)
        {
                try
                {
                    PermHandler.AddAdmin(NewAdmin.Username, NewAdmin.Id, Context.User.Username);
                    await Context.Channel.SendMessageAsync("Added `" + NewAdmin.Mention + "` to my Admins!");
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync("Error: `" + e.Message + "`");
                }
        }
        [Command("remad"), Alias("removeadmin"), Summary("Removes the admin from the Adminlist so they will have less permissions and commands to use.")]
        public async Task AdminRemove(SocketUser OldAdmin)
        {
            if (PermHandler.IsAdmin(Context.User.Id))
            {
                try
                {
                    PermHandler.RemoveAdmin(OldAdmin.Id);
                    await Context.Channel.SendMessageAsync("Removed `" + OldAdmin.Mention + "` from the admin list!");
                    await LogHandler.Log("[PERMHANLDER] An admin has been removed: " + OldAdmin.Username);
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync("Error: `" + e.Message + "`");
                }
            }
        }
    }
}
