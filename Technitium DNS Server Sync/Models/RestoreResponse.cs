using System.Text.Json.Serialization;

namespace TechnitiumSync.Models;

public class RestoreResponse
{
    public class Response
    {
        [JsonPropertyName("version")]
        public string? Version { get; set; }

        [JsonPropertyName("uptimestamp")]
        public DateTime? Uptimestamp { get; set; }

        [JsonPropertyName("dnsServerDomain")]
        public string? DnsServerDomain { get; set; }

        [JsonPropertyName("dnsServerLocalEndPoints")]
        public List<string?>? DnsServerLocalEndPoints { get; set; }

        [JsonPropertyName("dnsServerIPv4SourceAddresses")]
        public List<string?>? DnsServerIPv4SourceAddresses { get; set; }

        [JsonPropertyName("dnsServerIPv6SourceAddresses")]
        public List<string?>? DnsServerIPv6SourceAddresses { get; set; }

        [JsonPropertyName("defaultRecordTtl")]
        public int? DefaultRecordTtl { get; set; }

        [JsonPropertyName("useSoaSerialDateScheme")]
        public bool? UseSoaSerialDateScheme { get; set; }

        [JsonPropertyName("zoneTransferAllowedNetworks")]
        public List<object>? ZoneTransferAllowedNetworks { get; set; }

        [JsonPropertyName("notifyAllowedNetworks")]
        public List<object>? NotifyAllowedNetworks { get; set; }

        [JsonPropertyName("dnsAppsEnableAutomaticUpdate")]
        public bool? DnsAppsEnableAutomaticUpdate { get; set; }

        [JsonPropertyName("preferIPv6")]
        public bool? PreferIPv6 { get; set; }

        [JsonPropertyName("udpPayloadSize")]
        public int? UdpPayloadSize { get; set; }

        [JsonPropertyName("dnssecValidation")]
        public bool? DnssecValidation { get; set; }

        [JsonPropertyName("eDnsClientSubnet")]
        public bool? EDnsClientSubnet { get; set; }

        [JsonPropertyName("eDnsClientSubnetIPv4PrefixLength")]
        public int? EDnsClientSubnetIPv4PrefixLength { get; set; }

        [JsonPropertyName("eDnsClientSubnetIPv6PrefixLength")]
        public int? EDnsClientSubnetIPv6PrefixLength { get; set; }

        [JsonPropertyName("eDnsClientSubnetIpv4Override")]
        public object? EDnsClientSubnetIpv4Override { get; set; }

        [JsonPropertyName("eDnsClientSubnetIpv6Override")]
        public object? EDnsClientSubnetIpv6Override { get; set; }

        [JsonPropertyName("qpmLimitRequests")]
        public int? QpmLimitRequests { get; set; }

        [JsonPropertyName("qpmLimitErrors")]
        public int? QpmLimitErrors { get; set; }

        [JsonPropertyName("qpmLimitSampleMinutes")]
        public int? QpmLimitSampleMinutes { get; set; }

        [JsonPropertyName("qpmLimitIPv4PrefixLength")]
        public int? QpmLimitIPv4PrefixLength { get; set; }

        [JsonPropertyName("qpmLimitIPv6PrefixLength")]
        public int? QpmLimitIPv6PrefixLength { get; set; }

        [JsonPropertyName("qpmLimitBypassList")]
        public List<object>? QpmLimitBypassList { get; set; }

        [JsonPropertyName("clientTimeout")]
        public int? ClientTimeout { get; set; }

        [JsonPropertyName("tcpSendTimeout")]
        public int? TcpSendTimeout { get; set; }

        [JsonPropertyName("tcpReceiveTimeout")]
        public int? TcpReceiveTimeout { get; set; }

        [JsonPropertyName("quicIdleTimeout")]
        public int? QuicIdleTimeout { get; set; }

        [JsonPropertyName("quicMaxInboundStreams")]
        public int? QuicMaxInboundStreams { get; set; }

