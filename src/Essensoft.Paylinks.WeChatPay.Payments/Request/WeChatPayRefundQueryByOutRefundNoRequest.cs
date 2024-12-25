using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 查询单笔退款（通过商户退款单号）
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/jsapi-payment/query-by-out-refund-no.html
/// 查询单笔退款（通过商户退款单号）
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/in-app-payment/query-by-out-refund-no.html
/// 查询单笔退款（通过商户退款单号）
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/h5-payment/query-by-out-refund-no.html
/// 查询单笔退款（通过商户退款单号）
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/native-payment/query-by-out-refund-no.html
/// 查询单笔退款（通过商户退款单号）
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/mini-program-payment/query-by-out-refund-no.html
/// 查询单笔退款（通过商户退款单号）
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/combine-payment/refunds/query-by-out-refund-no.html
/// 查询单笔退款（通过商户退款单号）
/// 更新时间：2023.08.23
/// </para>
public class WeChatPayRefundQueryByOutRefundNoRequest : IWeChatPayRequest<WeChatPayRefundQueryByOutRefundNoResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Get;

    public string GetRequestUrl() => $"/v3/refund/domestic/refunds/{OutRefundNo}";

    private bool _needVerify = true;

    public bool GetNeedVerify() => _needVerify;

    public void SetNeedVerify(bool value) => _needVerify = value;

    private object? _queryModel;

    public void SetQueryModel(object queryModel) => _queryModel = queryModel;

    public object? GetQueryModel() => _queryModel;

    private object? _bodyModel;

    public void SetBodyModel(object bodyModel) => _bodyModel = bodyModel;

    public object? GetBodyModel() => _bodyModel;

    #endregion

    /// <summary>
    /// 商户退款单号
    /// </summary>
    public string OutRefundNo { get; set; }
}
