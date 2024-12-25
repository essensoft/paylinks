using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Payments.Request;

/// <summary>
/// alipay.trade.app.pay(app支付接口2.0)
/// </summary>
/// <para>
/// https://opendocs.alipay.com/open-v3/429e4d75_alipay.trade.app.pay
/// alipay.trade.app.pay(app支付接口2.0)
/// 更新时间：2024-06-05 13:47:07
/// </para>
public class AlipayTradeAppPayRequest : IAlipaySdkRequest
{
    #region IAlipaySdkRequest Members

    public string GetMethod() => "alipay.trade.app.pay";

    private object _bizModel;

    public void SetBizModel(object bizModel) => _bizModel = bizModel;

    public object GetBizModel() => _bizModel;

    private bool _needEncrypt;

    public bool GetNeedEncrypt() => _needEncrypt;

    public void SetNeedEncrypt(bool value) => _needEncrypt = value;

    #endregion
}
