using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayTradeBillRequest")]
public class WeChatPayGetTradeBillRequest : WeChatPayTradeBillRequest;

/// <summary>
/// 申请交易账单
/// </summary>
/// <para>
/// 申请交易账单
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791866
/// https://pay.weixin.qq.com/doc/v3/merchant/4013070395
/// https://pay.weixin.qq.com/doc/v3/merchant/4012810606
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791887
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791907
/// https://pay.weixin.qq.com/doc/v3/merchant/4012556692
/// https://pay.weixin.qq.com/doc/v3/merchant/4013071227
/// </para>
public class WeChatPayTradeBillRequest : IWeChatPayRequest<WeChatPayTradeBillResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Get;

    public string GetRequestUrl() => "/v3/bill/tradebill";

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