        [JsonPropertyName("listenBacklog")]
        public int? ListenBacklog { get; set; }

        [JsonPropertyName("webServiceLocalAddresses")]
        public List<string?>? WebServiceLocalAddresses { get; set; }

        [JsonPropertyName("webServiceHttpPort")]
        public int? WebServiceHttpPort { get; set; }

        [JsonPropertyName("webServiceEnableTls")]
        public bool? WebServiceEnableTls { get; set; }

        [JsonPropertyName("webServiceEnableHttp3")]
        public bool? WebServiceEnableHttp3 { get; set; }

        [JsonPropertyName("webServiceHttpToTlsRedirect")]
        public bool? WebServiceHttpToTlsRedirect { get; set; }

        [JsonPropertyName("webServiceUseSelfSignedTlsCertificate")]
        public bool? WebServiceUseSelfSignedTlsCertificate { get; set; }

        [JsonPropertyName("webServiceTlsPort")]
        public int? WebServiceTlsPort { get; set; }

        [JsonPropertyName("webServiceTlsCertificatePath")]
        public string? WebServiceTlsCertificatePath { get; set; }

        [JsonPropertyName("webServiceTlsCertificatePassword")]
        public string? WebServiceTlsCertificatePassword { get; set; }

        [JsonPropertyName("enableDnsOverUdpProxy")]
        public bool? EnableDnsOverUdpProxy { get; set; }

        [JsonPropertyName("enableDnsOverTcpProxy")]
        public bool? EnableDnsOverTcpProxy { get; set; }

        [JsonPropertyName("enableDnsOverHttp")]
        public bool? EnableDnsOverHttp { get; set; }

        [JsonPropertyName("enableDnsOverTls")]
        public bool? EnableDnsOverTls { get; set; }

        [JsonPropertyName("enableDnsOverHttps")]
        public bool? EnableDnsOverHttps { get; set; }

        [JsonPropertyName("enableDnsOverQuic")]
        public bool? EnableDnsOverQuic { get; set; }

        [JsonPropertyName("dnsOverUdpProxyPort")]
        public int? DnsOverUdpProxyPort { get; set; }

        [JsonPropertyName("dnsOverTcpProxyPort")]
        public int? DnsOverTcpProxyPort { get; set; }

        [JsonPropertyName("dnsOverHttpPort")]
        public int? DnsOverHttpPort { get; set; }

        [JsonPropertyName("dnsOverTlsPort")]
        public int? DnsOverTlsPort { get; set; }

        [JsonPropertyName("dnsOverHttpsPort")]
        public int? DnsOverHttpsPort { get; set; }

        [JsonPropertyName("dnsOverQuicPort")]
        public int? DnsOverQuicPort { get; set; }

        [JsonPropertyName("dnsTlsCertificatePath")]
        public object? DnsTlsCertificatePath { get; set; }

        [JsonPropertyName("dnsTlsCertificatePassword")]
        public string? DnsTlsCertificatePassword { get; set; }

        [JsonPropertyName("tsigKeys")]
        public List<object>? TsigKeys { get; set; }

        [JsonPropertyName("recursion")]
        public string? Recursion { get; set; }

        [JsonPropertyName("recursionDeniedNetworks")]
        public List<object>? RecursionDeniedNetworks { get; set; }

        [JsonPropertyName("recursionAllowedNetworks")]
        public List<object>? RecursionAllowedNetworks { get; set; }

        [JsonPropertyName("randomizeName")]
        public bool? RandomizeName { get; set; }

        [JsonPropertyName("qnameMinimization")]
        public bool? QnameMinimization { get; set; }

        [JsonPropertyName("nsRevalidation")]
        public bool? NsRevalidation { get; set; }

        [JsonPropertyName("resolverRetries")]
        public int? ResolverRetries { get; set; }

        [JsonPropertyName("resolverTimeout")]
        public int? ResolverTimeout { get; set; }

