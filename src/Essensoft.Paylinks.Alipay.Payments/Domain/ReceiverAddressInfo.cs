using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class ReceiverAddressInfo
{
    /// <summary>
    /// 收货地址
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// 中国标准城市区域码
    /// </summary>
    [JsonPropertyName("division_code")]
    public string? DivisionCode { get; set; }

    /// <summary>
    /// 收货人手机号
    /// </summary>
    [JsonPropertyName("mobile")]
    public string? Mobile { get; set; }

    /// <summary>
    /// 收货人的姓名
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 收货地址邮编
    /// </summary>
    [JsonPropertyName("zip")]
    public string? Zip { get; set; }
}
