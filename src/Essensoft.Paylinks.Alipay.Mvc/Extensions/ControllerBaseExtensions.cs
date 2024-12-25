using Microsoft.AspNetCore.Mvc;

namespace Essensoft.Paylinks.Alipay.Mvc.Extensions;

public static class ControllerBaseExtensions
{
    public static async Task<Dictionary<string, string>> GetAlipayParametersAsync(this ControllerBase controllerBase)
    {
        return await controllerBase.Request.GetAlipayParametersAsync().ConfigureAwait(false);
    }
}
