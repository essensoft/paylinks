using Essensoft.Paylinks.Alipay.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essensoft.Paylinks.Sample.Web.Pages.Alipay.SecurityTools;

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
            ViewData["response"] = AlipayCertUtilities.ConvertCertPrivateKey(str);
        }
        catch
        {
            ViewData["response"] = "无法获取";
        }
    }
}
