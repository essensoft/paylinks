using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayCombineTransactionsJsapiRequest")]
public class WeChatPayCombineJsapiPrepayRequest : WeChatPayCombineTransactionsJsapiRequest;

/// <summary>
/// JSAPI合单下单 / 小程序合单下单
/// </summary>
/// <para>
/// JSAPI合单下单 - 更新时间：2025.01.10
/// https://pay.weixin.qq.com/doc/v3/merchant/4012556926
/// 小程序合单下单 - 更新时间：2025.01.10
/// https://pay.weixin.qq.com/doc/v3/merchant/4012556931
/// </para>
public class WeChatPayCombineTransactionsJsapiRequest : IWeChatPayRequest<WeChatPayCombineTransactionsJsapiResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/combine-transactions/jsapi";

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
