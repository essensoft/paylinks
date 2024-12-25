using Essensoft.Paylinks.Alipay.Client;
using Essensoft.Paylinks.WeChatPay.Client;

namespace Essensoft.Paylinks.Sample.Web;

/// <summary>
/// Paylinks 选项
/// </summary>
public class PaylinksOptions
{
    /// <summary>
    /// Alipay 客户端选项
    /// </summary>
    public AlipayClientOptions Alipay { get; set; }

    /// <summary>
    /// WeChatPay 客户端选项
    /// </summary>
    public WeChatPayClientOptions WeChatPay { get; set; }
}
