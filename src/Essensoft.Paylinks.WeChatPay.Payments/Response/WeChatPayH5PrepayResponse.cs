using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayH5PrepayResponse : WeChatPayResponse
{
    /// <summary>
    /// 支付跳转链接
    /// h5_url为拉起微信支付收银台的中间页面，可通过访问该URL来拉起微信客户端，完成支付，h5_url的有效期为5分钟。
    /// </summary>
    [JsonPropertyName("h5_url")]
    public string H5Url { get; set; }
}
