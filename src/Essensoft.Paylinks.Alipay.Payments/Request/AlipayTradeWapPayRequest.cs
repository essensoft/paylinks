using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Payments.Request;

/// <summary>
/// alipay.trade.wap.pay(手机网站支付接口2.0)
/// </summary>
/// <para>
/// https://opendocs.alipay.com/open-v3/1a957be0_alipay.trade.wap.pay
/// alipay.trade.wap.pay(手机网站支付接口2.0)
/// 更新时间：2024-05-28 12:22:53
/// </para>
public class AlipayTradeWapPayRequest : IAlipaySdkRequest
{
    #region IAlipaySdkRequest Members

    public string GetMethod() => "alipay.trade.wap.pay";

    private object _bizModel;

    public void SetBizModel(object bizModel) => _bizModel = bizModel;

    public object GetBizModel() => _bizModel;

    private bool _needEncrypt;

    public bool GetNeedEncrypt() => _needEncrypt;

    public void SetNeedEncrypt(bool value) => _needEncrypt = value;

    #endregion
}
