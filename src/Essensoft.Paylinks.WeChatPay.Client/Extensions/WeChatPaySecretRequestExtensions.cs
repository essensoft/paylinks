using System.Reflection;
using Essensoft.Paylinks.Security;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Core.Utilities;

namespace Essensoft.Paylinks.WeChatPay.Client.Extensions;

public static class WeChatPaySecretRequestExtensions
{
    /// <summary>
    /// 加密请求敏感信息字段
    /// </summary>
    public static void EncryptSecretRequest<T>(this IWeChatPaySecretRequest<T> request, string publicKey) where T : WeChatPayResponse
    {
        var requestMethod = request.GetRequestMethod();
        var model = request.GetBodyModel();
        if (model != null)
        {
            ReflectionUtilities.ReplaceObjectString(model, (currentProperty, currentString) =>
            {
                if (currentProperty is null || !currentProperty.IsDefined(typeof(WeChatPaySecretPropertyAttribute)))
                {
                    return (false, string.Empty);
                }

                return (true, OaepSHA1WithRSA.Encrypt(currentString, publicKey));
            });
        }
    }

    /// <summary>
    /// 解密请求敏感信息字段(仅单元测试使用)
    /// </summary>
    public static void DecryptSecretRequest<T>(this IWeChatPaySecretRequest<T> request, string privateKey) where T : WeChatPayResponse
    {
        var requestMethod = request.GetRequestMethod();
        var model = request.GetBodyModel();
        if (model != null)
        {
            ReflectionUtilities.ReplaceObjectString(model, (currentProperty, currentString) =>
            {
                if (currentProperty is null || !currentProperty.IsDefined(typeof(WeChatPaySecretPropertyAttribute)))
                {
                    return (false, string.Empty);
                }

                return (true, OaepSHA1WithRSA.Decrypt(currentString, privateKey));
            });
        }
    }
}
