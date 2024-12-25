using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Client.Extensions;

public static class HttpResponseMessageExtensions
{
    public static WeChatPayHeaders GetWeChatPayHeaders(this HttpResponseMessage response)
    {
        var requestId = response.Headers.TryGetValues(WeChatPayHeaderNames.RequestId, out var requestIdValues) ? requestIdValues.First() : string.Empty;
        var serial = response.Headers.TryGetValues(WeChatPayHeaderNames.WeChatPaySerial, out var serialValues) ? serialValues.First() : string.Empty;
        var timestamp = response.Headers.TryGetValues(WeChatPayHeaderNames.WeChatPayTimestamp, out var timestampValues) ? timestampValues.First() : string.Empty;
        var nonce = response.Headers.TryGetValues(WeChatPayHeaderNames.WeChatPayNonce, out var nonceValues) ? nonceValues.First() : string.Empty;
        var signature = response.Headers.TryGetValues(WeChatPayHeaderNames.WeChatPaySignature, out var signatureValues) ? signatureValues.First() : string.Empty;
        var signatureType = response.Headers.TryGetValues(WeChatPayHeaderNames.WeChatPaySignatureType, out var signatureTypeValues) ? signatureTypeValues.First() : string.Empty;
        return new WeChatPayHeaders(requestId, serial, timestamp, nonce, signature, signatureType);
    }
}
