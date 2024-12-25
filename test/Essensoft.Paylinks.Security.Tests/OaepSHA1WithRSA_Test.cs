using System.Security.Cryptography;
using Shouldly;
using Xunit;

namespace Essensoft.Paylinks.Security.Tests;

public class OaepSHA1WithRSA_Test
{
    [Fact]
    public void Encrypt_Decrypt_RSAES_OAEP_Test()
    {
        using var rsa = RSA.Create();
        var publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
        var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
        var data = Guid.NewGuid().ToString("N");
        var ciphertext = OaepSHA1WithRSA.Encrypt(data, publicKey);
        ciphertext.ShouldNotBe(data);
        var plaintext = OaepSHA1WithRSA.Decrypt(ciphertext, privateKey);
        plaintext.ShouldBe(data);
    }
}
