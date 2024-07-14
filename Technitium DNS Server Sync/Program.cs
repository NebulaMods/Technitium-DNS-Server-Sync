﻿using System.Diagnostics;
using System.Text.Json;

using TechnitiumSync.Models;

namespace TechnitiumSync;

internal class Program
{
    private static bool _isRunning = true;

    private static void Main(string[] args)
    {
        Console.WriteLine("Technitium DNS Server Sync is beginning to start...");

        // Check if the user has passed any arguments
        if (args.Length > 0)
        {
            CommandHandler(args[0]);
            Thread.Sleep(Timeout.Infinite);
            return;
        }

        while (_isRunning)
        {
            CommandHandler(Console.ReadLine());
        }
    }

    private static Task BackgroundService()
    {
        _ = Task.Run(DoWorkAsync);
        return Task.CompletedTask;
    }

    private static async Task DoWorkAsync()
    {
        using var httpClient = new HttpClient();

        while (true)
        {
            // Read configuration file
            var config = await ReadConfigurationAsync();
            if (config != null)
            {
                // Login to the server
                var loginResponse = await Requests.LoginAsync(httpClient, config.Username, config.Password, config.MainServerUrl, config.IncludeInfo);
                if (loginResponse != null)
                {
                    Console.WriteLine("Logged in successfully.");
                    Console.WriteLine("Beginning to sync data...");

                    var backupSuccess = await Requests.GetBackupAsync(httpClient, config, loginResponse.Token);

                    if (!backupSuccess)
                    {
                        Console.WriteLine("Failed to sync data.");
                        Console.WriteLine("Waiting for next sync...");
                        await Task.Delay(config.SyncInterval * 1000);
                        continue;
                    }

                    var runningPath = Path.GetDirectoryName(Environment.ProcessPath);
                    if (string.IsNullOrWhiteSpace(runningPath))
                    {
                        Console.WriteLine("Failed to get the running path.");
                        continue;
                    }

                    var backupPath = Path.Combine(runningPath, "backup.zip");

                    foreach (var url in config.BackupServerUrls)
                    {
                        using var backupHttpClient = new HttpClient();

                        var backupServerLoginResponse = await Requests.LoginAsync(backupHttpClient, config.Username, config.Password, url, config.IncludeInfo);

                        if (backupServerLoginResponse == null || backupServerLoginResponse.Status == "error")
                        {
                            Console.WriteLine("Failed to login to backup server.");
                            File.Delete(backupPath);
                            continue;
                        }

                        var syncBackup = await Requests.SyncBackupAsync(httpClient, config, backupServerLoginResponse.Token, url);

                        if (syncBackup == null || syncBackup.Status == "error")
                        {
                            Console.WriteLine("Failed to sync data to backup server.");
                            File.Delete(backupPath);
                            continue;
                        }
                    }

                    // Delete the backup file
                    File.Delete(backupPath);

                    Console.WriteLine("Data synced successfully.");
                    Console.WriteLine("Waiting for next sync...");
                    await Task.Delay(config.SyncInterval * 1000);
                }
            }
        }
    }

    private static async Task<Configuration> ReadConfigurationAsync()
    {
        var runningPath = Path.GetDirectoryName(Environment.ProcessPath);

        if (string.IsNullOrWhiteSpace(runningPath))
        {
            Console.WriteLine("Failed to get the running path.");
            Process.GetCurrentProcess().Kill();
            return new Configuration();
        }

        var configPath = Path.Combine(runningPath, "config.json");

        if (!File.Exists(configPath))
        {
            var newConfig = new Configuration
            {
                Username = "admin",
                Password = "admin",
                IncludeInfo = true,
                MainServerUrl = "https://technitium.com/",
                BackupServerUrls = new[] { "https://technitium.com/" },
                SyncInterval = 60,
                Logs = false,
                Scopes = false,
                Apps = false,
                Stats = false,
                Zones = true,
                AllowedZones = true,
                BlockedZones = true,
                DnsSettings = true,
                AuthConfig = true,
                LogSettings = true,
                BlockLists = false,
                DeleteExistingFiles = false,
            };

            var newConfigJson = JsonSerializer.Serialize(newConfig);
            await File.WriteAllTextAsync(configPath, newConfigJson);
            Console.WriteLine("Configuration file created. Please edit the configuration file and restart the application.");
            Console.WriteLine("Exiting application...");
            Process.GetCurrentProcess().Kill();
            return newConfig;
        }

        var config = await File.ReadAllTextAsync(configPath);

        var configJson = JsonSerializer.Deserialize<Configuration>(config);

        return configJson ?? new Configuration();
    }

    private static void CommandHandler(string? command)
    {
        switch (command)
        {
            case "start":
                BackgroundService();
                break;

            case "exit":
                _isRunning = false;
                break;

            case "help":
                Console.WriteLine("Commands:");
                Console.WriteLine("start - Start the service");
                Console.WriteLine("exit - Exit the service");
                Console.WriteLine("help - Show this help message");
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}