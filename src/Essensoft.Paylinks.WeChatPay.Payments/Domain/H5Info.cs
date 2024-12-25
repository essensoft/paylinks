using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// H5场景信息
/// </summary>
public class H5Info
{
    /// <summary>
    /// 场景类型
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// 应用名称
    /// </summary>
    [JsonPropertyName("app_name")]
    public string? AppName { get; set; }

    /// <summary>
    /// 网站URL
    /// </summary>
    [JsonPropertyName("app_url")]
    public string? AppUrl { get; set; }

    /// <summary>
    /// iOS平台 BundleID
    /// </summary>
    [JsonPropertyName("bundle_id")]
    public string? BundleId { get; set; }

    /// <summary>
    /// Android平台 PackageName
    /// </summary>
    [JsonPropertyName("package_name")]
    public string? PackageName { get; set; }
}
