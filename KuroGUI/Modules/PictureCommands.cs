using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;
using Discord;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

using KuroGUI.Handlers;

namespace KuroGUI.Modules
{
    public class PictureModule : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService Service;
        public PictureModule(CommandService _service)
        {
            Service = _service;
        }

        [Command("picture"), Summary("Send a random picture. SFW/NSFW"), Alias("pic")]
        public async Task SendPictureAsync(string opt = "sfw")
        {
            switch (opt.ToLower())
            {
                case "sfw":
                    if (Global.PicturesSFW.Count > 0)
                    {
                        RestUserMessage userMessage = await Context.Channel.SendFileAsync(Global.PicturesSFW[new Random().Next(0, Global.PicturesSFW.Count - 1)]);
                        LastPicture GuildChNewPic = new LastPicture(Context.Channel.Id, userMessage.Id);
                        if (Global.LastPictures.FindIndex(z => z.LastPicChannelID == GuildChNewPic.LastPicChannelID) > -1)
                        {
                            Global.LastPictures[Global.LastPictures.FindIndex(z => z.LastPicChannelID == GuildChNewPic.LastPicChannelID)] = GuildChNewPic;
                        }
                        else
                        {
                            Global.LastPictures.Add(GuildChNewPic);
                        }
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("I don't have any SFW picture set!");
                    }
                    break;
                case "nsfw":
                    if (Context.Channel.IsNsfw)
                    {
                        if (Global.PicturesNSFW.Count > 0)
                        {
                            RestUserMessage userMessagensfw = await Context.Channel.SendFileAsync(Global.PicturesNSFW[new Random().Next(0, Global.PicturesNSFW.Count - 1)]);
                            LastPicture GuildChNewPicnsfw = new LastPicture(Context.Channel.Id, userMessagensfw.Id);
                            if (Global.LastPictures.FindIndex(z => z.LastPicChannelID == GuildChNewPicnsfw.LastPicChannelID) > -1)
                            {
                                Global.LastPictures[Global.LastPictures.FindIndex(z => z.LastPicChannelID == GuildChNewPicnsfw.LastPicChannelID)] = GuildChNewPicnsfw;
                            }
                            else
                            {
                                Global.LastPictures.Add(GuildChNewPicnsfw);
                            }
                        }
                        else
                        {
                            await Context.Channel.SendMessageAsync("I don't have any NSFW picture set!");
                        }
                        break;
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please go to an NSFW channel because I can't do that here");
                        break;
                    }
                default:
                    await Context.Channel.SendMessageAsync("Please use `sfw` or `nsfw`.");
                    break;
            }
        }
        [Command("dellast"), Summary("Deletes the last picture that bot has sent in that channel."), RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task DelLastPictureAsync()
        {
            int LastPicIndex = Global.LastPictures.FindIndex(x => x.LastPicChannelID == Context.Channel.Id);
            if (LastPicIndex > -1)
            {
                IMessage message = await Context.Channel.GetMessageAsync(Global.LastPictures[LastPicIndex].LastPicID);
                if (message != null)
                {

                    await message.DeleteAsync();
                    Global.LastPictures.Remove(Global.LastPictures[LastPicIndex]);
                }
                else
                {
                    await Context.Channel.SendMessageAsync("I could not find a picture! :<");
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("I could not find my last picture! Maybe it has been removed already.");
            }
        }
        [Command("sankaku", RunMode = RunMode.Async), Summary("Starts Sankaku search and sends a picture")]
        public async Task SankakuSearchAsync([Remainder]string tags)
        {
            try
            {
                if (Global.SankakuClient.LoggedIn)
                {
                    if (!Context.Channel.IsNsfw && (tags.IndexOf("rating:explicit") > -1 || tags.IndexOf("rating:questionable") > -1))
                    {
                        await Context.Channel.SendMessageAsync("Please go to an NSFW channel!");
                        return;
                    }
                    if (!Context.Channel.IsNsfw && tags.IndexOf("rating:safe") == -1)
                    {
                        tags += " rating:safe";
                    }
                    List<SankakuPost> TempPosts = Global.SankakuClient.SearchSankaku(tags.Trim());
                    SankakuPost TempPost = TempPosts[new Random().Next(TempPosts.Count - 1)];
                    using (System.Drawing.Bitmap TempImg = new System.Drawing.Bitmap(Global.SankakuClient.GetImage(TempPost)))
                    {
                        if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Images\")) Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"Images\");
                        Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + @"Images\" + TempPost.ImageFileName);
                        TempImg.Save(AppDomain.CurrentDomain.BaseDirectory + @"Images\" + TempPost.ImageFileName);
                        await Context.Channel.SendFileAsync(AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + TempPost.ImageFileName);
                    }
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync("Could not get an image!");
            }
        }
    }
}

