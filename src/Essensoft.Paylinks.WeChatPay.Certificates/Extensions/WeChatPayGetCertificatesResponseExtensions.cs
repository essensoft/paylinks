using System.Security.Cryptography.X509Certificates;
using Essensoft.Paylinks.Security;
using Essensoft.Paylinks.WeChatPay.Certificates.Response;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Certificates.Extensions;

public static class WeChatPayGetCertificatesResponseExtensions
{
    /// <summary>
    /// 获取解密后的平台证书
    /// </summary>
    public static List<WeChatPayPlatformCertificate> GetWeChatPayDecryptedPlatformCertificates(this WeChatPayGetCertificatesResponse response, string APIv3Key)
    {
        ArgumentNullException.ThrowIfNull(response);

        var list = new List<WeChatPayPlatformCertificate>();

        if (response.Certificates != null)
        {
            foreach (var certificate in response.Certificates)
            {
                switch (certificate.EncryptCertificate.Algorithm)
                {
                    case WeChatPayEncryptionTypes.AEAD_AES_256_GCM:
                        {
                            var certStr = AEAD_AES_256_GCM.Decrypt(certificate.EncryptCertificate.Nonce, certificate.EncryptCertificate.Ciphertext, certificate.EncryptCertificate.AssociatedData!, APIv3Key);
                            var cert = X509Certificate2.CreateFromPem(certStr);
                            var publicKey = Convert.ToBase64String(cert.GetRSAPublicKey()!.ExportSubjectPublicKeyInfo());
                            list.Add(new WeChatPayPlatformCertificate(certificate.SerialNo, certificate.EffectiveTime, certificate.ExpireTime, cert, publicKey));
                        }
                        break;
                }
            }
        }

        return list;
    }
}
