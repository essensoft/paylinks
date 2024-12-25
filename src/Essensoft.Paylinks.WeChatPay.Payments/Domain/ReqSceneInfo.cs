using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class ReqSceneInfo
{
    /// <summary>
    /// 商户端设备号
    /// </summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 用户终端IP
    /// </summary>
    [JsonPropertyName("payer_client_ip")]
    public string PayerClientIp { get; set; }
}
