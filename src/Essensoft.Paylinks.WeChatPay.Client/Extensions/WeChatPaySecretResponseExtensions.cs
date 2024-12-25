using System.Reflection;
using Essensoft.Paylinks.Security;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Core.Utilities;

namespace Essensoft.Paylinks.WeChatPay.Client.Extensions;

public static class WeChatPaySecretResponseExtensions
{
    /// <summary>
    /// 加密请求敏感信息字段(仅单元测试使用)
    /// </summary>
    public static void EncryptSSecretResponse(this IWeChatPaySecretResponse response, string publicKey)
    {
        ReflectionUtilities.ReplaceObjectString(response, (currentProperty, currentString) =>
        {
            if (currentProperty is null || !currentProperty.IsDefined(typeof(WeChatPaySecretPropertyAttribute)))
            {
                return (false, string.Empty);
            }

            return (true, OaepSHA1WithRSA.Encrypt(currentString, publicKey));
        });
    }

    /// <summary>
    /// 解密应答敏感信息字段
    /// </summary>
    public static void DecryptSecretResponse(this IWeChatPaySecretResponse response, string privateKey)
    {
        ReflectionUtilities.ReplaceObjectString(response, (currentProperty, currentString) =>
        {
            if (currentProperty is null || !currentProperty.IsDefined(typeof(WeChatPaySecretPropertyAttribute)))
            {
                return (false, string.Empty);
            }

            return (true, OaepSHA1WithRSA.Decrypt(currentString, privateKey));
        });
    }
}
