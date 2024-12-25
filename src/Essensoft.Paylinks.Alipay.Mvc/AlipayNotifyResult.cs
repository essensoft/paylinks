using Microsoft.AspNetCore.Mvc;

namespace Essensoft.Paylinks.Alipay.Mvc;

/// <summary>
/// Alipay 通知响应
/// </summary>
public static class AlipayNotifyResult
{
    /// <summary>
    /// 成功
    /// </summary>
    public static IActionResult Success => new ContentResult { Content = "success", ContentType = "text/plain", StatusCode = 200 };

    /// <summary>
    /// 失败
    /// </summary>
    public static IActionResult Fail => new ContentResult { Content = "fail", ContentType = "text/plain", StatusCode = 200 };
}
