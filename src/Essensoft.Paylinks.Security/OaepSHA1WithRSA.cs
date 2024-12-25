using System.Security.Cryptography;
using System.Text;

namespace Essensoft.Paylinks.Security;

public static class OaepSHA1WithRSA
{
    public static string Encrypt(string plaintext, string publicKey)
    {
        if (string.IsNullOrEmpty(plaintext))
        {
            throw new ArgumentNullException(nameof(plaintext));
        }

        if (string.IsNullOrEmpty(publicKey))
        {
            throw new ArgumentNullException(nameof(publicKey));
        }

        using var rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out _);
        return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), RSAEncryptionPadding.OaepSHA1));
    }

    public static string Decrypt(string ciphertext, string privateKey)
    {
        if (string.IsNullOrEmpty(ciphertext))
        {
            throw new ArgumentNullException(nameof(ciphertext));
        }

        if (string.IsNullOrEmpty(privateKey))
        {
            throw new ArgumentNullException(nameof(privateKey));
        }

        using var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
        return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(ciphertext), RSAEncryptionPadding.OaepSHA1));
    }
}
