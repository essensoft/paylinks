using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayCombineTransactionsAppRequest")]
public class WeChatPayCombineAppPrepayRequest : WeChatPayCombineTransactionsAppRequest;

/// <summary>
/// App合单下单
/// </summary>
/// <para>
/// App合单下单 - 更新时间：2025.01.10
/// https://pay.weixin.qq.com/doc/v3/merchant/4012556944
/// </para>
public class WeChatPayCombineTransactionsAppRequest : IWeChatPayRequest<WeChatPayCombineTransactionsAppResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/combine-transactions/app";

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
