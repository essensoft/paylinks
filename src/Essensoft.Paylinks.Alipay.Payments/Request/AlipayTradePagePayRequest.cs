using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Payments.Request;

/// <summary>
/// alipay.trade.page.pay(统一收单下单并支付页面接口)
/// </summary>
/// <para>
/// https://opendocs.alipay.com/open-v3/2423fad5_alipay.trade.page.pay
/// alipay.trade.page.pay(统一收单下单并支付页面接口)
/// 更新时间：2024-05-28 12:22:52
/// </para>
public class AlipayTradePagePayRequest : IAlipaySdkRequest
{
    #region IAlipayRequest Members

    public string GetMethod() => "alipay.trade.page.pay";

    private object _bizModel;

    public void SetBizModel(object bizModel) => _bizModel = bizModel;

    public object GetBizModel() => _bizModel;

    private bool _needEncrypt;

    public bool GetNeedEncrypt() => _needEncrypt;

    public void SetNeedEncrypt(bool value) => _needEncrypt = value;

    #endregion
}
