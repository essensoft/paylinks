using Essensoft.Paylinks.WeChatPay.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essensoft.Paylinks.WeChatPay.Mvc.Extensions;

public static class PageModelExtensions
{
    public static Task<WeChatPayHeaders> GetWeChatPayHeadersAsync(this PageModel pageModel)
    {
        return pageModel.Request.GetWeChatPayHeadersAsync();
    }

    public static async Task<string> GetWeChatPayBodyAsync(this PageModel pageModel, bool detectEncodingFromByteOrderMarks = true, int bufferSize = 1024, bool leaveOpen = true, CancellationToken cancellationToken = default)
    {
        return await pageModel.Request.GetWeChatPayBodyAsync(detectEncodingFromByteOrderMarks, bufferSize, leaveOpen, cancellationToken).ConfigureAwait(false);
    }
}
