using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayCombineTransactionsNativeRequest")]
public class WeChatPayCombineNativePrepayRequest : WeChatPayCombineTransactionsNativeRequest;

/// <summary>
/// Native合单下单
/// </summary>
/// <para>
/// Native合单下单 - 更新时间：2025.01.10
/// https://pay.weixin.qq.com/doc/v3/merchant/4012556982
/// </para>
public class WeChatPayCombineTransactionsNativeRequest : IWeChatPayRequest<WeChatPayCombineTransactionsNativeResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/combine-transactions/native";

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
