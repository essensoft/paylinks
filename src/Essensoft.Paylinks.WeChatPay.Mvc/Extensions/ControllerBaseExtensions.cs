using Essensoft.Paylinks.WeChatPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace Essensoft.Paylinks.WeChatPay.Mvc.Extensions;

public static class ControllerBaseExtensions
{
    extension(ControllerBase controllerBase)
    {
        public Task<WeChatPayHeaders> GetWeChatPayHeadersAsync()
        {
            return controllerBase.Request.GetWeChatPayHeadersAsync();
        }

        public async Task<string> GetWeChatPayBodyAsync(bool detectEncodingFromByteOrderMarks = true, int bufferSize = 1024, bool leaveOpen = true, CancellationToken cancellationToken = default)
        {
            return await controllerBase.Request.GetWeChatPayBodyAsync(detectEncodingFromByteOrderMarks, bufferSize, leaveOpen, cancellationToken).ConfigureAwait(false);
        }
    }
}
