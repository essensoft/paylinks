using System.Security.Cryptography;
using System.Text;

namespace Essensoft.Paylinks.Security;

public static class SHA256WithRSA
{
    public static string Sign(string data, string privateKey)
    {
        if (string.IsNullOrEmpty(data))
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (string.IsNullOrEmpty(privateKey))
        {
            throw new ArgumentNullException(nameof(privateKey));
        }

        using var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
        return Convert.ToBase64String(rsa.SignData(Encoding.UTF8.GetBytes(data), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
    }

    public static bool Verify(string data, string sign, string publicKey)
    {
        if (string.IsNullOrEmpty(data))
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (string.IsNullOrEmpty(sign))
        {
            throw new ArgumentNullException(nameof(sign));
        }

        if (string.IsNullOrEmpty(publicKey))
        {
            throw new ArgumentNullException(nameof(publicKey));
        }

        using var rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out _);
        return rsa.VerifyData(Encoding.UTF8.GetBytes(data), Convert.FromBase64String(sign), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }
}
