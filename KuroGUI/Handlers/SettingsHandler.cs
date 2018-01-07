using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

using KuroGUI.Handlers;

namespace KuroGUI.Handlers
{
    public class SettingsHandler
    {
        public Setting Settings = new Setting("owo >.>", Discord.UserStatus.Online, "", new List<AdminUser>(), new List<BlackListedChannel>());
        public SettingsHandler(string SettingsFile)
        {
            if (File.Exists(SettingsFile))
            {
                try
                {
                    Settings = JsonConvert.DeserializeObject<Setting>(File.ReadAllText(SettingsFile));
                    LogHandler.Log("[SETTINGSHANDLER] Read Settings File!");
                }
                catch {
                    LogHandler.Log("[SETTINGSHANDLER] Could not read Settings file! Using Default settings");
                }
            }
            else
            {
                LogHandler.Log("[SETTINGSHANDLER] Could not read Settings file! Using Default settings");
            }

        }
        public Task RefreshSettings()
        {
            Program.UserInterface.SettingsPage.Invoke(new Action(() =>
            {
                Program.UserInterface.AdminListView.Invoke(new Action(() =>
                {
                    Program.UserInterface.AdminListView.Items.Clear();
                    foreach (AdminUser admin in this.Settings.Admins)
                    {
                        Program.UserInterface.AdminListView.Items.Add(admin.Username);
                    }
                }));
                Program.UserInterface.BlackListView.Invoke(new Action(() =>
                {
                    Program.UserInterface.BlackListView.Items.Clear();
                    foreach (BlackListedChannel channel in this.Settings.BlackListChannels)
                    {
                        Program.UserInterface.BlackListView.Items.Add(new ListViewItem(new string[] { channel.Guild, channel.Channel, channel.Id.ToString() }));
                    }
                }));
                Program.UserInterface.SetGameTextBox.Invoke(new Action(() =>
                {
                    Program.UserInterface.SetGameTextBox.Text = this.Settings.Game;
                }));
            }));
            return Task.CompletedTask;
        }

        public Task RefreshChangedNames()
        {
            foreach(BlackListedChannel blc in this.Settings.BlackListChannels)
            {
                SocketGuildChannel channel = Global.Kuro.Client.GetChannel(blc.Id) as SocketGuildChannel;
                if (blc.Channel != channel.Name)
                {
                    blc.Channel = channel.Name;
                }
                if (blc.Guild != channel.Guild.Name)
                {
                    blc.Guild = channel.Guild.Name;
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
            RefreshSettings();
            return Task.CompletedTask;
        }

        //Saves lists...
        public async void SaveSettings()
        {
            try
            {
                File.WriteAllText("Settings.json", JsonConvert.SerializeObject(this.Settings));
                await LogHandler.Log("[SETTINGSHANDLER] Saved Settings File!");
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
        public List<AdminUser> Admins { get; set; }
        public List<BlackListedChannel> BlackListChannels { get; set; }

        public Setting(string _Game, Discord.UserStatus _GameStatus, string _SavedToken, List<AdminUser> _Admins, List<BlackListedChannel> _BlackListChannels)
        {
            this.Game = _Game;
            this.GameStatus = _GameStatus;
            this.SavedToken = _SavedToken;
            this.Admins = _Admins;
            this.BlackListChannels = _BlackListChannels;
        }
    }
}
