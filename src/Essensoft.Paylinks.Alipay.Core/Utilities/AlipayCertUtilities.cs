using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MD5 = Essensoft.Paylinks.Security.MD5;

namespace Essensoft.Paylinks.Alipay.Core.Utilities;

/// <summary>
/// Alipay 证书工具类
/// </summary>
public static class AlipayCertUtilities
{
    /// <summary>
    /// PKCS#8证书私钥转换PKCS#1证书私钥
    /// </summary>
    /// <param name="cert">PKCS#8证书私钥</param>
    public static string ConvertCertPrivateKey(string certPrivateKey)
    {
        using var rsa = RSA.Create();
        rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(certPrivateKey), out _);
        return Convert.ToBase64String(rsa.ExportRSAPrivateKey());
    }

    /// <summary>
    /// 提取根证书序列号
    /// </summary>
    /// <param name="rootCert">根证书</param>
    public static string GetRootCertSN(string rootCert)
    {
        var certCollection = new X509Certificate2Collection();
        if (File.Exists(rootCert))
        {
            certCollection.ImportFromPemFile(rootCert);
        }
        else
        {
            certCollection.ImportFromPem(rootCert);
        }

        var sb = new StringBuilder();

        foreach (var cert in certCollection)
        {
            if (cert.GetKeyAlgorithm() != "1.2.840.113549.1.1.1") // RSA
            {
                continue;
            }

            var certSN = GetCertSN(cert);

            if (sb.Length > 0)
            {
                sb.Append('_');
            }

            sb.Append(certSN);
        }

        return sb.ToString();
    }

    /// <summary>
    /// 计算指定证书的序列号
    /// </summary>
    /// <param name="cert">证书</param>
    public static string GetCertSN(string cert)
    {
        var certificate2 = File.Exists(cert) ? X509Certificate2.CreateFromPemFile(cert) : X509Certificate2.CreateFromPem(cert);
        return GetCertSN(certificate2);
    }

    /// <summary>
    /// 获取证书公钥
    /// </summary>
    /// <param name="cert">证书</param>
    public static string GetCertPublicKey(string cert)
    {
        var certificate2 = File.Exists(cert) ? X509Certificate2.CreateFromPemFile(cert) : X509Certificate2.CreateFromPem(cert);
        return Convert.ToBase64String(certificate2.GetRSAPublicKey()!.ExportSubjectPublicKeyInfo());
    }

    /// <summary>
    /// 计算指定证书的序列号
    /// </summary>
    /// <param name="cert">证书</param>
    private static string GetCertSN(X509Certificate2 cert)
    {
        // 10进制的序列号
        var serialNumber = BigInteger.Parse(cert.SerialNumber, NumberStyles.HexNumber).ToString();

        // 删除逗号后面的空格
        var issuer = cert.Issuer.Replace(", ", ",");

        // issuer不以"CN"开头，则需要反转顺序
        if (!issuer.StartsWith("CN", StringComparison.OrdinalIgnoreCase))
        {
            issuer = string.Join(',', issuer.Split(',').Reverse());
        }

        return MD5.ComputeHash(issuer + serialNumber).ToLowerInvariant();
    }
}
