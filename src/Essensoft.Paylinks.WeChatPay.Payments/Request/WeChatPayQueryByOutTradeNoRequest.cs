using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 商户订单号查询订单
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/jsapi-payment/query-by-out-trade-no.html
/// 商户订单号查询订单
/// 更新时间：2023.08.16
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/in-app-payment/query-by-out-trade-no.html
/// 商户订单号查询订单
/// 更新时间：2023.08.16
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/h5-payment/query-by-out-trade-no.html
/// 商户订单号查询订单
/// 更新时间：2023.08.16
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/native-payment/query-by-out-trade-no.html
/// 商户订单号查询订单
/// 更新时间：2023.08.16
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/mini-program-payment/query-by-out-trade-no.html
/// 商户订单号查询订单
/// 更新时间：2023.08.16
/// </para>
public class WeChatPayQueryByOutTradeNoRequest : IWeChatPayRequest<WeChatPayQueryByOutTradeNoResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Get;

    public string GetRequestUrl() => $"/v3/pay/transactions/out-trade-no/{OutTradeNo}";

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
