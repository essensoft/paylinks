using System.Text.Json;
using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Security;

namespace Essensoft.Paylinks.Alipay.Client.Extensions;

public static class AlipaySdkRequestExtensions
{
    public static IDictionary<string, string> BuildRequestParameter(this IAlipaySdkRequest request, string appId, string? appCertSN, string? rootCertSN, string? appAuthToken, string appPrivateKey, string? encryptType, string? encryptKey)
    {
        var sortedDict = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            { "method", request.GetMethod() },
            { "version", "1.0" },
            { "app_id", appId },
            { "format", "json" },
            { "timestamp", DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss") },
            { "charset", "UTF-8" },
            { "sign_type", "RSA2" }
        };

        if (!string.IsNullOrEmpty(appCertSN))
        {
            sortedDict.Add("app_cert_sn", appCertSN);
        }

        if (!string.IsNullOrEmpty(rootCertSN))
        {
            sortedDict.Add("alipay_root_cert_sn", rootCertSN);
        }

        if (!string.IsNullOrEmpty(appAuthToken))
        {
            sortedDict.Add("app_auth_token", appAuthToken);
        }

        var bizContent = request.BuildBizContent();
        if (request.GetNeedEncrypt() && !string.IsNullOrEmpty(encryptType) && !string.IsNullOrEmpty(encryptKey))
        {
            if (encryptType.Equals("AES", StringComparison.OrdinalIgnoreCase))
            {
                sortedDict.Add("encrypt_type", encryptType);
                sortedDict.Add("biz_content", AES.Encrypt(bizContent, encryptKey));
            }
            else
            {
                throw new AlipayException("不支持该加密方式: " + encryptType);
            }
        }
        else
        {
            sortedDict.Add("biz_content", bizContent);
        }

        var signatureSourceData = AlipaySignature.BuildSignatureSourceData(sortedDict);
        sortedDict.Add("sign", SHA256WithRSA.Sign(signatureSourceData, appPrivateKey));

        return sortedDict;
    }

    private static string BuildBizContent(this IAlipaySdkRequest request)
    {
        var bizModel = request.GetBizModel();
        return JsonSerializer.Serialize(bizModel, bizModel.GetType(), AlipayJsonSerializerOptions.Default);
    }
}
