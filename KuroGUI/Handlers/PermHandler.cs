using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace KuroGUI.Handlers
{
    public static class PermHandler
    {
        //Blacklist stuff
        public async static void AddBlackList(SocketTextChannel Channel, string AddedBy)
        {
            if (Global.Settingshandler.Settings.BlackListChannels.FindIndex(u => u.Id == Channel.Id) == -1)
            {
                Global.Settingshandler.Settings.BlackListChannels.Add(new BlackListedChannel(Channel.Guild.Name, Channel.Id, Channel.Name, AddedBy));
                await LogHandler.Log("[PERMHANLDER] Blacklisted channel has been Added: " + Channel.Id);
                Global.Settingshandler.SaveSettings();
                await Global.Settingshandler.RefreshSettings();
            }
            else
            {
                throw new Exception("This Channel is already in the BlackList!");
            }
        }
        public static bool BlackListed(SocketTextChannel Channel)
        {
            return Global.Settingshandler.Settings.BlackListChannels.Any(u => u.Id == Channel.Id);
        }
        public async static void RemoveBlackList(SocketTextChannel Channel)
        {
            if (Global.Settingshandler.Settings.BlackListChannels.FindIndex(u => u.Id == Channel.Id) > -1)
            {
                Global.Settingshandler.Settings.BlackListChannels.Remove(Global.Settingshandler.Settings.BlackListChannels.Find(u => u.Id == Channel.Id));
                await LogHandler.Log("[PERMHANLDER] Blacklisted channel has been Removed: " + Channel.Id);
                Global.Settingshandler.SaveSettings();
                await Global.Settingshandler.RefreshSettings();
            }
            else
            {
                throw new Exception("This Channel is not in the BlackList!");
            }
        }
        //Admin stuff
        public async static void AddAdmin(string Username, ulong UserID, string Addedby)
        {
            if (Global.Settingshandler.Settings.Admins.FindIndex(u => u.Id == UserID) == -1)
            {
                Global.Settingshandler.Settings.Admins.Add(new AdminUser(Username, UserID, Addedby));
                await LogHandler.Log("[PERMHANLDER] An admin has been added: " + Username);
                Global.Settingshandler.SaveSettings();
                await Global.Settingshandler.RefreshSettings();
            }
            else
            {
                throw new Exception("This User is already my Admin!");
            }
        }
        public static bool IsAdmin(ulong UserID)
        {
            return (Global.Settingshandler.Settings.Admins.FindIndex(u => u.Id == UserID) > -1);
        }
        public async static void RemoveAdmin(ulong UserID)
        {
            if (Global.Settingshandler.Settings.Admins.FindIndex(u => u.Id == UserID) == -1)
            {
                AdminUser OldAdmin = Global.Settingshandler.Settings.Admins.Find(u => u.Id == UserID);
                await LogHandler.Log("[PERMHANLDER] An admin has been Removed: " + OldAdmin.Username);
                Global.Settingshandler.Settings.Admins.Remove(Global.Settingshandler.Settings.Admins.Find(u => u.Id == UserID));
                Global.Settingshandler.SaveSettings();
                await Global.Settingshandler.RefreshSettings();
            }
            else
            {
                throw new Exception("This user is not my Admin!");
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
