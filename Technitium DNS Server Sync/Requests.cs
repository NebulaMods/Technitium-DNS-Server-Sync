using System.Net;
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
        var response = await client.GetAsync($"{configuration.MainServerUrl}/api/settings/backup?token={token}&blockLists=true&logs=false&scopes=false&apps=false&stats=false&zones=true&allowedZones=true&blockedZones=true&dnsSettings=true&authConfig=true&logSettings=true&ts={timestamp}");
        response.EnsureSuccessStatusCode();

        // Save the file to disk
        var content = await response.Content.ReadAsStreamAsync();
        using var fileStream = File.Create(Environment.ProcessPath + "backup.zip");
        await content.CopyToAsync(fileStream);

        return true;
    }

    public static async Task<RestoreResponse.Root?> SyncBackupAsync(HttpClient client, Configuration configuration, string token, string url)
    {
        // Read the file from disk using form data
        using var fileStream = File.OpenRead(Environment.ProcessPath + "backup.zip");
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(fileStream), "fileBackupZip", "backup.zip");

        var response = await client.PostAsync($"{url}/api/settings/restore?token={token}&blockLists=false&logs=false&scopes=false&apps=false&stats=false&zones=true&allowedZones=true&blockedZones=true&dnsSettings=true&authConfig=true&logSettings=true&deleteExistingFiles=false", content);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(responseContent))
            throw new Exception("Empty response from server.");

        return JsonSerializer.Deserialize<RestoreResponse.Root>(responseContent);
    }

}
