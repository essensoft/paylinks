using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayFundFlowBillRequest")]
public class WeChatPayGetFundFlowBillRequest : WeChatPayFundFlowBillRequest;

/// <summary>
/// 申请资金账单
/// </summary>
/// <para>
/// 申请资金账单
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791867
/// https://pay.weixin.qq.com/doc/v3/merchant/4013070400
/// https://pay.weixin.qq.com/doc/v3/merchant/4012810609
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791888
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791908
/// https://pay.weixin.qq.com/doc/v3/merchant/4012556748
/// https://pay.weixin.qq.com/doc/v3/merchant/4013071235
/// </para>
public class WeChatPayFundFlowBillRequest : IWeChatPayRequest<WeChatPayFundFlowBillResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Get;

    public string GetRequestUrl() => "/v3/bill/fundflowbill";

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
