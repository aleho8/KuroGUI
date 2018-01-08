using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord;
using Discord.WebSocket;

namespace KuroGUI.Handlers
{
    public static class PermHandler
    {
        //Blacklist stuff
        public async static Task<bool> AddBlackList(SocketTextChannel Channel, string AddedBy)
        {
            if (Global.SettingsHandler.Settings.BlackListChannels.FindIndex(u => u.Id == Channel.Id) == -1)
            {
                Global.SettingsHandler.Settings.BlackListChannels.Add(new BlackListedChannel(Channel.Guild.Name, Channel.Id, Channel.Name, AddedBy));
                await ControlHandler.LogAsync("[PERMHANLDER] Blacklisted channel has been Added: " + Channel.Id);
                Global.SettingsHandler.SaveSettings();
                await ControlHandler.ShowSettingsValueAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool BlackListed(SocketTextChannel Channel)
        {
            return Global.SettingsHandler.Settings.BlackListChannels.Any(u => u.Id == Channel.Id);
        }
        public async static Task<bool> RemoveBlackList(SocketTextChannel Channel)
        {
            if (Global.SettingsHandler.Settings.BlackListChannels.FindIndex(u => u.Id == Channel.Id) > -1)
            {
                Global.SettingsHandler.Settings.BlackListChannels.Remove(Global.SettingsHandler.Settings.BlackListChannels.Find(u => u.Id == Channel.Id));
                await ControlHandler.LogAsync("[PERMHANLDER] Blacklisted channel has been Removed: " + Channel.Id);
                Global.SettingsHandler.SaveSettings();
                await ControlHandler.ShowSettingsValueAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        //Admin stuff
        public async static Task<bool> AddAdmin(string Username, ulong UserID, string Addedby)
        {
            if (Global.SettingsHandler.Settings.Admins.FindIndex(u => u.Id == UserID) == -1)
            {
                Global.SettingsHandler.Settings.Admins.Add(new AdminUser(Username, UserID, Addedby));
                await ControlHandler.LogAsync("[PERMHANLDER] An admin has been added: " + Username);
                Global.SettingsHandler.SaveSettings();
                await ControlHandler.ShowSettingsValueAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsAdmin(ulong UserID)
        {
            return ((Global.SettingsHandler.Settings.Admins.FindIndex(u => u.Id == UserID) > -1) || (UserID == Global.SettingsHandler.Settings.OwnerID));
        }
        public async static Task<bool> RemoveAdmin(ulong UserID)
        {
            if (Global.SettingsHandler.Settings.Admins.FindIndex(u => u.Id == UserID) == -1)
            {
                AdminUser OldAdmin = Global.SettingsHandler.Settings.Admins.Find(u => u.Id == UserID);
                await ControlHandler.LogAsync("[PERMHANLDER] An admin has been Removed: " + OldAdmin.Username);
                Global.SettingsHandler.Settings.Admins.Remove(Global.SettingsHandler.Settings.Admins.Find(u => u.Id == UserID));
                Global.SettingsHandler.SaveSettings();
                await ControlHandler.ShowSettingsValueAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class AdminUser
    {
        public string Username { get; set; }
        public ulong Id { get; set; }
        public string AddedBy { get; set; }

        public AdminUser(string _Username, ulong _Id, string _AddedBy)
        {
            this.Username = _Username;
            this.Id = _Id;
            this.AddedBy = _AddedBy;
        }
    }
    public class BlackListedChannel
    {
        public string Guild { get; set; }
        public ulong Id { get; set; }
        public string Channel { get; set; }
        public string AddedBy { get; set; }

        public BlackListedChannel(string _Guild, ulong _Id, string _Channel ,string _AddedBy)
        {
            this.Guild = _Guild;
            this.Id = _Id;
            this.Channel = _Channel;
            this.AddedBy = _AddedBy;
        }
    }
}
