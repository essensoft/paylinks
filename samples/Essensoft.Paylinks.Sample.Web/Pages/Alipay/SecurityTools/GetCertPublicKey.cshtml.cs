using Essensoft.Paylinks.Alipay.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essensoft.Paylinks.Sample.Web.Pages.Alipay.SecurityTools;

public class GetCertPublicKeyModel : PageModel
{
    [BindProperty]
    public IFormFile Cert { get; set; }

    public void OnGet()
    {
    }

    public async Task OnPostAsync()
    {
        try
        {
            using var sr = new StreamReader(Cert.OpenReadStream());
            var str = await sr.ReadToEndAsync();
            ViewData["response"] = AlipayCertUtilities.GetCertPublicKey(str);
        }
        catch
        {
            ViewData["response"] = "无法获取";
        }
    }
}
