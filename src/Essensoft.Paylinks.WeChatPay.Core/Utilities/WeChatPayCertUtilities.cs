using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Essensoft.Paylinks.WeChatPay.Core.Utilities;

/// <summary>
/// WeChatPay 证书工具类
/// </summary>
public static class WeChatPayCertUtilities
{
    /// <summary>
    /// PKCS#8证书私钥转换PKCS#1证书私钥
    /// </summary>
    /// <param name="cert">PKCS#8证书私钥</param>
    public static string ConvertCertPrivateKey(string certPrivateKey)
    {
        using var rsa = RSA.Create();
        rsa.ImportFromPem(certPrivateKey);
        return Convert.ToBase64String(rsa.ExportRSAPrivateKey());
    }

    /// <summary>
    /// 通过证书信任链验证平台证书
    /// </summary>
    /// <param name="certTrustChain">证书信任链</param>
    /// <param name="cert">证书</param>
    public static bool VerifyCertificateChain(X509Certificate2Collection certTrustChain, X509Certificate2 cert)
    {
        using var chain = new X509Chain();

        chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        chain.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;
        chain.ChainPolicy.CustomTrustStore.AddRange(certTrustChain);

        return chain.Build(cert);
    }
}
