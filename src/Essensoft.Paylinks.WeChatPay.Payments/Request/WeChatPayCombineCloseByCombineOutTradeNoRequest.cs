using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 合单关单
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/combine-payment/orders/close-order.html
/// 合单关单
/// 更新时间：2023.08.23
/// </para>
public class WeChatPayCombineCloseByCombineOutTradeNoRequest : IWeChatPayRequest<WeChatPayCombineCloseByCombineOutTradeNoResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => $"/v3/combine-transactions/out-trade-no/{CombineOutTradeNo}/close";

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
    /// 合单商户单号
    /// </summary>
    public string CombineOutTradeNo { get; set; }
}
