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
        public async Task BlackListAdd(ulong ChannelID)
        {
            if (Global.PermHandler.IsAdmin(Context.User.Id))
            {
                try
                {
                    Global.PermHandler.AddBlackList(ChannelID);
                    await Context.Channel.SendMessageAsync("Added `" + ChannelID + "` to the BlackListed channels!");
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync("Error: `" + e.Message + "`");
                }
            }
        }
        [Command("rembl"), Alias("removeblacklist"), Summary("Removes the channel from the blacklist so the bot will see commands in them.")]
        public async Task BlackListRemove(ulong ChannelID)
        {
            if (Global.PermHandler.IsAdmin(Context.User.Id))
            {
                try
                {
                    Global.PermHandler.RemoveBlackList(ChannelID);
                    await Context.Channel.SendMessageAsync("Removed `" + ChannelID + "` from the BlackListed channels!");
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync("Error: `" + e.Message + "`");
                }
            }
        }
        [Command("addad"), Alias("addadmin"), Summary("Adds the user to the blacklist so the bot won't see commands in them.")]
        public async Task BlackListAdd(IGuildUser NewAdmin)
        {
            if (Global.PermHandler.IsAdmin(Context.User.Id))
            {
                try
                {
                    Global.PermHandler.AddAdmin(NewAdmin.Id);
                    await Context.Channel.SendMessageAsync("Added `" + NewAdmin.Mention + "` to my Admins!");
                    await LogHandler.Log("[PERMHANLDER] An admin has been added: " + NewAdmin.Nickname);
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync("Error: `" + e.Message + "`");
                }
            }
        }
        [Command("remad"), Alias("removeadmin"), Summary("Removes the admin from the Adminlist so they will have less permissions and commands to use.")]
        public async Task BlackListRemove(IGuildUser OldAdmin)
        {
            if (Global.PermHandler.IsAdmin(Context.User.Id))
            {
                try
                {
                    Global.PermHandler.RemoveAdmin(OldAdmin.Id);
                    await Context.Channel.SendMessageAsync("Removed `" + OldAdmin.Mention + "` from the admin list!");
                    await LogHandler.Log("[PERMHANLDER] An admin has been removed: " + OldAdmin.Nickname);
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync("Error: `" + e.Message + "`");
                }
            }
        }
    }
}
