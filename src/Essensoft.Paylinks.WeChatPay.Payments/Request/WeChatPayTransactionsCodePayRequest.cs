using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayTransactionsCodePayRequest")]
public class WeChatPayCodePayRequest : WeChatPayTransactionsCodePayRequest;

/// <summary>
/// 付款码支付
/// </summary>
/// <para>
/// 付款码支付 - 更新时间：2024.12.03
/// https://pay.weixin.qq.com/doc/v3/merchant/4012382150
/// </para>
public class WeChatPayTransactionsCodePayRequest : IWeChatPayRequest<WeChatPayTransactionsCodePayResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/pay/transactions/codepay";

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
}
