using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class CommRespSceneInfo
{
    /// <summary>
    /// 终端设备号
    /// </summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }
}
