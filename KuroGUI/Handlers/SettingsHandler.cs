using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace KuroGUI.Handlers
{
    public class SettingsHandler
    {
        public Setting Settings = new Setting("owo >.>", Discord.UserStatus.Online, "", 0, new List<AdminUser>(), new List<BlackListedChannel>(), new List<GreetMessage>(), new List<string>(), new List<string>(), "", "", "");
        public SettingsHandler(string SettingsFile)
        {
            if (File.Exists(SettingsFile))
            {
                try
                {
                    Settings = JsonConvert.DeserializeObject<Setting>(File.ReadAllText(SettingsFile));
                    ControlHandler.LogAsync("[SETTINGSHANDLER] Read Settings File!");
                }
                catch {
                    ControlHandler.LogAsync("[SETTINGSHANDLER] Couldn't read Settings file! Using Default settings. Don't forget to set your ID as OwnerID in [SETTINGS]!");
                }
            }
            else
            {
                ControlHandler.LogAsync("[SETTINGSHANDLER] Couldn't read Settings file! Using Default settings. Don't forget to set your ID as OwnerID in [SETTINGS]!");
            }
        }
        public async Task RefreshGuildChangesAsync()
        {
            foreach(BlackListedChannel blc in this.Settings.BlackListChannels)
            {
                SocketGuildChannel channel = Global.Kuro.Client.GetChannel(blc.Id) as SocketGuildChannel;
                if (channel != null)
                {
                    if (blc.Channel != channel.Name)
                    {
                        blc.Channel = channel.Name;
                    }
                    if (blc.Guild != channel.Guild.Name)
                    {
                        blc.Guild = channel.Guild.Name;
                    }
                }
                else
                {
                    this.Settings.BlackListChannels.Remove(blc);
                }
            }
            foreach (AdminUser admin in this.Settings.Admins)
            {
                SocketUser user = Global.Kuro.Client.GetUser(admin.Id);
                if (user.Username != admin.Username)
                {
                    admin.Username = user.Username;
                }
            }
            foreach(GreetMessage msg in this.Settings.GreetMessages)
            {
                SocketGuildChannel channel = Global.Kuro.Client.GetChannel(msg.ChannelID) as SocketGuildChannel;
                if (channel != null)
                {
                    if (channel.Name != msg.ChannelName)
                    {
                        msg.ChannelName = channel.Name;
                    }
                    if (channel.Guild.Name != msg.GuildName)
                    {
                        msg.GuildName = channel.Guild.Name;
                    }
                }
                else
                {
                    this.Settings.GreetMessages.Remove(msg);
                }
            }
            this.SaveSettings();
            await ControlHandler.ShowSettingsValueAsync();
        }
        public async void ReadPictures()
        {
            Global.PicturesSFW.Clear();
            Global.PicturesNSFW.Clear();
            try
            {
                foreach (string sfwfolder in this.Settings.SFWFolders)
                {
                    Global.PicturesSFW.AddRange(Directory.GetFiles(sfwfolder).ToList<string>().FindAll(path => path.EndsWith(".jpg") || path.EndsWith(".png") || path.EndsWith(".gif") || path.EndsWith(".webm")));
                }
                foreach (string nsfwfolder in this.Settings.NSFWFolders)
                {
                    Global.PicturesNSFW.AddRange(Directory.GetFiles(nsfwfolder).ToList<string>().FindAll(path => path.EndsWith(".jpg") || path.EndsWith(".png") || path.EndsWith(".gif") || path.EndsWith(".webm")));
                }
                await ControlHandler.LogAsync(string.Format("[PICTURES] Found {0} SFW and {1} NSFW pictures!", Global.PicturesSFW.Count, Global.PicturesNSFW.Count));
            }
            catch (Exception e)
            {
                await ControlHandler.LogAsync("[PICTURES] Could not get pictures from this folder: " + e.Message);
            }
        }
        //Saves lists...
        public async void SaveSettings()
        {
            try
            {
                File.WriteAllText("Settings.json", JsonConvert.SerializeObject(this.Settings));
                await ControlHandler.LogAsync("[SETTINGSHANDLER] Saved Settings File!");
            }
            catch(Exception ecc) {
                Console.WriteLine(ecc.Message);
            }
        }
    }
    public class Setting
    {
        public string Game { get; set; }
        public Discord.UserStatus GameStatus { get; set; }
        public string SavedToken { get; set; }
        public ulong OwnerID { get; set; }
        public List<AdminUser> Admins { get; set; }
        public List<BlackListedChannel> BlackListChannels { get; set; }
        public List<GreetMessage> GreetMessages { get; set; }
        public List<string> SFWFolders { get; set; }
        public List<string> NSFWFolders { get; set; }
        public string SankakuUserName { get; set; }
        public string SankakuPassword { get; set; }
        public string osuAPIKey { get; set; }

        public Setting(string _Game, Discord.UserStatus _GameStatus, string _SavedToken, ulong _OwnerID, List<AdminUser> _Admins, List<BlackListedChannel> _BlackListChannels, List<GreetMessage> _GreetMessages, List<string> _SFWFolders, List<string> _NSFWFolders, string _SankakuPW, string _SankakuUN, string _osuAPIKey)
        {
            this.Game = _Game;
            this.GameStatus = _GameStatus;
            this.SavedToken = _SavedToken;
            this.OwnerID = _OwnerID;
            this.Admins = _Admins;
            this.BlackListChannels = _BlackListChannels;
            this.GreetMessages = _GreetMessages;
            this.SFWFolders = _SFWFolders;
            this.NSFWFolders = _NSFWFolders;
            this.SankakuUserName = _SankakuUN;
            this.SankakuPassword = _SankakuPW;
            this.osuAPIKey = _osuAPIKey;
        }
    }
}
