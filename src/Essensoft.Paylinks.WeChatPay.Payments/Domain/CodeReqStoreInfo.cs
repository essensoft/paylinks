using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class CodeReqStoreInfo
{
    /// <summary>
    /// 门店编号
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// 商家自定义编码
    /// </summary>
    [JsonPropertyName("out_id")]
    public string? OutId { get; set; }
}
