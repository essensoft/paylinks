using Essensoft.Paylinks.WeChatPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace Essensoft.Paylinks.WeChatPay.Mvc.Extensions;

public static class ControllerBaseExtensions
{
    public static Task<WeChatPayHeaders> GetWeChatPayHeadersAsync(this ControllerBase controllerBase)
    {
        return controllerBase.Request.GetWeChatPayHeadersAsync();
    }

    public static async Task<string> GetWeChatPayBodyAsync(this ControllerBase controllerBase, bool detectEncodingFromByteOrderMarks = true, int bufferSize = 1024, bool leaveOpen = true, CancellationToken cancellationToken = default)
    {
        return await controllerBase.Request.GetWeChatPayBodyAsync(detectEncodingFromByteOrderMarks, bufferSize, leaveOpen, cancellationToken).ConfigureAwait(false);
    }
}
