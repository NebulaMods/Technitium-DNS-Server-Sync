using System.Text.Json.Serialization;

namespace TechnitiumSync.Models;
public class LoginResponse
{
    public class Administration
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class Allowed
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class Apps
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class Blocked
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class Cache
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class Dashboard
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class DhcpServer
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class DnsClient
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class Info
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("uptimestamp")]
        public DateTime? Uptimestamp { get; set; }

        [JsonPropertyName("dnsServerDomain")]
        public string DnsServerDomain { get; set; }

        [JsonPropertyName("defaultRecordTtl")]
        public int? DefaultRecordTtl { get; set; }

        [JsonPropertyName("useSoaSerialDateScheme")]
        public bool? UseSoaSerialDateScheme { get; set; }

        [JsonPropertyName("dnssecValidation")]
        public bool? DnssecValidation { get; set; }

        [JsonPropertyName("permissions")]
        public Permissions Permissions { get; set; }
    }

    public class Logs
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class Permissions
    {
        [JsonPropertyName("Dashboard")]
        public Dashboard Dashboard { get; set; }

        [JsonPropertyName("Zones")]
        public Zones Zones { get; set; }

        [JsonPropertyName("Cache")]
        public Cache Cache { get; set; }

        [JsonPropertyName("Allowed")]
        public Allowed Allowed { get; set; }

        [JsonPropertyName("Blocked")]
        public Blocked Blocked { get; set; }

        [JsonPropertyName("Apps")]
        public Apps Apps { get; set; }

        [JsonPropertyName("DnsClient")]
        public DnsClient DnsClient { get; set; }

        [JsonPropertyName("Settings")]
        public Settings Settings { get; set; }

        [JsonPropertyName("DhcpServer")]
        public DhcpServer DhcpServer { get; set; }

        [JsonPropertyName("Administration")]
        public Administration Administration { get; set; }

        [JsonPropertyName("Logs")]
        public Logs Logs { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class Settings
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

    public class Zones
    {
        [JsonPropertyName("canView")]
        public bool? CanView { get; set; }

        [JsonPropertyName("canModify")]
        public bool? CanModify { get; set; }

        [JsonPropertyName("canDelete")]
        public bool? CanDelete { get; set; }
    }

}
