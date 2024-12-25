using System.Security.Cryptography;
using System.Text;

namespace Essensoft.Paylinks.Security;

public static class AES
{
    private static readonly byte[] _iv = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

    public static string Encrypt(string plaintext, string key)
    {
        if (string.IsNullOrEmpty(plaintext))
        {
            throw new ArgumentNullException(nameof(plaintext));
        }

        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        using var aes = Aes.Create();
        aes.Key = Convert.FromBase64String(key);
        aes.IV = _iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var ctf = aes.CreateEncryptor();
        var content = Encoding.UTF8.GetBytes(plaintext);
        return Convert.ToBase64String(ctf.TransformFinalBlock(content, 0, content.Length));
    }

    public static string Decrypt(string ciphertext, string key)
    {
        if (string.IsNullOrEmpty(ciphertext))
        {
            throw new ArgumentNullException(nameof(ciphertext));
        }

        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        using var aes = Aes.Create();
        aes.Key = Convert.FromBase64String(key);
        aes.IV = _iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var ctf = aes.CreateDecryptor();
        var content = Convert.FromBase64String(ciphertext);
        return Encoding.UTF8.GetString(ctf.TransformFinalBlock(content, 0, content.Length));
    }
}
