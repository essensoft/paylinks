using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 预签约信息
/// </summary>
public class ReqContractInfo
{
    /// <summary>
    /// 签约商户号
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }

    /// <summary>
    /// 签约商户AppID
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 签约商户协议号
    /// </summary>
    [JsonPropertyName("out_contract_code")]
    public string OutContractCode { get; set; }

    /// <summary>
    /// 委托代扣协议模板ID
    /// </summary>
    [JsonPropertyName("plan_id")]
    public string PlanId { get; set; }

    /// <summary>
    /// 用户账户展示名称
    /// </summary>
    [JsonPropertyName("contract_display_account")]
    public string ContractDisplayAccount { get; set; }

    /// <summary>
    /// 回调通知地址
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string NotifyUrl { get; set; }
}
