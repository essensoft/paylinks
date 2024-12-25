using System.Security.Cryptography;
using Shouldly;
using Xunit;

namespace Essensoft.Paylinks.Security.Tests;

public class SHA256WithRSA_Test
{
    [Fact]
    public void Sign_Verify_SHA256WithRSA_Test()
    {
        using var rsa = RSA.Create();
        var publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
        var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
        var data = Guid.NewGuid().ToString("N");
        var sign = SHA256WithRSA.Sign(data, privateKey);
        SHA256WithRSA.Verify(data, sign, publicKey).ShouldBeTrue();
    }
}
