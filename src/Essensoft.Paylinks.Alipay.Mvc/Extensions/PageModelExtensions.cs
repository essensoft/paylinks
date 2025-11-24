using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essensoft.Paylinks.Alipay.Mvc.Extensions;

public static class PageModelExtensions
{
    extension(PageModel pageModel)
    {
        public async Task<Dictionary<string, string>> GetAlipayParametersAsync()
        {
            return await pageModel.Request.GetAlipayParametersAsync().ConfigureAwait(false);
        }
    }
}
