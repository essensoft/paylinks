using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayTransactionsJsapiRequest")]
public class WeChatPayJsapiPrepayRequest : WeChatPayTransactionsJsapiRequest;

/// <summary>
/// JSAPI下单 / 小程序下单
/// </summary>
/// <para>
/// JSAPI下单 - 更新时间：2025.01.10
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791856
/// 小程序下单 - 更新时间：2025.01.02
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791897
/// </para>
public class WeChatPayTransactionsJsapiRequest : IWeChatPayRequest<WeChatPayTransactionsJsapiResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/pay/transactions/jsapi";

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
