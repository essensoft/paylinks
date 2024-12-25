using System.Text.Json;
using Essensoft.Paylinks.Security;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Client.Extensions;

public static class WeChatPayNotifyExtensions
{
    /// <summary>
    /// 获取解密后的通知资源
    /// </summary>
    /// <param name="notify"></param>
    /// <param name="APIv3Key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static T GetWeChatPayDecryptedNotifyResource<T>(this WeChatPayNotify notify, string APIv3Key) where T : IWeChatPayNotifyResource
    {
        switch (notify.Resource.Algorithm)
        {
            case WeChatPayEncryptionTypes.AEAD_AES_256_GCM:
                {
                    var json = AEAD_AES_256_GCM.Decrypt(notify.Resource.Nonce, notify.Resource.Ciphertext, notify.Resource.AssociatedData, APIv3Key);
                    return JsonSerializer.Deserialize<T>(json, WeChatPayJsonSerializerOptions.Default)!;
                }
            default:
                throw new ArgumentOutOfRangeException(nameof(notify.Resource.Algorithm), notify.Resource.Algorithm, null);
        }
    }
}
