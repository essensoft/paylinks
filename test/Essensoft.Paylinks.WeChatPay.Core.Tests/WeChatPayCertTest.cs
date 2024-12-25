using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Essensoft.Paylinks.WeChatPay.Core.Utilities;
using Shouldly;
using Xunit;

namespace Essensoft.Paylinks.WeChatPay.Core.Tests;

public class WeChatPayCertTest
{
    [Fact]
    public void VerifyCertificateChain_Test()
    {
        var rootCert1 = GenerateRootCertificate("My Root CA", 2048, 10);
        var childCert1 = GenerateEndEntityCertificate(rootCert1, "My Child Certificate", 2048, 5);
        var rootCert2 = GenerateRootCertificate("My Root CA", 2048, 10);
        var childCert2 = GenerateEndEntityCertificate(rootCert2, "My Child Certificate", 2048, 5);
        WeChatPayCertUtilities.VerifyCertificateChain(new X509Certificate2Collection(rootCert1), childCert2).ShouldBeFalse();
        WeChatPayCertUtilities.VerifyCertificateChain(new X509Certificate2Collection(rootCert2), childCert1).ShouldBeFalse();
        WeChatPayCertUtilities.VerifyCertificateChain(new X509Certificate2Collection(rootCert1), childCert1).ShouldBeTrue();
        WeChatPayCertUtilities.VerifyCertificateChain(new X509Certificate2Collection(rootCert2), childCert2).ShouldBeTrue();
    }

    private static X509Certificate2 GenerateRootCertificate(string subjectName, int keySize, int yearsValid)
    {
        using var rsa = RSA.Create(keySize);
        var request = new CertificateRequest($"CN={subjectName}", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        request.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.CrlSign | X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.DigitalSignature, true));
        var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(yearsValid));
        return certificate;
    }

    private static X509Certificate2 GenerateEndEntityCertificate(X509Certificate2 issuerCert, string subjectName, int keySize, int yearsValid)
    {
        using var rsa = RSA.Create(keySize);
        var request = new CertificateRequest($"CN={subjectName}", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        var serialNumber = new byte[16];
        Random.Shared.NextBytes(serialNumber);
        var certificate = request.Create(issuerCert, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(yearsValid), serialNumber);
        return certificate;
    }
}
