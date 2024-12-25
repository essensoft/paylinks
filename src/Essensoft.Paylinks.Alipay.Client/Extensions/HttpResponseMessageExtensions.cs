using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Client.Extensions;

public static class HttpResponseMessageExtensions
{
    public static AlipayHeaders GetAlipayHeaders(this HttpResponseMessage response)
    {
        var timestamp = response.Headers.TryGetValues(AlipayHeaderNames.AlipayTimestamp, out var timestampIdValues) ? timestampIdValues.First() : string.Empty;
        var signature = response.Headers.TryGetValues(AlipayHeaderNames.AlipaySignature, out var signatureValues) ? signatureValues.First() : string.Empty;
        var sn = response.Headers.TryGetValues(AlipayHeaderNames.AlipaySN, out var snValues) ? snValues.First() : string.Empty;
        var traceId = response.Headers.TryGetValues(AlipayHeaderNames.AlipayTraceId, out var traceIdValues) ? traceIdValues.First() : string.Empty;
        var nonce = response.Headers.TryGetValues(AlipayHeaderNames.AlipayNonce, out var nonceValues) ? nonceValues.First() : string.Empty;
        return new AlipayHeaders(timestamp, signature, sn, traceId, nonce);
    }
}
