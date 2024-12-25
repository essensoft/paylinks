using System.Text.Json;
using Essensoft.Paylinks.WeChatPay.Client.Extensions;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 客户端
/// </summary>
public class WeChatPayClient(IHttpClientFactory httpClientFactory, IWeChatPayPlatformCertificateManagerFactory certificateManagerFactory) : IWeChatPayClient
{
    public const string HttpClientName = nameof(WeChatPayClient);

    public async Task<T> ExecuteAsync<T>(IWeChatPayRequest<T> request, WeChatPayClientOptions options, CancellationToken cancellationToken = default) where T : WeChatPayResponse
    {
        string? certSerialNo = null;

        if (request is IWeChatPaySecretRequest<T> secretRequest)
        {
            // 加密敏感信息
            string certPublicKey;

            if (!string.IsNullOrEmpty(options.WeChatPayPublicKeyId) && !string.IsNullOrEmpty(options.WeChatPayPublicKey))
            {
                certSerialNo = options.WeChatPayPublicKeyId;
                certPublicKey = options.WeChatPayPublicKey;
            }
            else
            {
                var certificateManager = certificateManagerFactory.Create(options.MchId);
                var certificate = certificateManager.GetAvailableCertificates().OrderByDescending(c => c.EffectiveTime).FirstOrDefault() ?? throw new WeChatPayException("验签失败: 微信平台证书管理器中未找到有效平台证书");
                if (string.IsNullOrEmpty(certificate.PublicKey))
                {
                    throw new WeChatPayException("验签失败: 平台证书公钥为空");
                }

                certSerialNo = certificate.SerialNo;
                certPublicKey = certificate.PublicKey;
            }

            secretRequest.EncryptSecretRequest(certPublicKey);
        }

        var httpClient = httpClientFactory.CreateClient(HttpClientName);
        using var httpRequest = request.CreateHttpRequestMessage(options.ServerUrl, options.MchId, options.MchSerialNo, options.MchPrivateKey, certSerialNo);
        using var httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

        var statusCode = httpResponse.StatusCode;
        var headers = httpResponse.GetWeChatPayHeaders();
        var content = await httpResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if (httpResponse.IsSuccessStatusCode)
        {
            if (request.GetNeedVerify())
            {
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

                WeChatPaySignature.VerifySignature(headers, content, certPublicKey);
            }

            var response = content.StartsWith('{') && content.EndsWith('}')
                ? JsonSerializer.Deserialize<T>(content, WeChatPayJsonSerializerOptions.Default)!
                : Activator.CreateInstance<T>();

            if (response is IWeChatPaySecretResponse secretResponse)
            {
                // 解密敏感信息
                secretResponse.DecryptSecretResponse(options.MchPrivateKey);
            }

            response.StatusCode = statusCode;
            response.Headers = headers;
            response.Body = content;
            return response;
        }
        else
        {
            var response = content.StartsWith('{') && content.EndsWith('}')
                ? JsonSerializer.Deserialize<T>(content, WeChatPayJsonSerializerOptions.Default)!
                : Activator.CreateInstance<T>();

            response.StatusCode = statusCode;
            response.Headers = headers;
            response.Body = content;
            return response;
        }
    }

    public Task<T> SdkExecuteAsync<T>(IWeChatPaySdkRequest<T> request, WeChatPayClientOptions options) where T : WeChatPaySdkResponse
    {
        return Task.FromResult(request.SignatureHandler(options.MchPrivateKey));
    }
}
