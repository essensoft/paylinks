using System.Net;
using System.Text;
using System.Text.Json;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Client.Extensions;

public static class WeChatPayRequestExtensions
{
    public static HttpRequestMessage CreateHttpRequestMessage<T>(this IWeChatPayRequest<T> request, string serverUrl, string mchId, string serialNo, string privateKey, string? certSerialNo) where T : WeChatPayResponse
    {
        HttpRequestMessage httpRequest;

        var requestUri = request.GetRequestUrl();
        var requestMethod = request.GetRequestMethod();
        var httpMethod = request.GetHttpMethod();

        switch (requestMethod)
        {
            case WeChatPayRequestMethod.Get:
                {
                    var query = request.BuildQuery();
                    if (!string.IsNullOrEmpty(query))
                    {
                        requestUri += "?" + query;
                    }

                    var token = WeChatPaySignature.BuildToken(requestUri, httpMethod.Method, null, mchId, serialNo, privateKey);
                    var authorization = WeChatPaySignature.BuildAuthorization(WeChatPaySignatureTypes.WECHATPAY2_SHA256_RSA2048, token);

                    httpRequest = new HttpRequestMessage(httpMethod, serverUrl?.TrimEnd('/') + requestUri)
                    {
                        Headers = { { "Accept", "application/json" }, { "User-Agent", "Paylinks" }, }
                    };
                    httpRequest.Headers.TryAddWithoutValidation("Authorization", authorization);
                }
                break;
            case WeChatPayRequestMethod.Post:
            case WeChatPayRequestMethod.Put:
            case WeChatPayRequestMethod.Delete:
            case WeChatPayRequestMethod.Patch:
                {
                    var query = request.BuildQuery();
                    if (!string.IsNullOrEmpty(query))
                    {
                        requestUri += "?" + query;
                    }

                    var body = request.BuildBody();
                    var token = WeChatPaySignature.BuildToken(requestUri, httpMethod.Method, body, mchId, serialNo, privateKey);
                    var authorization = WeChatPaySignature.BuildAuthorization(WeChatPaySignatureTypes.WECHATPAY2_SHA256_RSA2048, token);

                    httpRequest = new HttpRequestMessage(httpMethod, serverUrl?.TrimEnd('/') + requestUri)
                    {
                        Headers = { { "Accept", "application/json" }, { "User-Agent", "Paylinks" } },
                        Content = new StringContent(body, Encoding.UTF8, "application/json")
                    };
                    httpRequest.Headers.TryAddWithoutValidation("Authorization", authorization);
                }
                break;
            default:
                throw new WeChatPayException("不支持该请求方式: " + requestMethod);
        }

        if (!string.IsNullOrEmpty(certSerialNo))
        {
            httpRequest.Headers.Add(WeChatPayHeaderNames.WeChatPaySerial, certSerialNo);
        }

        return httpRequest;
    }

    private static HttpMethod GetHttpMethod<T>(this IWeChatPayRequest<T> request) where T : WeChatPayResponse
    {
        var requestMethod = request.GetRequestMethod();
        return requestMethod switch
        {
            WeChatPayRequestMethod.Get => HttpMethod.Get,
            WeChatPayRequestMethod.Post => HttpMethod.Post,
            WeChatPayRequestMethod.Put => HttpMethod.Put,
            WeChatPayRequestMethod.Delete => HttpMethod.Delete,
            WeChatPayRequestMethod.Patch => HttpMethod.Patch,
            _ => throw new ArgumentOutOfRangeException(nameof(requestMethod), requestMethod, null)
        };
    }

    private static string BuildQuery<T>(this IWeChatPayRequest<T> request) where T : WeChatPayResponse
    {
        var queryModel = request.GetQueryModel();
        if (queryModel == null)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        var bytes = JsonSerializer.SerializeToUtf8Bytes(queryModel, queryModel.GetType(), WeChatPayJsonSerializerOptions.Default);
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

    private static string BuildBody<T>(this IWeChatPayRequest<T> request) where T : WeChatPayResponse
    {
        var bodyModel = request.GetBodyModel();
        if (bodyModel == null)
        {
            return string.Empty;
        }

        return JsonSerializer.Serialize(bodyModel, bodyModel.GetType(), WeChatPayJsonSerializerOptions.Default);
    }
}
