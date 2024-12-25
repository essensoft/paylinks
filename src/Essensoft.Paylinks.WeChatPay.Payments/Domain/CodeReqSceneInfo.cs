using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 商户门店信息
/// </summary>
public class CodeReqSceneInfo
{
    /// <summary>
    /// 商户端设备号
    /// </summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 商户端设备 IP。
    /// </summary>
    [JsonPropertyName("device_ip")]
    public string? DeviceIp { get; set; }

    /// <summary>
    /// 商户门店信息。
    /// </summary>
    [JsonPropertyName("store_info")]
    public CodeReqStoreInfo StoreInfo { get; set; }
}
