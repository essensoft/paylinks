using System.Text;
using Essensoft.Paylinks.WeChatPay.Core;
using Microsoft.AspNetCore.Http;

namespace Essensoft.Paylinks.WeChatPay.Mvc.Extensions;

public static class HttpRequestExtensions
{
    public static Task<WeChatPayHeaders> GetWeChatPayHeadersAsync(this HttpRequest request)
    {
        var requestId = request.Headers.TryGetValue(WeChatPayHeaderNames.RequestId, out var requestIdValues) ? requestIdValues.ToString() : string.Empty;
        var serial = request.Headers.TryGetValue(WeChatPayHeaderNames.WeChatPaySerial, out var serialValues) ? serialValues.ToString() : string.Empty;
        var timestamp = request.Headers.TryGetValue(WeChatPayHeaderNames.WeChatPayTimestamp, out var timestampValues) ? timestampValues.ToString() : string.Empty;
        var nonce = request.Headers.TryGetValue(WeChatPayHeaderNames.WeChatPayNonce, out var nonceValues) ? nonceValues.ToString() : string.Empty;
        var signature = request.Headers.TryGetValue(WeChatPayHeaderNames.WeChatPaySignature, out var signatureValues) ? signatureValues.ToString() : string.Empty;
        var signatureType = request.Headers.TryGetValue(WeChatPayHeaderNames.WeChatPaySignatureType, out var signatureTypeValues) ? signatureTypeValues.ToString() : string.Empty;
        return Task.FromResult(new WeChatPayHeaders(requestId, serial, timestamp, nonce, signature, signatureType));
    }

    public static async Task<string> GetWeChatPayBodyAsync(this HttpRequest request, bool detectEncodingFromByteOrderMarks = true, int bufferSize = 1024, bool leaveOpen = true, CancellationToken cancellationToken = default)
    {
        using var reader = new StreamReader(request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
        return await reader.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
    }
}
