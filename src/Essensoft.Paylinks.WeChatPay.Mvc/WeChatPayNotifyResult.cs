using Microsoft.AspNetCore.Mvc;

namespace Essensoft.Paylinks.WeChatPay.Mvc;

/// <summary>
/// WeChatPay 通知应答
/// </summary>
public static class WeChatPayNotifyResult
{
    /// <summary>
    /// 成功
    /// </summary>
    public static IActionResult Success => new ContentResult { Content = "{\"code\":\"SUCCESS\",\"message\":\"OK\"}", ContentType = "application/json", StatusCode = 200 };

    /// <summary>
    /// 失败
    /// </summary>
    public static IActionResult Fail => new ContentResult { Content = "{\"code\":\"FAIL\",\"message\":\"FAIL\"}", ContentType = "application/json", StatusCode = 500 };
}
