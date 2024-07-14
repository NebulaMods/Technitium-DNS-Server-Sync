﻿using System.Net;
using System.Text.Json;

using TechnitiumSync.Models;

namespace TechnitiumSync;

internal class Requests
{
    public static async Task<LoginResponse.Root?> LoginAsync(HttpClient client, string user, string password, string url, bool includeInfo)
    {
        // Encode username and password
        user = WebUtility.UrlEncode(user);
        password = WebUtility.UrlEncode(password);

        var response = await client.GetAsync($"{url}/api/user/login?user={user}&pass={password}&includeInfo={includeInfo}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return string.IsNullOrEmpty(content)
            ? throw new Exception("Empty response from server.")
            : JsonSerializer.Deserialize<LoginResponse.Root>(content);
    }

    public static async Task<bool> GetBackupAsync(HttpClient client, Configuration configuration, string token)
    {
        // Generate timestamp for request
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var response = await client.GetAsync($"{configuration.MainServerUrl}/api/settings/backup?token={token}" +
            $"&blockLists={configuration.BlockLists}&logs={configuration.Logs}&scopes={configuration.Scopes}&apps={configuration.Apps}" +
            $"&stats={configuration.Stats}&zones={configuration.Zones}&allowedZones={configuration.AllowedZones}" +
            $"&blockedZones={configuration.BlockedZones}&dnsSettings={configuration.DnsSettings}&authConfig={configuration.AuthConfig}&logSettings={configuration.LogSettings}&ts={timestamp}");
        response.EnsureSuccessStatusCode();

        // Save the file to disk
        var runningPath = Path.GetDirectoryName(Environment.ProcessPath);

        if (string.IsNullOrWhiteSpace(runningPath))
        {
            Console.WriteLine("Failed to get the running path.");
            return false;
        }

        var backupPath = Path.Combine(runningPath, "backup.zip");

        var content = await response.Content.ReadAsStreamAsync();
        using var fileStream = File.Create(backupPath);
        await content.CopyToAsync(fileStream);

        return true;
    }

    public static async Task<RestoreResponse.Root?> SyncBackupAsync(HttpClient client, Configuration configuration, string token, string url)
    {
        // Read the file from disk using form data
        var runningPath = Path.GetDirectoryName(Environment.ProcessPath);
        if (string.IsNullOrWhiteSpace(runningPath))
        {
            Console.WriteLine("Failed to get the running path.");
            return null;
        }

        var backupPath = Path.Combine(runningPath, "backup.zip");

        using var fileStream = File.OpenRead(backupPath);
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(fileStream), "fileBackupZip", "backup.zip");

        var response = await client.PostAsync($"{url}/api/settings/restore?token={token}" +
            $"&blockLists={configuration.BlockLists}&logs={configuration.Logs}&scopes={configuration.Scopes}&apps={configuration.Apps}" +
            $"&stats={configuration.Stats}&zones={configuration.Zones}&allowedZones={configuration.AllowedZones}" +
            $"&blockedZones={configuration.BlockedZones}&dnsSettings={configuration.DnsSettings}&authConfig={configuration.AuthConfig}&logSettings={configuration.LogSettings}&deleteExistingFiles=false", content);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        return string.IsNullOrEmpty(responseContent)
            ? throw new Exception("Empty response from server.")
            : JsonSerializer.Deserialize<RestoreResponse.Root>(responseContent);
    }
}