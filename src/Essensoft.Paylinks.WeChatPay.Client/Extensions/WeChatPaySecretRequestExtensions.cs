using System.Reflection;
using Essensoft.Paylinks.Security;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Core.Utilities;

namespace Essensoft.Paylinks.WeChatPay.Client.Extensions;

/// <summary>
///
/// </summary>
public static class WeChatPaySecretRequestExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <typeparam name="T"></typeparam>
    extension<T>(IWeChatPaySecretRequest<T> request) where T : WeChatPayResponse
    {
        /// <summary>
        /// 加密请求敏感信息字段
        /// </summary>
        public void EncryptSecretRequest(string publicKey)
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
        public void DecryptSecretRequest(string privateKey)
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
}
