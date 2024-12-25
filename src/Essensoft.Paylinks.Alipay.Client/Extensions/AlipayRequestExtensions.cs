using System.Net;
using System.Text;
using System.Text.Json;
using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Security;

namespace Essensoft.Paylinks.Alipay.Client.Extensions;

public static class AlipayRequestExtensions
{
    public static HttpRequestMessage CreateHttpRequestMessage<T>(this IAlipayRequest<T> request, string serverUrl, string appId, string appPrivateKey, string? alipayRootCertSN, string? appCertSN, string? appAuthToken, string? encryptType, string? encryptKey) where T : AlipayResponse
    {
        HttpRequestMessage httpRequest;

        var requestUri = request.GetRequestUrl();
        var requestMethod = request.GetRequestMethod();
        var httpMethod = request.GetHttpMethod();

        switch (requestMethod)
        {
            case AlipayRequestMethod.Get:
                {
                    var query = request.BuildQuery();
                    if (!string.IsNullOrEmpty(query))
                    {
                        requestUri += "?" + query;
                    }

                    var token = AlipaySignature.BuildToken(appId, appCertSN, httpMethod.Method, requestUri, null, appAuthToken, appPrivateKey);
                    var authorization = AlipaySignature.BuildAuthorization(AlipaySignatureTypes.ALIPAY_SHA256withRSA, token);

                    httpRequest = new HttpRequestMessage(httpMethod, serverUrl?.TrimEnd('/') + requestUri)
                    {
                        Headers = { { "Accept", "application/json" }, { "User-Agent", "Paylinks" } }
                    };

                    httpRequest.Headers.TryAddWithoutValidation("Authorization", authorization);
                }
                break;
            case AlipayRequestMethod.Post:
            case AlipayRequestMethod.Put:
            case AlipayRequestMethod.Delete:
            case AlipayRequestMethod.Head:
            case AlipayRequestMethod.Options:
            case AlipayRequestMethod.Patch:
                {
                    var query = request.BuildQuery();
                    if (!string.IsNullOrEmpty(query))
                    {
                        requestUri += "?" + query;
                    }

                    var body = request.BuildBody();
                    var isEncrypted = false;

                    if (request.GetNeedEncrypt() && !string.IsNullOrEmpty(encryptType) && !string.IsNullOrEmpty(encryptKey))
                    {
                        if (encryptType.Equals("AES", StringComparison.OrdinalIgnoreCase))
                        {
                            body = AES.Encrypt(body, encryptKey);
                            isEncrypted = true;
                        }
                        else
                        {
                            throw new AlipayException("不支持该加密方式: " + encryptType);
                        }
                    }

                    var token = AlipaySignature.BuildToken(appId, appCertSN, httpMethod.Method, requestUri, body, appAuthToken, appPrivateKey);
                    var authorization = AlipaySignature.BuildAuthorization(AlipaySignatureTypes.ALIPAY_SHA256withRSA, token);

                    httpRequest = new HttpRequestMessage(httpMethod, serverUrl?.TrimEnd('/') + requestUri)
                    {
                        Headers = { { "Accept", "application/json" }, { "User-Agent", "Paylinks" } }
                    };

                    if (isEncrypted)
                    {
                        httpRequest.Headers.Add("alipay-encrypt-type", encryptType);
                        httpRequest.Content = new StringContent(body, Encoding.UTF8, "text/plain");
                    }
                    else
                    {
                        httpRequest.Content = new StringContent(body, Encoding.UTF8, "application/json");
                    }

                    httpRequest.Headers.TryAddWithoutValidation("Authorization", authorization);
                }
                break;
            default:
                throw new AlipayException("不支持该请求方式: " + requestMethod);
        }

        if (!string.IsNullOrEmpty(alipayRootCertSN))
        {
            httpRequest.Headers.Add(AlipayHeaderNames.AlipayRootCertSN, alipayRootCertSN);
        }

        if (!string.IsNullOrEmpty(appAuthToken))
        {
            httpRequest.Headers.Add(AlipayHeaderNames.AlipayAppAuthToken, appAuthToken);
        }

        return httpRequest;
    }

    private static HttpMethod GetHttpMethod<T>(this IAlipayRequest<T> request) where T : AlipayResponse
    {
        var method = request.GetRequestMethod();
        return method switch
        {
            AlipayRequestMethod.Get => HttpMethod.Get,
            AlipayRequestMethod.Post => HttpMethod.Post,
            AlipayRequestMethod.Put => HttpMethod.Put,
            AlipayRequestMethod.Delete => HttpMethod.Delete,
            AlipayRequestMethod.Head => HttpMethod.Head,
            AlipayRequestMethod.Options => HttpMethod.Options,
            AlipayRequestMethod.Patch => HttpMethod.Patch,
            _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
        };
    }

    private static string BuildQuery<T>(this IAlipayRequest<T> request) where T : AlipayResponse
    {
        var queryModel = request.GetQueryModel();
        if (queryModel == null)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        var bytes = JsonSerializer.SerializeToUtf8Bytes(queryModel, queryModel.GetType(), AlipayJsonSerializerOptions.Default);
        var jsonElementDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(bytes);
        if (jsonElementDict != null)
        {
            foreach (var kv in jsonElementDict)
            {
                switch (kv.Value.ValueKind)
                {
                    case JsonValueKind.Object:
                    case JsonValueKind.Array:
                        sb.Append(kv.Key + "=" + WebUtility.UrlEncode(kv.Value.GetRawText()) + "&");
                        continue;
                    case JsonValueKind.String:
                    case JsonValueKind.Number:
                        sb.Append(kv.Key + "=" + WebUtility.UrlEncode(kv.Value.GetString()) + "&");
                        continue;
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                        sb.Append(kv.Key + "=" + WebUtility.UrlEncode(kv.Value.ToString().ToLowerInvariant()) + "&");
                        continue;
                    case JsonValueKind.Null:
                    case JsonValueKind.Undefined:
                    default:
                        continue;
                }
            }
        }

        return sb.Length > 0 ? sb.ToString()[..^1] : string.Empty;
    }

    private static string BuildBody<T>(this IAlipayRequest<T> request) where T : AlipayResponse
    {
        var bodyModel = request.GetBodyModel();
        if (bodyModel == null)
        {
            return string.Empty;
        }

        return JsonSerializer.Serialize(bodyModel, bodyModel.GetType(), AlipayJsonSerializerOptions.Default);
    }
}
