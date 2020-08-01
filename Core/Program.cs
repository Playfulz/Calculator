using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Calculator.Core {
    
    class Program : ModuleBase<SocketCommandContext> {

        public static DiscordSocketClient _client;
        CommandService _commands;
        public static List<ulong> admins = new List<ulong>();
        Random rand = new Random();
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        async Task MainAsync() {
            admins.Add(620704612185407507);
            admins.Add(347015092854063115);
            admins.Add(283706696377827329);
            admins.Add(147422106215383040);
            var json = File.ReadAllText("config.json");
            var token = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);

            _client = new DiscordSocketClient(new DiscordSocketConfig {
                LogLevel = LogSeverity.Debug
            });

            _commands = new CommandService(new CommandServiceConfig {
                CaseSensitiveCommands = false,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            string strCmdText;
            strCmdText= "/C node index.js";
            System.Diagnostics.Process.Start("CMD.exe",strCmdText);
            
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);

            _client.MessageReceived += ClientMessageReceived;
            _client.Ready += ClientReady;
            _client.Log += ClientLog;
            
            await _client.LoginAsync(TokenType.Bot, token["TOKEN"]);
            await _client.StartAsync();
            await Task.Delay(-1);
        }
        async Task ClientLog(LogMessage pessage) {
            Console.WriteLine($"{DateTime.Now} at {pessage.Source}] {pessage.Message}");
        }

        async Task ClientReady() {
            await _client.SetGameAsync("the code! Click to watch!", "https://www.youtube.com/watch?v=dQw4w9WgXcQ", ActivityType.Streaming);
            await _client.SetStatusAsync(UserStatus.Online);
        }

        async Task ClientMessageReceived(SocketMessage message) {
            var Message = message as SocketUserMessage;
            var content = Message.Content;
            var Context = new SocketCommandContext(_client, Message);
            if (Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.IsBot) return;
            int argPos = 0;
            
            if (!Message.HasStringPrefix("-", ref argPos) && !Message.HasMentionPrefix(_client.CurrentUser, ref argPos)) {
                return;
            }

            var Result = await _commands.ExecuteAsync(Context, argPos, null);

            if (!Result.IsSuccess) {
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing a command. Text: {Context.Message.Content} | Error: {Result.ErrorReason}");
            }
        }


    }
}
