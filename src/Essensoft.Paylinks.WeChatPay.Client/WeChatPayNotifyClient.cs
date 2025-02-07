using System.Text.Json;
using Essensoft.Paylinks.WeChatPay.Client.Extensions;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 通知客户端
/// </summary>
public class WeChatPayNotifyClient(IWeChatPayPlatformCertificateManagerFactory certificateManagerFactory) : IWeChatPayNotifyClient
{
    public Task<T> ExecuteAsync<T>(WeChatPayHeaders headers, string body, WeChatPayClientOptions options) where T : IWeChatPayNotifyResource
    {
        if (headers.Signature.StartsWith(WeChatPayConstants.SignTestPrefix)) // 签名探测流量
        {
            throw new WeChatPayException("验签失败: 签名探测流量");
        }

        // 验签
        string certPublicKey;

        if (headers.Serial.StartsWith(WeChatPayConstants.PublicKeyIdPrefix)) // 微信支付公钥
        {
            if (!string.IsNullOrEmpty(options.WeChatPayPublicKeyId) && !string.IsNullOrEmpty(options.WeChatPayPublicKey))
            {
                if (headers.Serial != options.WeChatPayPublicKeyId)
                {
                    throw new WeChatPayException("验签失败: 配置的微信支付公钥Id与通知公钥Id/应答公钥Id不一致");
                }

                certPublicKey = options.WeChatPayPublicKey;
            }
            else
            {
                throw new WeChatPayException("验签失败: 未配置微信支付公钥/微信支付公钥Id");
            }
        }
        else
        {
            var certificateManager = certificateManagerFactory.Create(options.MchId);
            var certificate = certificateManager.GetBySerialNo(headers.Serial) ?? throw new WeChatPayException("验签失败: 微信平台证书管理器中未找到有效平台证书");
            if (string.IsNullOrEmpty(certificate.PublicKey))
            {
                throw new WeChatPayException("验签失败: 平台证书公钥为空");
            }

            certPublicKey = certificate.PublicKey;
        }

        WeChatPaySignature.VerifySignature(headers, body, certPublicKey);

        // 反序列化通知
        var notify = JsonSerializer.Deserialize<WeChatPayNotify>(body, WeChatPayJsonSerializerOptions.Default);

        // 解密并且反序列化通知资源
        return Task.FromResult(notify!.GetWeChatPayDecryptedNotifyResource<T>(options.APIv3Key));
    }
}
