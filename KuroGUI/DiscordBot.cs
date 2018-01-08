using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KuroGUI.Handlers;

namespace KuroGUI
{
    public class DiscordBot
    {
        public CommandService Commands;
        public DiscordSocketClient Client;
        public IServiceProvider Services;
        public string Token { get; private set; }

        public DiscordBot() { }
        public async Task ConnectAsync(string _Token)
        {
            await ControlHandler.LogAsync("Connecting...");

            this.Token = _Token;

            DiscordSocketConfig _config = new DiscordSocketConfig
            {
                MessageCacheSize = 128,
            };
            Client = new DiscordSocketClient(_config);
            Commands = new CommandService(new CommandServiceConfig()
                {
                    DefaultRunMode = RunMode.Async
                });


            Services = new ServiceCollection()
            .AddSingleton(Client)
            .AddSingleton(Commands)
            .BuildServiceProvider();

            await InstallCommandsAsync();
            Client.UserJoined += Global.GuildEventHandler.GreetNewUser;
            Client.ChannelCreated += Global.GuildEventHandler.ChannelUpdate;
            Client.ChannelDestroyed += Global.GuildEventHandler.ChannelUpdate;
            Client.ChannelUpdated += Global.GuildEventHandler.ChannelModified;
            Client.Ready += Global.GuildEventHandler.ClientReady;
            Client.MessageReceived += Global.GuildEventHandler.MessageReceived;
            Client.Log += Global.GuildEventHandler.Log;
            Client.GuildUpdated += Global.GuildEventHandler.GuildModifed;
            Client.JoinedGuild += Global.GuildEventHandler.GuildJoinLeave;
            Client.LeftGuild += Global.GuildEventHandler.GuildJoinLeave;
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();

        }
        public async void Disconnect()
        {
            try
            {
                Global.SettingsHandler.SaveSettings();
                await Client.StopAsync();
                await ControlHandler.LogAsync("[DISCONNECTED] Disconnected from Discord!");
            }
            catch { }
        }

        public async Task InstallCommandsAsync()
        {
            Client.MessageReceived += HandleCommandAsync;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }
        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            SocketUserMessage message = messageParam as SocketUserMessage;
            if (message == null || (PermHandler.BlackListed(message.Channel as SocketTextChannel) && !PermHandler.IsAdmin(message.Author.Id))) return;
            int argPos = 0;
            if (!message.HasCharPrefix('-', ref argPos)) return;
            SocketCommandContext context = new SocketCommandContext(Client, message);
            IResult result = await Commands.ExecuteAsync(context, argPos, Services);
            if (!result.IsSuccess)
            {
                switch (result.Error)
                {
                    case CommandError.UnknownCommand:
                        await context.Channel.SendMessageAsync("Unknown command. Try `-help` for list of commands!");
                        break;
                    case CommandError.BadArgCount:
                        await context.Channel.SendMessageAsync("Wrong input! Please try something else.");
                        break;
                    case CommandError.UnmetPrecondition:
                        await context.Channel.SendMessageAsync("You can not use this command!");
                        break;
                    default:
                        if (PermHandler.IsAdmin(context.Message.Author.Id))
                        {
                            await context.Message.Author.SendMessageAsync(result.ErrorReason);
                            await context.Channel.SendMessageAsync("Something went wrong! Please tell an admin! :(");
                        }
                        else
                        {
                            await context.Channel.SendMessageAsync("Something went wrong! Please tell an admin! :(");
                        }
                        break;
                }
            }
        }
    }
    public class LastPicture
    {
        public ulong LastPicChannelID { get; set; }
        public ulong LastPicID { get; set; }

        public LastPicture(ulong _lastchid, ulong _lastpicid)
        {
            this.LastPicChannelID = _lastchid;
            this.LastPicID = _lastpicid;
        }
    }
    public class GreetMessage
    {
        public ulong GuildID { get; set; }
        public ulong ChannelID { get; set; }
        public string GuildName { get; set; }
        public string ChannelName { get; set; }
        public string Message { get; set; }

        public GreetMessage(ulong _GuildID, ulong _ChannelID, string _Message, string _GuildName, string _ChannelName)
        {
            this.GuildID = _GuildID;
            this.ChannelID = _ChannelID;
            this.Message = _Message;
            this.GuildName = _GuildName;
            this.ChannelName = _ChannelName;
        }
    }
}
