using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class BusinessParams
{
    /// <summary>
    /// 实际订单时间，在乘车码场景，传入的是用户刷码乘车时间
    /// </summary>
    [JsonPropertyName("actual_order_time")]
    public DateTimeOffset? ActualOrderTime { get; set; }

    /// <summary>
    /// 校园卡编号
    /// </summary>
    [JsonPropertyName("campus_card")]
    public string? CampusCard { get; set; }

    /// <summary>
    /// 虚拟卡卡类型
    /// </summary>
    [JsonPropertyName("card_type")]
    public string? CardType { get; set; }

    /// <summary>
    /// 因公付金额，单位：元。
    /// </summary>
    [JsonPropertyName("enterprise_pay_amount")]
    public string? EnterprisePayAmount { get; set; }

    /// <summary>
    /// 因公付业务信息
    /// </summary>
    [JsonPropertyName("enterprise_pay_info")]
    public string? EnterprisePayInfo { get; set; }

    /// <summary>
    /// 商户传入的交易税费。需要落地风控使用
    /// </summary>
    [JsonPropertyName("good_taxes")]
    public string? GoodTaxes { get; set; }

    /// <summary>
    /// 商户端创建订单的 IP，须上传正确的用户端外网 IP，支持 ipv4/ipv6 格式； mc_create_trade_ip和mcCreateTradeIp（旧）参数描述相同，首选mc_create_trade_ip入参，请勿重复入参； 如已入参mcCreateTradeIp（旧），无需新增入参mc_create_trade_ip。
    /// </summary>
    [JsonPropertyName("mc_create_trade_ip")]
    public string? McCreateTradeIp { get; set; }

    /// <summary>
    /// 当需要在 商家平台（b.alipay.com）—数据中心 中查看对应业务场景下的数据明细可以通过该参数传入 支持传入的值：&lt;a target&#x3D;\&quot;_blank\&quot; href&#x3D;\&quot;https://opendocs.alipay.com/mini/08by8k?pathHash&#x3D;96e03412\&quot;&gt;小程序细分业务场景&lt;/a&gt;
    /// </summary>
    [JsonPropertyName("tiny_app_merchant_biz_type")]
    public string? TinyAppMerchantBizType { get; set; }
}
