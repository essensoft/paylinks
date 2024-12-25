using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class LogisticsDetail
{
    /// <summary>
    /// 物流类型
    /// </summary>
    [JsonPropertyName("logistics_type")]
    public string LogisticsType { get; set; }
}
