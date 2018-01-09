using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;

using KuroGUI.Handlers;

namespace KuroGUI
{
    public static class Global
    {
        public static DiscordBot Kuro = new DiscordBot();

        public static SankakuHandler SankakuClient = new SankakuHandler();
        public static GuildEventHandler GuildEventHandler = new GuildEventHandler();
        public static SettingsHandler SettingsHandler = new SettingsHandler("Settings.json");
        public static List<LastPicture> LastPictures = new List<LastPicture>();
        public static List<string> PicturesSFW = new List<string>();
        public static List<string> PicturesNSFW = new List<string>();
        public static string osuKey;

        public async static Task Start()
        {
            try
            {
                osuKey = File.ReadAllText("../osuapi.txt");
                await ControlHandler.LogAsync("[OSUAPI] Got API key!");
            }
            catch(Exception ex)
            {
                await ControlHandler.LogAsync("[OSUAPI] Could not get API key! Osu! commands will not work! " + ex.Message);
            }
            SettingsHandler.ReadPictures();
            if (!string.IsNullOrEmpty(Global.SettingsHandler.Settings.SankakuUserName) && !string.IsNullOrEmpty(Global.SettingsHandler.Settings.SankakuPassword))
            {
                Global.SankakuClient.Password = Global.SettingsHandler.Settings.SankakuPassword;
                Global.SankakuClient.Username = Global.SettingsHandler.Settings.SankakuUserName;
                if (!SankakuClient.Login())
                {
                    await ControlHandler.LogAsync("[SANKAKU] Could not log in to Sankaku! Picture search will not work!");
                }
                else
                {
                    await ControlHandler.LogAsync("[SANKAKU] Logged in to Sankaku!");
                    Program.UserInterface.SankakuLoginButton.Enabled = false;
                    Program.UserInterface.SankakuPasswordTextBox.Enabled = false;
                    Program.UserInterface.SankakuUserNameTextBox.Enabled = false;
                }
            }
        }


    }
}
