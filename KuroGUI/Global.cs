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

        public static SankakuHandler SankakuClient = new SankakuHandler("aleho8", "hardcoded password LUL");
        public static SettingsHandler SettingsHandler = new SettingsHandler("Settings.json");
        public static List<LastPicture> LastPictures = new List<LastPicture>();
        public static List<string> PicturesSFW = new List<string>();
        public static List<string> PicturesNSFW = new List<string>();
        public static string osuKey;
        public static HttpClient httpclient = new HttpClient();

        public async static Task Start()
        {
            try
            {
                SankakuClient.Password = File.ReadAllText("../sankakupw.txt").Trim();
            }
            catch { }
            await SettingsHandler.RefreshSettings();
            if (!SankakuClient.Login())
            {
                await LogHandler.Log("[SANKAKU] Could not log in to Sankaku! Picture search will not work!");
            }
            else
            {
                await LogHandler.Log("[SANKAKU] Logged in to Sankaku!");
            }
            httpclient.DefaultRequestHeaders.Accept.Clear();
            httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                string[] TempSFW = Directory.GetFiles("E:/Pictures/RandomSFW/").Concat(Directory.GetFiles("E:/Pictures/Illya&Kuro/")).ToArray();
                string[] TempNSFW = Directory.GetFiles("E:/Pictures/RandomNSFW/").Concat(Directory.GetFiles("E:/Pictures/NSFW/")).ToArray();
                foreach (string sfwpic in TempSFW)
                {
                    PicturesSFW.Add(sfwpic);
                }
                foreach (string nsfwpic in TempNSFW)
                {
                    PicturesNSFW.Add(nsfwpic);
                }
                await LogHandler.Log(string.Format("[PICTURES] Found {0} SFW and {1} NSFW pictures!", PicturesSFW.Count, PicturesNSFW.Count));
            }
            catch(Exception e)
            {
                await LogHandler.Log("[PICTURES] Could not get saved pictures! Some picture commands might not work! " + e.Message);
            }
            try
            {
                osuKey = File.ReadAllText("../osuapi.txt");
                await LogHandler.Log("[OSUAPI] Got API key!");
            }
            catch(Exception ex)
            {
                await LogHandler.Log("[OSUAPI] Could not get API key! Osu! commands will not work! " + ex.Message);
            }
        }


    }
}