        [JsonPropertyName("resolverMaxStackCount")]
        public int? ResolverMaxStackCount { get; set; }

        [JsonPropertyName("saveCache")]
        public bool? SaveCache { get; set; }

        [JsonPropertyName("serveStale")]
        public bool? ServeStale { get; set; }

        [JsonPropertyName("serveStaleTtl")]
        public int? ServeStaleTtl { get; set; }

        [JsonPropertyName("cacheMaximumEntries")]
        public int? CacheMaximumEntries { get; set; }

        [JsonPropertyName("cacheMinimumRecordTtl")]
        public int? CacheMinimumRecordTtl { get; set; }

        [JsonPropertyName("cacheMaximumRecordTtl")]
        public int? CacheMaximumRecordTtl { get; set; }

        [JsonPropertyName("cacheNegativeRecordTtl")]
        public int? CacheNegativeRecordTtl { get; set; }

        [JsonPropertyName("cacheFailureRecordTtl")]
        public int? CacheFailureRecordTtl { get; set; }

        [JsonPropertyName("cachePrefetchEligibility")]
        public int? CachePrefetchEligibility { get; set; }

        [JsonPropertyName("cachePrefetchTrigger")]
        public int? CachePrefetchTrigger { get; set; }

        [JsonPropertyName("cachePrefetchSampleIntervalInMinutes")]
        public int? CachePrefetchSampleIntervalInMinutes { get; set; }

        [JsonPropertyName("cachePrefetchSampleEligibilityHitsPerHour")]
        public int? CachePrefetchSampleEligibilityHitsPerHour { get; set; }

        [JsonPropertyName("enableBlocking")]
        public bool? EnableBlocking { get; set; }

        [JsonPropertyName("allowTxtBlockingReport")]
        public bool? AllowTxtBlockingReport { get; set; }

        [JsonPropertyName("blockingBypassList")]
        public List<object>? BlockingBypassList { get; set; }

        [JsonPropertyName("blockingType")]
        public string? BlockingType { get; set; }

        [JsonPropertyName("customBlockingAddresses")]
        public List<object>? CustomBlockingAddresses { get; set; }

        [JsonPropertyName("blockListUrls")]
        public List<string?>? BlockListUrls { get; set; }

        [JsonPropertyName("blockListUpdateIntervalHours")]
        public int? BlockListUpdateIntervalHours { get; set; }

        [JsonPropertyName("blockListNextUpdatedOn")]
        public DateTime? BlockListNextUpdatedOn { get; set; }

        [JsonPropertyName("proxy")]
        public object? Proxy { get; set; }

        [JsonPropertyName("forwarders")]
        public List<string?>? Forwarders { get; set; }

        [JsonPropertyName("forwarderProtocol")]
        public string? ForwarderProtocol { get; set; }

        [JsonPropertyName("forwarderRetries")]
        public int? ForwarderRetries { get; set; }

        [JsonPropertyName("forwarderTimeout")]
        public int? ForwarderTimeout { get; set; }

        [JsonPropertyName("forwarderConcurrency")]
        public int? ForwarderConcurrency { get; set; }

        [JsonPropertyName("enableLogging")]
        public bool? EnableLogging { get; set; }

        [JsonPropertyName("ignoreResolverLogs")]
        public bool? IgnoreResolverLogs { get; set; }

        [JsonPropertyName("logQueries")]
        public bool? LogQueries { get; set; }

        [JsonPropertyName("useLocalTime")]
        public bool? UseLocalTime { get; set; }

        [JsonPropertyName("logFolder")]
        public string? LogFolder { get; set; }

        [JsonPropertyName("maxLogFileDays")]
        public int? MaxLogFileDays { get; set; }

        [JsonPropertyName("enableInMemoryStats")]
        public bool? EnableInMemoryStats { get; set; }

        [JsonPropertyName("maxStatFileDays")]
        public int? MaxStatFileDays { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("response")]
        public Response? Response { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}