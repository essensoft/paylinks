using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayCombineTransactionsH5Request")]
public class WeChatPayCombineH5PrepayRequest : WeChatPayCombineTransactionsH5Request;

/// <summary>
/// H5合单下单
/// </summary>
/// <para>
/// H5合单下单 - 更新时间：2025.01.10
/// https://pay.weixin.qq.com/doc/v3/merchant/4012556961
/// </para>
public class WeChatPayCombineTransactionsH5Request : IWeChatPayRequest<WeChatPayCombineTransactionsH5Response>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/combine-transactions/h5";

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
