using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 关闭订单
/// </summary>
/// <para>
/// 关闭订单 - 更新时间：2024.12.11
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791860
/// 关闭订单 - 更新时间：2024.11.25
/// https://pay.weixin.qq.com/doc/v3/merchant/4013070360
/// 关闭订单 - 更新时间：2024.12.11
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791839
/// 关闭订单 - 更新时间：2024.12.11
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791881
/// 关闭订单 - 更新时间：2024.12.11
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791901
/// </para>
public class WeChatPayCloseByOutTradeNoRequest : IWeChatPayRequest<WeChatPayCloseByOutTradeNoResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => $"/v3/pay/transactions/out-trade-no/{OutTradeNo}/close";

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
    /// 商户订单号
    /// </summary>
    public string OutTradeNo { get; set; }
}
