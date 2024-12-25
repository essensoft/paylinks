using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 退款申请
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/refund/refunds/create.html
/// 退款申请
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/jsapi-payment/create.html
/// 退款申请
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/in-app-payment/create.html
/// 退款申请
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/h5-payment/create.html
/// 退款申请
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/native-payment/create.html
/// 退款申请
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/mini-program-payment/create.html
/// 退款申请
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/combine-payment/refunds/create.html
/// 退款申请
/// 更新时间：2023.08.23
/// </para>
public class WeChatPayRefundRequest : IWeChatPayRequest<WeChatPayRefundResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/refund/domestic/refunds";

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
