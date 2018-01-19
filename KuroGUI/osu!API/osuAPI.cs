using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace KuroGUI.osuAPI
{
    public class osuapi
    {
        private string APIKey { get; set; }
        public osuapi(string _APIKey)
        {
            this.APIKey = _APIKey;
        }
        /// <summary>
        /// Retrieve general user information.
        /// </summary>
        /// <param name="UserName">Username of the player.</param>
        /// <param name="GameMode">Specified GameMode. Standard by default.</param>
        /// <returns>Returns osuPlayer Object</returns>
        public async Task<osuPlayer> GetPlayer(string UserName, GameMode GameMode = GameMode.Standard)
        {
            try
            {
                WebRequest Request = WebRequest.Create($"https://osu.ppy.sh/api/get_user?k={this.APIKey}&u={UserName}&type=string&m={(int)GameMode}");
                Request.Method = "GET";
                using (WebResponse resp = await Request.GetResponseAsync())
                {
                    string responsestring = Encoding.Default.GetString(ReadStream(resp.GetResponseStream()));
                    osuPlayer player = JsonConvert.DeserializeObject<osuPlayer[]>(responsestring)[0];
                    return player;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Retrieve general user information.
        /// </summary>
        /// <param name="UserID">UserID of the player.</param>
        /// <param name="GameMode">Specified GameMode. Standard by default.</param>
        /// <returns>Returns osuPlayer Object</returns>
        public async Task<osuPlayer> GetPlayer(ulong UserID, GameMode GameMode = GameMode.Standard)
        {
            try
            {
                WebRequest Request = WebRequest.Create($"https://osu.ppy.sh/api/get_user?k={this.APIKey}&u={UserID}&type=id&m={(int)GameMode}");
                Request.Method = "GET";
                using (WebResponse resp = await Request.GetResponseAsync())
                {
                    string responsestring = Encoding.Default.GetString(ReadStream(resp.GetResponseStream()));
                    osuPlayer player = JsonConvert.DeserializeObject<osuPlayer[]>(responsestring)[0];
                    return player;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Gets the user's recent plays over the last 24 hours.
        /// </summary>
        /// <param name="UserName">UserName of the player</param>
        /// <param name="MaxValue">Max number of scores to get. Max is 50.</param>
        /// <param name="GameMode">Specified GameMode. Default is Standard</param>
        /// <returns>Returns an Array of osuPlayerRecent.</returns>
        public async Task<osuPlayerRecent[]> GetPlayerRecent(string UserName, int MaxValue = 10, GameMode GameMode = GameMode.Standard)
        {
            try
            {
                if (MaxValue > 50) MaxValue = 50;
                WebRequest Request = WebRequest.Create($"https://osu.ppy.sh/api/get_user_recent?k={this.APIKey}&u={UserName}&type=string&limit={MaxValue}&m={(int)GameMode}");
                Request.Method = "GET";
                using (WebResponse resp = await Request.GetResponseAsync())
                {
                    string responsestring = Encoding.Default.GetString(ReadStream(resp.GetResponseStream()));
                    osuPlayerRecent[] playerrecent = JsonConvert.DeserializeObject<osuPlayerRecent[]>(responsestring);
                    return playerrecent;
                }
            }
            catch(Exception ex)
            {
                throw ex;                
            }
        }
        /// <summary>
        /// Gets the user's recent plays over the last 24 hours.
        /// </summary>
        /// <param name="UserID">UserID of the player.</param>
        /// <param name="MaxValue">Max number of scores to get. Max is 50.</param>
        /// <param name="GameMode">Specified GameMode. Default is Standard.</param>
        /// <returns>Returns an Array of osuPlayerRecent.</returns>
        public async Task<osuPlayerRecent[]> GetPlayerRecent(ulong UserID, int MaxValue = 10, GameMode GameMode = GameMode.Standard)
        {
            try
            {
                if (MaxValue > 50) MaxValue = 50;
                WebRequest Request = WebRequest.Create($"https://osu.ppy.sh/api/get_user_recent?k={this.APIKey}&u={UserID}&type=id&limit={MaxValue}&m={(int)GameMode}");
                Request.Method = "GET";
                using (WebResponse resp = await Request.GetResponseAsync())
                {
                    string responsestring = Encoding.Default.GetString(ReadStream(resp.GetResponseStream()));
                    osuPlayerRecent[] playerRecent = JsonConvert.DeserializeObject<osuPlayerRecent[]>(responsestring);
                    return playerRecent;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the top scores for the specified user.
        /// </summary>
        /// <param name="UserID">Specify a UserID to return best scores from.</param>
        /// <param name="MaxValue">Amount of results (range between 1 and 100 - defaults to 10).</param>
        /// <param name="GameMode">GameMode to get results from.(Defaults to Standard.)</param>
        /// <returns>An array of osuPlayerBest</returns>
        public async Task<osuPlayerBest[]> GetPlayerBest(ulong UserID, int MaxValue = 10, GameMode GameMode = GameMode.Standard)
        {
            try
            {
                if (MaxValue > 100) MaxValue = 100;
                WebRequest Request = WebRequest.Create($"https://osu.ppy.sh/api/get_user_best?k={this.APIKey}&u={UserID}&type=id&limit={MaxValue}&m={(int)GameMode}");
                Request.Method = "GET";
                using (WebResponse resp = await Request.GetResponseAsync())
                {
                    string responsestring = Encoding.Default.GetString(ReadStream(resp.GetResponseStream()));
                    osuPlayerBest[] playerBest = JsonConvert.DeserializeObject<osuPlayerBest[]>(responsestring);
                    return playerBest;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get the top scores for the specified user.
        /// </summary>
        /// <param name="UserName">Specify a UserName to return best scores from.</param>
        /// <param name="MaxValue">Amount of results (range between 1 and 100 - defaults to 10).</param>
        /// <param name="GameMode">GameMode to get results from.(Defaults to Standard.)</param>
        /// <returns>An array of osuPlayerBest</returns>
        public async Task<osuPlayerBest[]> GetPlayerBest(string UserName, int MaxValue = 10, GameMode GameMode = GameMode.Standard)
        {
            try
            {
                if (MaxValue > 100) MaxValue = 100;
                WebRequest Request = WebRequest.Create($"https://osu.ppy.sh/api/get_user_best?k={this.APIKey}&u={UserName}&type=string&limit={MaxValue}&m={(int)GameMode}");
                Request.Method = "GET";
                using (WebResponse resp = await Request.GetResponseAsync())
                {
                    string responsestring = Encoding.Default.GetString(ReadStream(resp.GetResponseStream()));
                    osuPlayerBest[] playerBest = JsonConvert.DeserializeObject<osuPlayerBest[]>(responsestring);
                    return playerBest;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Retrieve general beatmap information.
        /// </summary>
        /// <param name="Link">URL of the beatmap or beatmapset.</param>
        /// <returns>An Array of 50 results.</returns>
        public async Task<osuBeatMapInfo[]> GetBeatMapInfo(string Link)
        {
            try
            {
                Regex r = new Regex(@"https://osu.ppy.sh/([sb]+?)/(\d*)");
                if (r.IsMatch(Link))
                {
                    string linktype = r.Match(Link).Groups[1].Value;
                    string linkID = r.Match(Link).Groups[2].Value;
                    WebRequest Request = WebRequest.Create($"https://osu.ppy.sh/api/get_beatmaps?k={this.APIKey}&{linktype}={linkID}&limit=50");
                    Request.Method = "GET";
                    using (WebResponse resp = await Request.GetResponseAsync())
                    {
                        string responsestring = Encoding.Default.GetString(ReadStream(resp.GetResponseStream()));
                        osuBeatMapInfo[] beatmapinfo = JsonConvert.DeserializeObject<osuBeatMapInfo[]>(responsestring);
                        return beatmapinfo;
                    }
                }
                else
                {
                    throw new Exception("This is not a beatmap URL!");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private byte[] ReadStream(Stream Stream)
        {
            using (MemoryStream memstream = new MemoryStream())
            {
                Stream.CopyTo(memstream);
                Stream.Flush();
                Stream.Dispose();
                return memstream.ToArray();
            }
        }

    }
}
