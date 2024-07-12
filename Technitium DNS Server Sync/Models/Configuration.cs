using System.Text.Json.Serialization;

namespace TechnitiumSync.Models;
public class Configuration
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("includeInfo")]
    public bool IncludeInfo { get; set; }

    [JsonPropertyName("mainServerUrl")]
    public string MainServerUrl { get; set; }

    [JsonPropertyName("backupServerUrls")]
    public string[] BackupServerUrls { get; set; }

    [JsonPropertyName("syncInterval")]
    public int SyncInterval { get; set; }

    // What items to sync

    [JsonPropertyName("blockLists")]
    public bool BlockLists { get; set; }

    [JsonPropertyName("logs")]
    public bool Logs { get; set; }

    [JsonPropertyName("scopes")]
    public bool Scopes { get; set; }

    [JsonPropertyName("apps")]
    public bool Apps { get; set; }

    [JsonPropertyName("stats")]
    public bool Stats { get; set; }

    [JsonPropertyName("zones")]
    public bool Zones { get; set; }

    [JsonPropertyName("allowedZones")]
    public bool AllowedZones { get; set; }

    [JsonPropertyName("blockedZones")]
    public bool BlockedZones { get; set; }

    [JsonPropertyName("dnsSettings")]
    public bool DnsSettings { get; set; }

    [JsonPropertyName("authConfig")]
    public bool AuthConfig { get; set; }

    [JsonPropertyName("logSettings")]
    public bool LogSettings { get; set; }

    [JsonPropertyName("deleteExistingFiles")]
    public bool DeleteExistingFiles { get; set; }
}