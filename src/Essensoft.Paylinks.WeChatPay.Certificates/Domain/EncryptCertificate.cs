using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Certificates.Domain;

/// <summary>
/// 证书内容
/// </summary>
public class EncryptCertificate
{
    /// <summary>
    /// 加密证书的算法
    /// </summary>
    [JsonPropertyName("algorithm")]
    public string Algorithm { get; set; }

    /// <summary>
    /// 加密证书的随机串
    /// </summary>
    [JsonPropertyName("nonce")]
    public string Nonce { get; set; }

    /// <summary>
    /// 加密证书的附加数据
    /// </summary>
    [JsonPropertyName("associated_data")]
    public string? AssociatedData { get; set; }

    /// <summary>
    /// 加密后的证书内容
    /// </summary>
    [JsonPropertyName("ciphertext")]
    public string Ciphertext { get; set; }
}
