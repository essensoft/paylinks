using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Certificates.Model;

public class WeChatPayGetCertificatesQueryModel
{
    /// <summary>
    /// 平台证书算法类型
    /// SM2：获取国密算法的平台证书
    /// RSA：获取RSA算法的平台证书
    /// ALL：获取所有类型的平台证书
    /// 不填：默认获取RSA算法的平台证书
    /// </summary>
    [JsonPropertyName("algorithm_type")]
    public string? AlgorithmType { get; set; }
}
