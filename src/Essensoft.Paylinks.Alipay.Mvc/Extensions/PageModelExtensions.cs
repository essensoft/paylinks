using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essensoft.Paylinks.Alipay.Mvc.Extensions;

public static class PageModelExtensions
{
    public static async Task<Dictionary<string, string>> GetAlipayParametersAsync(this PageModel pageModel)
    {
        return await pageModel.Request.GetAlipayParametersAsync().ConfigureAwait(false);
    }
}
