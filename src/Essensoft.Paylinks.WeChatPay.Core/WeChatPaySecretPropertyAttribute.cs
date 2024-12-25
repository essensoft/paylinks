namespace Essensoft.Paylinks.WeChatPay.Core;

/// <summary>
/// WeChatPay 敏感信息字段
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public sealed class WeChatPaySecretPropertyAttribute : Attribute;
