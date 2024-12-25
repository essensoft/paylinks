using System.Security.Cryptography;
using Essensoft.Paylinks.WeChatPay.Client.Extensions;
using Essensoft.Paylinks.WeChatPay.Core;
using Shouldly;
using Xunit;

namespace Essensoft.Paylinks.WeChatPay.Client.Tests;

public class WeChatPaySecretPropertyTest
{
    class TestModel
    {
        [WeChatPaySecretProperty]
        public string Str2 { get; set; }

        [WeChatPaySecretProperty]
        public List<string> List3 { get; set; }
    }

    class TestSecretModel
    {
        [WeChatPaySecretProperty]
        public string Str1 { get; set; }

        public TestModel Model { get; set; }
    }

    class TestSecretRequest : IWeChatPaySecretRequest<TestSecretResponse>
    {
        #region IWeChatPayRequest Members

        public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;
        public string GetRequestUrl() => throw new NotImplementedException();
        public void SetNeedVerify(bool value) => throw new NotImplementedException();
        public bool GetNeedVerify() => throw new NotImplementedException();
        public void SetQueryModel(object queryModel) => throw new NotImplementedException();
        public object? GetQueryModel() => throw new NotImplementedException();
        private object? _bodyModel;
        public void SetBodyModel(object bodyModel) => _bodyModel = bodyModel;
        public object? GetBodyModel() => _bodyModel;

        #endregion
    }

    class TestSecretResponse : WeChatPaySecretResponse
    {
        [WeChatPaySecretProperty]
        public string Str1 { get; set; }

        public TestModel Model { get; set; }
    }

    [Fact]
    public void Encrypt_Decrypt_SecretRequest_Test()
    {
        using var rsa = RSA.Create();
        var publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
        var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
        var nonceStr1 = Guid.NewGuid().ToString("N");
        var nonceStr2 = Guid.NewGuid().ToString("N");
        var nonceStr3 = Guid.NewGuid().ToString("N");

        var testSecretModel = new TestSecretModel
        {
            Str1 = nonceStr1,
            Model = new TestModel
            {
                Str2 = nonceStr2,
                List3 =
                [
                    nonceStr3,
                    nonceStr3,
                    nonceStr3
                ]
            }
        };

        var testSecretRequest = new TestSecretRequest();
        testSecretRequest.SetBodyModel(testSecretModel);

        // 加密
        testSecretRequest.EncryptSecretRequest(publicKey);

        testSecretModel.Str1.ShouldNotBe(nonceStr1);
        testSecretModel.Model.Str2.ShouldNotBe(nonceStr2);
        foreach (var str in testSecretModel.Model.List3)
        {
            str.ShouldNotBe(nonceStr3);
        }

        // 解密
        testSecretRequest.DecryptSecretRequest(privateKey);

        testSecretModel.Str1.ShouldBe(nonceStr1);
        testSecretModel.Model.Str2.ShouldBe(nonceStr2);
        foreach (var str in testSecretModel.Model.List3)
        {
            str.ShouldBe(nonceStr3);
        }
    }

    [Fact]
    public void Encrypt_Decrypt_SecretResponse_Test()
    {
        using var rsa = RSA.Create();
        var publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
        var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
        var nonceStr1 = Guid.NewGuid().ToString("N");
        var nonceStr2 = Guid.NewGuid().ToString("N");
        var nonceStr3 = Guid.NewGuid().ToString("N");

        var testSecretResponse = new TestSecretResponse
        {
            Str1 = nonceStr1,
            Model = new TestModel
            {
                Str2 = nonceStr2,
                List3 =
                [
                    nonceStr3,
                    nonceStr3,
                    nonceStr3
                ]
            }
        };

        // 加密
        testSecretResponse.EncryptSSecretResponse(publicKey);

        testSecretResponse.Str1.ShouldNotBe(nonceStr1);
        testSecretResponse.Model.Str2.ShouldNotBe(nonceStr2);
        foreach (var str in testSecretResponse.Model.List3)
        {
            str.ShouldNotBe(nonceStr3);
        }

        // 解密
        testSecretResponse.DecryptSecretResponse(privateKey);

        testSecretResponse.Str1.ShouldBe(nonceStr1);
        testSecretResponse.Model.Str2.ShouldBe(nonceStr2);
        foreach (var str in testSecretResponse.Model.List3)
        {
            str.ShouldBe(nonceStr3);
        }
    }
}
