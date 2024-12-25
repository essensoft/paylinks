using Essensoft.Paylinks.WeChatPay.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.SecurityTools;

public class ConvertCertPrivateKeyModel : PageModel
{
    [BindProperty]
    public IFormFile CertPrivateKey { get; set; }

    public void OnGet()
    {
    }

    public async Task OnPostAsync()
    {
        try
        {
            using var sr = new StreamReader(CertPrivateKey.OpenReadStream());
            var str = await sr.ReadToEndAsync();
            ViewData["response"] = WeChatPayCertUtilities.ConvertCertPrivateKey(str);
        }
        catch
        {
            ViewData["response"] = "无法获取";
        }
    }
}
