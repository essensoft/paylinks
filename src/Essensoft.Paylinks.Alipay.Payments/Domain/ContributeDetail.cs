using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class ContributeDetail
{
    /// <summary>
    /// 出资方金额
    /// </summary>
    [JsonPropertyName("contribute_amount")]
    public string ContributeAmount { get; set; }

    /// <summary>
    /// 出资方类型
    /// </summary>
    [JsonPropertyName("contribute_type")]
    public string ContributeType { get; set; }
}
