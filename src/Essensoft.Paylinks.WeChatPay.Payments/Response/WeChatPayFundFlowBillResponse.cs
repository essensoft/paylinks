using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayFundFlowBillResponse : WeChatPayResponse
{
    /// <summary>
    /// 哈希类型
    /// </summary>
    [JsonPropertyName("hash_type")]
    public string HashType { get; set; }

    /// <summary>
    /// 哈希值
    /// </summary>
    [JsonPropertyName("hash_value")]
    public string HashValue { get; set; }

    /// <summary>
    /// 账单下载地址
    /// </summary>
    [JsonPropertyName("download_url")]
    public string DownloadUrl { get; set; }
}
