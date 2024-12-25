using System.Security.Cryptography;
using System.Text;

namespace Essensoft.Paylinks.Security;

public static class AEAD_AES_256_GCM
{
    private const int TagSize = 16;

    public static string Encrypt(string nonce, string plaintext, string associatedData, string key)
    {
        if (string.IsNullOrEmpty(nonce))
        {
            throw new ArgumentNullException(nameof(nonce));
        }

        if (string.IsNullOrEmpty(plaintext))
        {
            throw new ArgumentNullException(nameof(plaintext));
        }

        if (string.IsNullOrEmpty(associatedData))
        {
            throw new ArgumentNullException(nameof(associatedData));
        }

        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        var keyBytes = Encoding.UTF8.GetBytes(key);
        using var aesGcm = new AesGcm(keyBytes, TagSize);
        var nonceBytes = Encoding.UTF8.GetBytes(nonce);
        var plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
        var tagBytes = new byte[16];
        Random.Shared.NextBytes(tagBytes);
        var ciphertextBytes = new byte[plaintextBytes.Length];
        var associatedDataBytes = Encoding.UTF8.GetBytes(associatedData);
        aesGcm.Encrypt(nonceBytes, plaintextBytes, ciphertextBytes, tagBytes, associatedDataBytes);
        return Convert.ToBase64String(ciphertextBytes.Concat(tagBytes).ToArray()); // ciphertext 应当包含 tag
    }

    public static string Decrypt(string nonce, string ciphertext, string associatedData, string key)
    {
        if (string.IsNullOrEmpty(nonce))
        {
            throw new ArgumentNullException(nameof(nonce));
        }

        if (string.IsNullOrEmpty(ciphertext))
        {
            throw new ArgumentNullException(nameof(ciphertext));
        }

        if (string.IsNullOrEmpty(associatedData))
        {
            throw new ArgumentNullException(nameof(associatedData));
        }

        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        var keyBytes = Encoding.UTF8.GetBytes(key);
        using var aesGcm = new AesGcm(keyBytes, TagSize);
        var nonceBytes = Encoding.UTF8.GetBytes(nonce);
        var ciphertextWithTagBytes = Convert.FromBase64String(ciphertext); // ciphertext 包含了 tag，即尾部16字节
        var ciphertextBytes = ciphertextWithTagBytes[..^TagSize];
        var tagBytes = ciphertextWithTagBytes[^TagSize..];
        var plaintextBytes = new byte[ciphertextBytes.Length];
        var associatedDataBytes = Encoding.UTF8.GetBytes(associatedData);
        aesGcm.Decrypt(nonceBytes, ciphertextBytes, tagBytes, plaintextBytes, associatedDataBytes);
        return Encoding.UTF8.GetString(plaintextBytes);
    }
}
