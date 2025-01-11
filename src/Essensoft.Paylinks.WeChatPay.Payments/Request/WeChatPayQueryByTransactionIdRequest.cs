using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 微信支付订单号查询订单
/// </summary>
/// <para>
/// 微信支付订单号查询订单
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791858
/// https://pay.weixin.qq.com/doc/v3/merchant/4013070354
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791837
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791879
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791899
/// </para>
public class WeChatPayQueryByTransactionIdRequest : IWeChatPayRequest<WeChatPayQueryByTransactionIdResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Get;

    public string GetRequestUrl() => $"/v3/pay/transactions/id/{TransactionId}";

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
    /// 微信支付订单号
    /// </summary>
    public string TransactionId { get; set; }
}
