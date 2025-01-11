using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 退款申请
/// </summary>
/// <para>
/// 申请退款 - 更新时间：2025.01.09
/// https://pay.weixin.qq.com/doc/v3/merchant/4013071036
/// https://pay.weixin.qq.com/doc/v3/merchant/4013070371
/// https://pay.weixin.qq.com/doc/v3/merchant/4012810597
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791883
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791903
/// https://pay.weixin.qq.com/doc/v3/merchant/4012556524
/// </para>
public class WeChatPayRefundRequest : IWeChatPayRequest<WeChatPayRefundResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/refund/domestic/refunds";

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
