using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// JSAPI下单 / 小程序下单
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/jsapi-payment/direct-jsons/jsapi-prepay.html
/// JSAPI下单
/// 更新时间：2023.08.16
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/mini-program-payment/mini-prepay.html
/// 小程序下单
/// 更新时间：2023.08.16
/// </para>
public class WeChatPayJsapiPrepayRequest : IWeChatPayRequest<WeChatPayJsapiPrepayResponse>
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
