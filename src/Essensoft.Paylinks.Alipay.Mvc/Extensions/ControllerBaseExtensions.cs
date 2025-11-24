using Microsoft.AspNetCore.Mvc;

namespace Essensoft.Paylinks.Alipay.Mvc.Extensions;

public static class ControllerBaseExtensions
{
    extension(ControllerBase controllerBase)
    {
        public async Task<Dictionary<string, string>> GetAlipayParametersAsync()
        {
            return await controllerBase.Request.GetAlipayParametersAsync().ConfigureAwait(false);
        }
    }
}
