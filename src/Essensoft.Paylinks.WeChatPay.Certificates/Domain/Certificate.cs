using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Certificates.Domain;

/// <summary>
/// 平台证书的详情
/// </summary>
public class Certificate
{
    /// <summary>
    /// 证书序列号
    /// 平台证书的主键，唯一定义此资源的标识
    /// </summary>
    [JsonPropertyName("serial_no")]
    public string SerialNo { get; set; }

    /// <summary>
    /// 证书启用时间
    /// 启用证书的时间，时间格式为RFC3339。每个平台证书的启用时间是固定的。
    /// </summary>
    [JsonPropertyName("effective_time")]
    public DateTimeOffset? EffectiveTime { get; set; }

    /// <summary>
    /// 证书弃用时间
    /// 弃用证书的时间，时间格式为RFC3339。更换平台证书前，会提前24小时修改老证书的弃用时间，接口返回新老两个平台证书。更换完成后，接口会返回最新的平台证书。
    /// </summary>
    [JsonPropertyName("expire_time")]
    public DateTimeOffset? ExpireTime { get; set; }

    /// <summary>
    /// 证书信息
    /// </summary>
    [JsonPropertyName("encrypt_certificate")]
    public EncryptCertificate EncryptCertificate { get; set; }
}
