using Essensoft.Paylinks.WeChatPay.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essensoft.Paylinks.WeChatPay.Mvc.Extensions;

public static class PageModelExtensions
{
    extension(PageModel pageModel)
    {
        public Task<WeChatPayHeaders> GetWeChatPayHeadersAsync()
        {
            return pageModel.Request.GetWeChatPayHeadersAsync();
        }

        public async Task<string> GetWeChatPayBodyAsync(bool detectEncodingFromByteOrderMarks = true, int bufferSize = 1024, bool leaveOpen = true, CancellationToken cancellationToken = default)
        {
            return await pageModel.Request.GetWeChatPayBodyAsync(detectEncodingFromByteOrderMarks, bufferSize, leaveOpen, cancellationToken).ConfigureAwait(false);
        }
    }
}
