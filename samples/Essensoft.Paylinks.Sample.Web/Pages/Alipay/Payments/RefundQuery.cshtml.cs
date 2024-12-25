using Essensoft.Paylinks.Alipay.Client;
using Essensoft.Paylinks.Alipay.Payments.Model;
using Essensoft.Paylinks.Alipay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.Alipay.Payments;

public class RefundQueryModel(IAlipayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly AlipayClientOptions _options = options.Value.Alipay;

    [BindProperty]
    public AlipayTradeFastPayRefundQueryBodyModel Input { get; set; }

    public void OnGet()
    {
    }

    public async Task OnPostAsync()
    {
        var request = new AlipayTradeFastPayRefundQueryRequest();
        request.SetBodyModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;
    }
}
