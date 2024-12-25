using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayTradeRefundBodyModel
{
    /// <summary>
    /// 退款金额。 需要退款的金额，该金额不能大于订单金额，单位为元，支持两位小数。 注：如果正向交易使用了营销，该退款金额包含营销金额，支付宝会按业务规则分配营销和买家自有资金分别退多少，默认优先退买家的自有资金。如交易总金额100元，用户支付时使用了80元自有资金和20元无资金流的营销券，商家实际收款80元。如果首次请求退款60元，则60元全部从商家收款资金扣除退回给用户自有资产；如果再请求退款40元，则从商家收款资金扣除20元退回用户资产以及把20元的营销券退回给用户（券是否可再使用取决于券的规则配置）。
    /// </summary>
    [JsonPropertyName("refund_amount")]
    public string RefundAmount { get; set; }

    /// <summary>
    /// 商户订单号。 订单支付时传入的商户订单号，商家自定义且保证商家系统中唯一。与支付宝交易号 trade_no 不能同时为空。
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string? OutTradeNo { get; set; }

    /// <summary>
    /// 支付宝交易号。 和商户订单号 out_trade_no 不能同时为空，两者同时存在时，优先取值trade_no
    /// </summary>
    [JsonPropertyName("trade_no")]
    public string? TradeNo { get; set; }

    /// <summary>
    /// 退款原因说明。 商家自定义，将在会在商户和用户的pc退款账单详情中展示
    /// </summary>
    [JsonPropertyName("refund_reason")]
    public string? RefundReason { get; set; }

    /// <summary>
    /// 退款请求号。 标识一次退款请求，需要保证在交易号下唯一，如需部分退款，则此参数必传。 注：针对同一次退款请求，如果调用接口失败或异常了，重试时需要保证退款请求号不能变更，防止该笔交易重复退款。支付宝会保证同样的退款请求号多次请求只会退一次。
    /// </summary>
    [JsonPropertyName("out_request_no")]
    public string? OutRequestNo { get; set; }

    /// <summary>
    /// 退款包含的商品列表信息
    /// </summary>
    [JsonPropertyName("refund_goods_detail")]
    public List<RefundGoodsDetail>? RefundGoodsDetail { get; set; }

    /// <summary>
    /// 退分账明细信息。 注：1.当面付且非直付通模式无需传入退分账明细，系统自动按退款金额与订单金额的比率，从收款方和分账收入方退款，不支持指定退款金额与退款方。 2.直付通模式，电脑网站支付，手机 APP 支付，手机网站支付产品，须在退款请求中明确是否退分账，从哪个分账收入方退，退多少分账金额；如不明确，默认从收款方退款，收款方余额不足退款失败。不支持系统按比率退款。
    /// </summary>
    [JsonPropertyName("refund_royalty_parameters")]
    public List<OpenApiRoyaltyDetailInfoPojo>? RefundRoyaltyParameters { get; set; }

    /// <summary>
    /// 查询选项。 商户通过上送该参数来定制同步需要额外返回的信息字段，数组格式。
    /// </summary>
    [JsonPropertyName("query_options")]
    public List<string>? QueryOptions { get; set; }

    /// <summary>
    /// 针对账期交易，在确认结算后退款的话，需要指定确认结算时的结算单号。
    /// </summary>
    [JsonPropertyName("related_settle_confirm_no")]
    public string? RelatedSettleConfirmNo { get; set; }
}
