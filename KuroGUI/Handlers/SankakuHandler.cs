using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KuroGUI.Handlers
{
    /// <summary>
    /// Most of this class is from
    /// https://github.com/ExModify/Chino-chan/blob/master/Chino-chan/Image/Sankaku.cs
    /// </summary>
    public class SankakuHandler
    {
        string Username { get; set; }
        public string Password { get; set; }

        string ActualUsername { get; set; }
        string PasswordHash { get; set; }

        string Cfduid { get; set; }
        string SankakuSessionId { get; set; }
        
        public bool LoggedIn { get; private set; }

        string Endpoint
        {
            get
            {
                return "https://chan.sankakucomplex.com/";
            }
        }
        string AuthUrl
        {
            get
            {
                return Endpoint + "user/authenticate";
            }
        }

        public SankakuHandler(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        private string[] BadExt = new string[]{
            ".mp4",
            ".webm",
            ".wmv"
        };
        public bool Login()
        {
            PasswordHash = null;
            Cfduid = null;
            SankakuSessionId = null;
            ActualUsername = null;
            try
            {
                HttpWebRequest CookieReq = (HttpWebRequest)WebRequest.Create("https://chan.sankakucomplex.com/");
                CookieReq.Method = "GET";
                CookieReq.Headers.Add("Upgrade-Insecure-Requests: 1");
                CookieReq.Headers.Add("Accept-Encoding: gzip, deflate, sdch, br");
                CookieReq.Headers.Add("Accept-Language: en-US,en;q=0.8,sl;q=0.6");
                CookieReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
                CookieReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                CookieReq.Timeout = 18 * 1000;

                HttpWebResponse CookieResponse = (HttpWebResponse)CookieReq.GetResponse();
                string CookieValueValue = CookieResponse.GetResponseHeader("Set-Cookie");
                CookieResponse.Close();
                Cfduid = new Regex(@"__cfduid=(.*?);").Match(CookieValueValue).Groups[1].Value;

                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://chan.sankakucomplex.com/user/authenticate");
                Request.Method = "POST";
                Request.AllowAutoRedirect = false;
                Request.Headers.Add("Origin", "https://chan.sankakucomplex.com");
                Request.Headers.Add("Cache-Control", "max-age=0");
                Request.Headers.Add("Upgrade-Insecure-Requests", "1");
                Request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                Request.Headers.Add("Accept-Language", "en-US,en;q=0.8,sl;q=0.6");
                Request.Host = "chan.sankakucomplex.com";
                Request.Referer = "https://chan.sankakucomplex.com/user/login";
                Request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
                Request.ContentType = "application/x-www-form-urlencoded";
                Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                Request.Headers.Add("Cookie", $"__cfduid={Cfduid}; auto_page=1; blacklisted_tags=; locale=en");
                string Content = $"url=&user%5Bname%5D={Username}&user%5Bpassword%5D={Password}&commit=Login";

                byte[] ContentBytes = Encoding.ASCII.GetBytes(Content);
                Request.ContentLength = ContentBytes.Length;
                Stream RequestStream = Request.GetRequestStream();
                RequestStream.Write(ContentBytes, 0, ContentBytes.Length);
                RequestStream.Close();
                Request.Timeout = 18 * 1000;

                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                string Value = Response.GetResponseHeader("Set-Cookie");
                Response.Close();

                PasswordHash = new Regex(@"pass_hash=(.*?);").Match(Value).Groups[1].Value;
                ActualUsername = new Regex(@"login=(.*?);").Match(Value).Groups[1].Value;
                SankakuSessionId = new Regex(@"_sankakucomplex_session=(.*?);").Match(Value).Groups[1].Value;

                if (PasswordHash.Length < 2)
                {
                    LoggedIn = false; return LoggedIn;
                }
                LoggedIn = true;
                return LoggedIn;
            }
            catch (WebException Exception)
            {
                ControlHandler.LogAsync("[SANKAKU] " + Exception.Message);
                LoggedIn = false;
                return LoggedIn;
            }
            catch
            {
                LoggedIn = false;
                return LoggedIn;
            }
        }
        public List<SankakuPost> SearchSankaku(string Tags)
        {
            try
            {
                Tags = Tags.Replace(" ", "+");
                if (!Tags.Contains("order:"))
                {
                    Tags += "+order:random";
                }
                if (Tags.ToLower().Contains("page:"))
                {
                    Regex o = new Regex("(?<=page:)(\\S.*?((?=\\+)|(?=$|\\W)))", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    string numstring = o.Match(Tags).Groups[1].Value;
                    Tags = Tags.Replace(string.Join("", Tags.ToLower().StartsWith("page:") ? "" : "+", "page:", numstring), "");
                    if (uint.TryParse(numstring, NumberStyles.Integer, CultureInfo.CurrentCulture.NumberFormat, out uint pnum))
                    {
                        Tags += "&page=" + pnum;
                    }
                    else
                    {
                        Tags += "&page=1";
                    }
                }
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create($"https://chan.sankakucomplex.com/post/index.content?&tags={Tags}");
                Request.Method = "GET";
                Request.Referer = $"https://chan.sankakucomplex.com/?tags={Tags}&commit=Search";
                Request.Host = "chan.sankakucomplex.com";
                Request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
                Request.Accept = "text/html, */*";
                Request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                Request.Headers.Add("Accept-Language", "en-GB,en;q=0.8,sl;q=0.6");
                Request.Headers.Add("Cookie", $"__cfduid={Cfduid}; login={Username}; pass_hash={PasswordHash}; " +
                    $"__atuvc=24%7C43; __atuvs=580cc97684a60c23003; mode=view; auto_page=1; " +
                    $"blacklisted_tags=full-package_futanari&futanari&video&webm&mp4; locale=en; _sankakucomplex_session={SankakuSessionId}");
                Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                string Content = Encoding.UTF8.GetString(ReadStream(Response.GetResponseStream()));
                Response.Close();
                Response.Dispose();
                return GetPosts(Content.Split('\n'));
            }
            catch (Exception Exception)
            {
                throw Exception;
            }
        }

        public Image GetImage(SankakuPost Post)
        {
            string PostID = Post.PostID;
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://chan.sankakucomplex.com/post/show/" + PostID);
            Request.Method = "GET";
            Request.Host = "chan.sankakucomplex.com";
            Request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
            Request.Accept = "text/html, */*";
            Request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            Request.Headers.Add("Accept-Language", "en-GB,en;q=0.8,sl;q=0.6");
            Request.Headers.Add("Cookie", $"__cfduid={Cfduid}; login={Username}; pass_hash={PasswordHash}; " +
                $"__atuvc=24%7C43; __atuvs=580cc97684a60c23003; mode=view; auto_page=1; " +
                $"blacklisted_tags=full-package_futanari&futanari&video&webm&mp4; locale=en; _sankakucomplex_session={SankakuSessionId}");
            Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            string ImgURL = "";
            string ConString = Encoding.UTF8.GetString(ReadStream(Response.GetResponseStream()));
            foreach (string line in ConString.Split('\n'))
            {
                if (line.IndexOf("<li>Original:") > -1)
                {
                    ImgURL = line.Substring(line.IndexOf("\"") + 3, line.IndexOf("\"", line.IndexOf("\"") + 1) - (line.IndexOf("\"") + 3));
                }
            }
            Response.Dispose();
            if (!this.BadExt.Any(s => ImgURL.Contains(s)))
            {
                HttpWebRequest ImgRequest = (HttpWebRequest)WebRequest.Create("http://" + ImgURL);

                Regex r = new Regex(@"cs\.sankakucomplex\.com/data/(.*?)/(.*?)/(.*?)\?", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                Post.ImageFileName = r.Match(ImgURL).Groups[3].Value;
                ImgRequest.Method = "GET";
                ImgRequest.Host = "cs.sankakucomplex.com";
                ImgRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
                ImgRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                ImgRequest.Headers.Add("Accept-Language", "en-GB,en;q=0.8,sl;q=0.6");
                ImgRequest.Headers.Add("Upgrade-Insecure-Requests", "1");

                WebResponse ImgResponse = ImgRequest.GetResponse();
                Stream ImgStream = ImgResponse.GetResponseStream();
                try
                {
                    byte[] Buffer = new byte[4 * 1024];
                    using (MemoryStream Memory = new MemoryStream())
                    {
                        int Count = 0;
                        while ((Count = ImgStream.Read(Buffer, 0, Buffer.Length)) != 0)
                        {
                            Memory.Write(Buffer, 0, Count);
                        }
                        Image Img = Image.FromStream(Memory);
                        ImgStream.Dispose();
                        return Img;
                    }
                }
                catch (Exception arg)
                {
                    throw arg;
                }
            }
            else
            {
                throw new Exception("The requested image has an unsupported extension.");
            }
        }
        private byte[] ReadStream(Stream Stream)
        {
            using (MemoryStream MemoryStream = new MemoryStream())
            {
                Stream.CopyTo(MemoryStream);
                Stream.Flush();
                Stream.Dispose();
                return MemoryStream.ToArray();
            }
        }
        private List<SankakuPost> GetPosts(string[] html)
        {
            List<SankakuPost> templist = new List<SankakuPost>();
            bool f = false;
            foreach (string line in html)
            {
                if (line.IndexOf("<span class=\"thumb blacklisted\"") > -1)
                {
                    if (!f)
                    {
                        f = true;
                        continue;
                    }
                    else
                    {
                        string link = line.Substring(line.IndexOf("<a href=\"/post/show/") + 20, line.IndexOf("\"", line.IndexOf("<a href=\"/post/show/")) - (line.IndexOf("<a href=\"/post/show/") + 1));
                        string previewlink = line.Substring(line.IndexOf("src=\"//") + 7, line.IndexOf(".jpg", line.IndexOf("src=\"//")) - (line.IndexOf("src=\"//") + 3));
                        string tags = line.Substring(line.IndexOf("title=\"") + 7, line.IndexOf("\" alt=\"\"", line.IndexOf("title=\"")) - (line.IndexOf("title=\"") + 8));
                        templist.Add(new SankakuPost(tags.Split(' '), link, previewlink));
                    }
                }
            }
            return templist;
        }
    }
    public class SankakuPost
    {
        public string[] Tags { get; private set; }
        public string PostID { get; private set; }
        public string PreviewPicLink { get; private set; }
        public string ImageFileName { get; set; }

        public SankakuPost(string[] _Tags, string _PostID, string _PreviewPicLink)
        {
            Tags = _Tags;
            PostID = _PostID.Replace("\"", "");
            PreviewPicLink = _PreviewPicLink;
        }
    }
}
