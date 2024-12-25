using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 撤销
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/code-payment-v3/direct/reverse.html
/// 撤销
/// 更新时间：2024.04.15
/// </para>
public class WeChatPayReverseRequest : IWeChatPayRequest<WeChatPayReverseResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => $"/v3/pay/transactions/out-trade-no/{OutTradeNo}/reverse";

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
    /// 商户订单号
    /// </summary>
    public string OutTradeNo { get; set; }
}
