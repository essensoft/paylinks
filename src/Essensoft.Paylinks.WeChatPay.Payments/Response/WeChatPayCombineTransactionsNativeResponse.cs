using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayCombineTransactionsNativeResponse : WeChatPayResponse
{
    /// <summary>
    /// 二维码链接
    /// </summary>
    [JsonPropertyName("code_url")]
    public string CodeUrl { get; set; }
}
