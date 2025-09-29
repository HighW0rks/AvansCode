using System;
using System.Reflection;
using Discord;
using Discord.WebSocket;

public static class DiscordBot
{
    private static DiscordSocketClient client;
    private static Func<string, string, string> callback = null!;

    static DiscordBot()
    {
        var config = new DiscordSocketConfig
        {
            GatewayIntents =
            GatewayIntents.Guilds
            | GatewayIntents.GuildMessages
            | GatewayIntents.MessageContent
        };
        client = new DiscordSocketClient(config);
    }
    public static void Start(string token, Func<string, string, string> callback)
    {
        DiscordBot.callback = callback;
        if (string.IsNullOrEmpty(token))
            RunConsole();
        else
            Run(token).GetAwaiter().GetResult();
    }

    private static void RunConsole()
    {
        Console.WriteLine("Je hebt geen discord bot verbonden. Je kunt hier nu typen om een discord chat te simuleren");
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                continue;
            }

            string reply = callback.Invoke("Console", input)!;
            if (!string.IsNullOrEmpty(reply))
            {
                Console.WriteLine(reply);
            }
        }
    }

    private static async Task Run(string token)
    {
        await client.LoginAsync(Discord.TokenType.Bot, token);
        client.MessageReceived += MessageReceived;
        client.Log += Log;
        await client.StartAsync();

        await Task.Delay(-1);
    }

    private static Task Log(LogMessage message)
    {
        Console.WriteLine($"[{message.Severity}] {message.Source} -> {message.Message} {message.Exception?.Message}");
        return Task.CompletedTask;
    }

    private static async Task MessageReceived(SocketMessage message)
    {
        if (message.Author.IsBot)
            return;
        try
        {
            string reply = callback.Invoke(message.Author.Username, message.Content ?? string.Empty)!;
            if (!string.IsNullOrEmpty(reply))
            {
                await message.Channel.SendMessageAsync(reply);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
