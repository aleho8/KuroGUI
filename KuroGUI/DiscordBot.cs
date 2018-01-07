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
            await LogHandler.Log("Connecting...");

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

            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();

        }
        public async void DisconnectAsync()
        {
            await Client.StopAsync();
            await LogHandler.Log("[DISCONNECTED] Disconnected from Discord!");
            Global.PermHandler.SaveBlackList();
        }

        public async Task InstallCommandsAsync()
        {
            Client.MessageReceived += HandleCommandAsync;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }
        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            SocketUserMessage message = messageParam as SocketUserMessage;
            if (message == null || Global.PermHandler.BlackListed(message.Channel.Id)) return;
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
                    default:
                        if (context.Message.Author.Id == 135529017833947136)
                        {
                            await context.Message.Author.SendMessageAsync(result.ErrorReason);
                            await context.Channel.SendMessageAsync("Uknown error! Please tell aleho8! :(");
                        }
                        else
                        {
                            await context.Channel.SendMessageAsync("Uknown error! Please tell aleho8! :(");
                        }
                        break;
                }
            }
        }
    }
    public class LastPicture
    {
        public ulong LastPicChannelID;
        public ulong LastPicID;

        public LastPicture(ulong _lastchid, ulong _lastpicid)
        {
            this.LastPicChannelID = _lastchid;
            this.LastPicID = _lastpicid;
        }
    }
}
