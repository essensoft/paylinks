using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 合单下单-NATIVE
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/combine-payment/orders/native-prepay.html
/// 合单下单-NATIVE
/// 更新时间：2023.08.23
/// </para>
public class WeChatPayCombineNativePrepayRequest : IWeChatPayRequest<WeChatPayCombineNativePrepayResponse>
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
