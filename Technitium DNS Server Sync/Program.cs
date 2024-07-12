using System.Diagnostics;
using System.Text.Json;

using TechnitiumSync.Models;

namespace TechnitiumSync;

internal class Program
{
    private static bool _isRunning = true;
    static void Main(string[] args)
    {
        Console.WriteLine("Technitium DNS Server Sync is beginning to start...");

        // Check if the user has passed any arguments
        if (args.Length > 0)
        {
            switch (args[0])
            {
                case "start":
                    BackgroundService();
                    break;
                case "exit":
                    _isRunning = false;
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }

        while (_isRunning)
        {
            switch (Console.ReadLine())
            {
                case "start":
                    BackgroundService();
                    break;
                case "exit":
                    _isRunning = false;
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
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
            if (config != null) {
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


                    foreach (var url in config.BackupServerUrls)
                    {
                        using var backupHttpClient = new HttpClient();

                        var backupServerLoginResponse = await Requests.LoginAsync(backupHttpClient, config.Username, config.Password, url, config.IncludeInfo);

                        if (backupServerLoginResponse == null || backupServerLoginResponse.Status == "error")
                        {
                            Console.WriteLine("Failed to login to backup server.");
                            continue;
                        }

                        var syncBackup = await Requests.SyncBackupAsync(httpClient, config, backupServerLoginResponse.Token, url);

                        if (syncBackup == null || syncBackup.Status == "error")
                        {
                            Console.WriteLine("Failed to sync data to backup server.");
                            continue;
                        }
                    }

                    // Delete the backup file
                    File.Delete(Environment.ProcessPath + "backup.zip");

                    Console.WriteLine("Data synced successfully.");
                    Console.WriteLine("Waiting for next sync...");
                    await Task.Delay(config.SyncInterval * 1000);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static async Task<Configuration> ReadConfigurationAsync()
    {
        var configPath = Path.Combine(Path.GetDirectoryName(Environment.ProcessPath), "config.json");

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
        return JsonSerializer.Deserialize<Configuration>(config);
    }
}
