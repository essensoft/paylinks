using System.Text.Json;
using Essensoft.Paylinks.Alipay.Client.Extensions;
using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Core.Utilities;
using Essensoft.Paylinks.Security;

namespace Essensoft.Paylinks.Alipay.Client;

/// <summary>
/// Alipay 客户端
/// </summary>
public class AlipayClient(IHttpClientFactory httpClientFactory) : IAlipayClient
{
    public const string HttpClientName = nameof(AlipayClient);

    public async Task<T> ExecuteAsync<T>(IAlipayRequest<T> request, AlipayClientOptions options, string? appAuthToken, CancellationToken cancellationToken = default) where T : AlipayResponse
    {
        var httpClient = httpClientFactory.CreateClient(HttpClientName);
        using var httpRequest = request.CreateHttpRequestMessage(options.ServerUrl, options.AppId, options.AppPrivateKey, options.AlipayRootCertSN, options.AppCertSN, appAuthToken, options.EncryptType, options.EncryptKey);
        using var httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

        var statusCode = httpResponse.StatusCode;
        var headers = httpResponse.GetAlipayHeaders();
        var content = await httpResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if (httpResponse.IsSuccessStatusCode)
        {
            if (request.GetNeedVerify())
            {
                // 验签
                AlipaySignature.VerifySignatureV2(headers, content, options.AlipayCertSN, options.AlipayPublicKey);
            }

            if (request.GetNeedEncrypt() && !string.IsNullOrEmpty(options.EncryptType) && !string.IsNullOrEmpty(options.EncryptKey))
            {
                // 解密
                if (options.EncryptType.Equals("AES", StringComparison.OrdinalIgnoreCase))
                {
                    content = AES.Decrypt(content, options.EncryptKey);
                }
                else
                {
                    throw new AlipayException("不支持该解密方式: " + options.EncryptType);
                }
            }

            var response = content.StartsWith('{') && content.EndsWith('}')
                ? JsonSerializer.Deserialize<T>(content, AlipayJsonSerializerOptions.Default)!
                : Activator.CreateInstance<T>();

            response.StatusCode = statusCode;
            response.Headers = headers;
            response.Body = content;
            return response;
        }
        else
        {
            var response = content.StartsWith('{') && content.EndsWith('}')
                ? JsonSerializer.Deserialize<T>(content, AlipayJsonSerializerOptions.Default)!
                : Activator.CreateInstance<T>();

            response.StatusCode = statusCode;
            response.Headers = headers;
            response.Body = content;
            return response;
        }
    }

    public Task<string> PageExecuteAsync(IAlipaySdkRequest request, AlipayClientOptions options, string? appAuthToken = null, string? reqMethod = null)
    {
        var reqUrl = options.ServerUrl?.TrimEnd('/') + "/gateway.do";
        var reqDict = request.BuildRequestParameter(options.AppId, options.AppCertSN, options.AlipayRootCertSN, appAuthToken, options.AppPrivateKey, options.EncryptType, options.EncryptKey);

        string reqContent;
        if (string.Equals("GET", reqMethod, StringComparison.OrdinalIgnoreCase))
        {
            reqContent = AlipayDictionaryUtilities.BuildRequestUrl(reqUrl, reqDict);
        }
        else
        {
            reqContent = AlipayDictionaryUtilities.BuildRequestForm(reqUrl, reqDict);
        }

        return Task.FromResult(reqContent);
    }

    public Task<string> SdkExecuteAsync(IAlipaySdkRequest request, AlipayClientOptions options, string? appAuthToken = null)
    {
        var reqDict = request.BuildRequestParameter(options.AppId, options.AppCertSN, options.AlipayRootCertSN, appAuthToken, options.AppPrivateKey, options.EncryptType, options.EncryptKey);
        var reqQuery = AlipayDictionaryUtilities.BuildQuery(reqDict);
        return Task.FromResult(reqQuery);
    }
}
