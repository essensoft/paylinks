namespace Essensoft.Paylinks.WeChatPay.Core;

/// <summary>
/// WeChatPay 异常
/// </summary>
public class WeChatPayException : Exception
{
    public WeChatPayException()
    {
    }

    public WeChatPayException(string messages) : base(messages)
    {
    }

    public WeChatPayException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
