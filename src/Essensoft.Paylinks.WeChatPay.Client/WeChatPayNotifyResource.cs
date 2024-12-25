using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 通知资源数据
/// </summary>
public class WeChatPayNotifyResource
{
    /// <summary>
    /// 加密算法类型
    /// </summary>
    [JsonPropertyName("algorithm")]
    public string Algorithm { get; set; }

    /// <summary>
    /// 数据密文
    /// </summary>
    [JsonPropertyName("ciphertext")]
    public string Ciphertext { get; set; }

    /// <summary>
    /// 附加数据
    /// </summary>
    [JsonPropertyName("associated_data")]
    public string AssociatedData { get; set; }

    /// <summary>
    /// 原始类型
    /// </summary>
    [JsonPropertyName("original_type")]
    public string OriginalType { get; set; }

    /// <summary>
    /// 加密使用的随机串。
    /// </summary>
    [JsonPropertyName("nonce")]
    public string Nonce { get; set; }
}
