using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayTransactionsAppRequest")]
public class WeChatPayAppPrepayRequest : WeChatPayTransactionsAppRequest;

/// <summary>
/// APP下单
/// </summary>
/// <para>
/// APP下单 - 更新时间：2024.12.30
/// https://pay.weixin.qq.com/doc/v3/merchant/4013070347
/// </para>
public class WeChatPayTransactionsAppRequest : IWeChatPayRequest<WeChatPayTransactionsAppResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/pay/transactions/app";

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
