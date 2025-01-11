using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 商户订单号查询订单
/// </summary>
/// <para>
/// 商户订单号查询订单
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791859
/// https://pay.weixin.qq.com/doc/v3/merchant/4013070356
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791838
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791880
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791900
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
