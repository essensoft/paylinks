using System.Security.Cryptography.X509Certificates;
using Essensoft.Paylinks.WeChatPay.Certificates.Extensions;
using Essensoft.Paylinks.WeChatPay.Certificates.Request;
using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Core.Utilities;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Services;

/// <summary>
/// 微信支付后台服务
/// 定时更新微信支付平台证书（12小时）。
/// </summary>
public class WeChatPayBackgroundService(
    ILogger<WeChatPayBackgroundService> logger,
    IWeChatPayClient client,
    IWeChatPayPlatformCertificateManagerFactory certificateManagerFactory,
    IOptions<PaylinksOptions> options) : BackgroundService
{
    private readonly PaylinksOptions _options = options.Value;

    // 如何通过证书信任链验证平台证书？https://pay.weixin.qq.com/doc/v3/merchant/4012072597
    // 微信支付平台证书信任链: https://wx.gtimg.com/mch/files/CertTrustChain.p7b
    private const string WeChatPayRootCertPem = """
        subject=/C=CN/O=Tenpay.com/OU=Tenpay.com CA Center/CN=Tenpay.com Root CA
        issuer=/C=CN/O=iTrusChina/OU=China Trust Network/CN=iTrusChina Class 2 Enterprise CA - G3
        -----BEGIN CERTIFICATE-----
        MIIEcDCCA1igAwIBAgIUG9QiDlDbwEsGrTl1SYRsAcPo69IwDQYJKoZIhvcNAQEL
        BQAwcDELMAkGA1UEBhMCQ04xEzARBgNVBAoMCmlUcnVzQ2hpbmExHDAaBgNVBAsM
        E0NoaW5hIFRydXN0IE5ldHdvcmsxLjAsBgNVBAMMJWlUcnVzQ2hpbmEgQ2xhc3Mg
        MiBFbnRlcnByaXNlIENBIC0gRzMwHhcNMTcwODA5MDkxNTU1WhcNMzIwODA5MDkx
        NTU1WjBeMQswCQYDVQQGEwJDTjETMBEGA1UEChMKVGVucGF5LmNvbTEdMBsGA1UE
        CxMUVGVucGF5LmNvbSBDQSBDZW50ZXIxGzAZBgNVBAMTElRlbnBheS5jb20gUm9v
        dCBDQTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALvnPD6k39BdPYAH
        +6lnWPjuHH+2pcmZUf2E8cNFQFNr+ECRZylYV2iKyItCQt3I2/7VIDZl6aR9TE7n
        sZrtSmOXCw635QOrq2yF9LTSDotAhf3ER0+216w3age/VzGcNVQpTf6gRCHCuQIk
        8pe/oh06JagGvX0wERa+I6NfuG58ZHQY9d6RqLXKQl0Up95v73HDsG487z8k6jcn
        qpGngmHQxdWiWRJugqxNRUD+awv2/DUsqGOffPX4jzJ6rLSJSlQXvuniDYxmaiaD
        cK0bUbB5aM+1zMwogoHSYxWj/6B+vgcnHQCUrwGdiQR5+F+yRWzy5bO09IzaFgeO
        PNPLPOsCAwEAAaOCARIwggEOMBIGA1UdEwEB/wQIMAYBAf8CAQAwDgYDVR0PAQH/
        BAQDAgEGMCAGA1UdEQQZMBekFTATMREwDwYDVQQDDAhzd2JlLTI2NjAdBgNVHQ4E
        FgQUTFo4GLdm9oHX52HcWnzuL4tui2gwHwYDVR0jBBgwFoAUK1vVxWgI69vN5LA5
        MqJf/8dPmEUwRgYDVR0gBD8wPTA7BgoqgRyG7xcBAQECMC0wKwYIKwYBBQUHAgEW
        H2h0dHBzOi8vd3d3Lml0cnVzLmNvbS5jbi9jdG5jcHMwPgYDVR0fBDcwNTAzoDGg
        L4YtaHR0cDovL3RvcGNhLml0cnVzLmNvbS5jbi9jcmwvaXRydXNjMmNhZzMuY3Js
        MA0GCSqGSIb3DQEBCwUAA4IBAQBwZhL/eiOQmMyo1D0IR9mu1DPWl5J3XXhjc4R6
        mFgsN/FCeVP9M4U9y2FJH6i5Ha5YCecKGw5pwhA0rjZr/6okWwo22GF+nzI/gQiz
        6ugAKs5VjFbeiEb04Ncz4HT8FP1idK3tyCjqCUTkLNt0U3tR7wy26hgOqlT2wCZ9
        X4MfT8dUMdt9nCZx4ujN5yZOzaLOCHmzoGDGxgKg91bbu0TG2Yzd2ylhrxxRtFH9
        aZ/J1x5UoF7uwhTM8P92DuAldWC1/bX1kciOtQvQEZeAy+9y/1BtFxoBnmDxnqkX
        +lirIUYTLDaL7HaLrOLECUlaxZCU/Nkwm3tmqQxtCh+XQBdd
        -----END CERTIFICATE-----

        subject=/C=CN/O=iTrusChina/OU=China Trust Network/CN=iTrusChina Class 2 Root CA - G3
        issuer=/C=CN/O=iTrusChina/OU=China Trust Network/CN=iTrusChina Class 2 Root CA - G3
        -----BEGIN CERTIFICATE-----
        MIIDxTCCAq2gAwIBAgIUEMdk6dVgOEIS2cCP0Q43P90Ps5YwDQYJKoZIhvcNAQEF
        BQAwajELMAkGA1UEBhMCQ04xEzARBgNVBAoMCmlUcnVzQ2hpbmExHDAaBgNVBAsM
        E0NoaW5hIFRydXN0IE5ldHdvcmsxKDAmBgNVBAMMH2lUcnVzQ2hpbmEgQ2xhc3Mg
        MiBSb290IENBIC0gRzMwHhcNMTMwNDE4MDkzNjU2WhcNMzMwNDE4MDkzNjU2WjBq
        MQswCQYDVQQGEwJDTjETMBEGA1UECgwKaVRydXNDaGluYTEcMBoGA1UECwwTQ2hp
        bmEgVHJ1c3QgTmV0d29yazEoMCYGA1UEAwwfaVRydXNDaGluYSBDbGFzcyAyIFJv
        b3QgQ0EgLSBHMzCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAOPPShpV
        nJbMqqCw6Bz1kehnoPst9pkr0V9idOwU2oyS47/HjJXk9Rd5a9xfwkPO88trUpz5
        4GmmwspDXjVFu9L0eFaRuH3KMha1Ak01citbF7cQLJlS7XI+tpkTGHEY5pt3EsQg
        wykfZl/A1jrnSkspMS997r2Gim54cwz+mTMgDRhZsKK/lbOeBPpWtcFizjXYCqhw
        WktvQfZBYi6o4sHCshnOswi4yV1p+LuFcQ2ciYdWvULh1eZhLxHbGXyznYHi0dGN
        z+I9H8aXxqAQfHVhbdHNzi77hCxFjOy+hHrGsyzjrd2swVQ2iUWP8BfEQqGLqM1g
        KgWKYfcTGdbPB1MCAwEAAaNjMGEwHQYDVR0OBBYEFG/oAMxTVe7y0+408CTAK8hA
        uTyRMB8GA1UdIwQYMBaAFG/oAMxTVe7y0+408CTAK8hAuTyRMA8GA1UdEwEB/wQF
        MAMBAf8wDgYDVR0PAQH/BAQDAgEGMA0GCSqGSIb3DQEBBQUAA4IBAQBLnUTfW7hp
        emMbuUGCk7RBswzOT83bDM6824EkUnf+X0iKS95SUNGeeSWK2o/3ALJo5hi7GZr3
        U8eLaWAcYizfO99UXMRBPw5PRR+gXGEronGUugLpxsjuynoLQu8GQAeysSXKbN1I
        UugDo9u8igJORYA+5ms0s5sCUySqbQ2R5z/GoceyI9LdxIVa1RjVX8pYOj8JFwtn
        DJN3ftSFvNMYwRuILKuqUYSHc2GPYiHVflDh5nDymCMOQFcFG3WsEuB+EYQPFgIU
        1DHmdZcz7Llx8UOZXX2JupWCYzK1XhJb+r4hK5ncf/w8qGtYlmyJpxk3hr1TfUJX
        Yf4Zr0fJsGuv
        -----END CERTIFICATE-----

        subject=/C=CN/O=iTrusChina/OU=China Trust Network/CN=iTrusChina Class 2 Enterprise CA - G3
        issuer=/C=CN/O=iTrusChina/OU=China Trust Network/CN=iTrusChina Class 2 Root CA - G3
        -----BEGIN CERTIFICATE-----
        MIIEWzCCA0OgAwIBAgIUXebgKKreiIUWpld7APPGQeaeEzEwDQYJKoZIhvcNAQEF
        BQAwajELMAkGA1UEBhMCQ04xEzARBgNVBAoMCmlUcnVzQ2hpbmExHDAaBgNVBAsM
        E0NoaW5hIFRydXN0IE5ldHdvcmsxKDAmBgNVBAMMH2lUcnVzQ2hpbmEgQ2xhc3Mg
        MiBSb290IENBIC0gRzMwHhcNMTMwNDE4MDk0NDE3WhcNMzMwNDE3MDk0NDE3WjBw
        MQswCQYDVQQGEwJDTjETMBEGA1UECgwKaVRydXNDaGluYTEcMBoGA1UECwwTQ2hp
        bmEgVHJ1c3QgTmV0d29yazEuMCwGA1UEAwwlaVRydXNDaGluYSBDbGFzcyAyIEVu
        dGVycHJpc2UgQ0EgLSBHMzCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEB
        AL2hymJqz9ASXoYSuCCNZi4/q/FWnOcnNkk0jgDTmwsXa+vr6f/c2gbRAehBu1Uh
        1m9N/yp4Enxzf5EPh1yTTQ7042PJfh8I5x+I6A64xYN4qGPlYnl8gmP/0+fTDejJ
        vPtM59k83rhGQsZzyp9rMiaUphHbFEr6ZWWrCg1SADP6NlP3P90wOmBviE12yGsv
        JZF1HOaTSKuSWDGZPZq8RO+q9lfhlOHi0Ht7V+hnuxCOgN/PWhvoh0KpHhPi0OKn
        6/RIZObZqMBqngPEUHXZfkzIQo6KEUvvWduvOC6P5hPpbAr0+xvE2WFORyRyL52W
        8bfkc8/QzdxxCa9RVpzRuFcCAwEAAaOB8jCB7zAPBgNVHRMBAf8EBTADAQH/MA4G
        A1UdDwEB/wQEAwIBBjAdBgNVHQ4EFgQUK1vVxWgI69vN5LA5MqJf/8dPmEUwHwYD
        VR0jBBgwFoAUb+gAzFNV7vLT7jTwJMAryEC5PJEwRgYDVR0gBD8wPTA7BgoqgRyG
        7xcBAQECMC0wKwYIKwYBBQUHAgEWH2h0dHBzOi8vd3d3Lml0cnVzLmNvbS5jbi9j
        dG5jcHMwRAYDVR0fBD0wOzA5oDegNYYzaHR0cDovL2ljYS1wdWJsaWMuaXRydXMu
        Y29tLmNuL2NybC9pdHJ1c2MycmNhZzMuY3JsMA0GCSqGSIb3DQEBBQUAA4IBAQA3
        WmfVeOre6edXZmsq1RXYAoJf/is70tRqJKato6KpOHkmGmo/+btAJ9JqKYSciOoq
        7OkAuQugkA9BoMLZkaGhvPIYuRqQmDcpLEvVS5L5acKKlQiRmyLKXtmZmBUP0Dxd
        SAbF9CG45abr226WQ9Yx+I5RjW0BMDZUBOHL+x8oOy3Sw5aqWznbPyNbCKFtJ0pV
        n0rx0BtfpRdnuew0cshfNOGn05N7W5YmYD1S6gbVQt5VZL9fAXphYlM12rlSaDiB
        NdM0hSb43laYFyH9bnMJxZDqcEQ/YwZZ0nfRfvRXx+s/8kvHmZPgmx9sGGfCx2AZ
        RCQzBAe4s75o8F08GgkU
        -----END CERTIFICATE-----

        
        """;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var certTrustChain = new X509Certificate2Collection();
        certTrustChain.ImportFromPem(WeChatPayRootCertPem);

        while (!stoppingToken.IsCancellationRequested)
        {
            if (string.IsNullOrEmpty(_options.WeChatPay.MchId) ||
                string.IsNullOrEmpty(_options.WeChatPay.MchSerialNo) ||
                string.IsNullOrEmpty(_options.WeChatPay.MchPrivateKey))
            {
                logger.LogError("未配置微信支付客户端选项，微信支付后台服务取消。");
                break;
            }

            try
            {
                var certificateManager = certificateManagerFactory.Create(_options.WeChatPay.MchId);

                // 移除所有无效证书
                certificateManager.RemoveUnavailableCertificates();

                // 下载平台证书请求
                var request = new WeChatPayGetCertificatesRequest();

                // 无有效平台证书时，不需要验签。
                if (!certificateManager.GetAvailableCertificates().Any())
                {
                    request.SetNeedVerify(false);
                }

                // 执行请求
                var response = await client.ExecuteAsync(request, _options.WeChatPay, stoppingToken);
                if (response.IsSuccessful)
                {
                    // 获取解密后的平台证书
                    foreach (var certificate in response.GetWeChatPayDecryptedPlatformCertificates(_options.WeChatPay.APIv3Key))
                    {
                        // 跳过已存在的证书
                        if (certificateManager.GetBySerialNo(certificate.SerialNo) != null)
                        {
                            continue;
                        }

                        // 证书信任链验证平台证书
                        if (WeChatPayCertUtilities.VerifyCertificateChain(certTrustChain, certificate.Certificate))
                        {
                            certificateManager.Add(certificate);
                            logger.LogInformation($"新增微信平台证书: {certificate.SerialNo}");
                        }
                    }
                }
                else
                {
                    logger.LogError(response.Body);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            await Task.Delay(TimeSpan.FromHours(12), stoppingToken);
        }
    }
}
