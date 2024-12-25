using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 商户门店信息
/// </summary>
public class StoreInfo
{
    /// <summary>
    /// 门店编号
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// 门店名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 地区编码
    /// </summary>
    [JsonPropertyName("area_code")]
    public string? AreaCode { get; set; }

    /// <summary>
    /// 详细地址
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }
}
