using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

[Obsolete("Use WeChatPayCombineTransactionsQueryByCombineOutTradeNoRequest")]
public class WeChatPayCombineQueryByCombineOutTradeNoRequest : WeChatPayCombineTransactionsQueryByCombineOutTradeNoRequest;

/// <summary>
/// 合单查询 - 更新时间：2025.01.10
/// </summary>
/// <para>
/// 合单查询
/// https://pay.weixin.qq.com/doc/v3/merchant/4012557006
/// </para>
public class WeChatPayCombineTransactionsQueryByCombineOutTradeNoRequest : IWeChatPayRequest<WeChatPayCombineTransactionsQueryByCombineOutTradeNoResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Get;

    public string GetRequestUrl() => $"/v3/combine-transactions/out-trade-no/{CombineOutTradeNo}";

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
    /// 合单商户订单号
    /// </summary>
    public string CombineOutTradeNo { get; set; }
}
