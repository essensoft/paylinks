using Essensoft.Paylinks.Alipay.Client;
using Essensoft.Paylinks.Alipay.Payments.Model;
using Essensoft.Paylinks.Alipay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.Alipay.Payments;

public class RefundModel(IAlipayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly AlipayClientOptions _options = options.Value.Alipay;

    [BindProperty]
    public AlipayTradeRefundBodyModel Input { get; set; }

    public void OnGet()
    {
        Input = new AlipayTradeRefundBodyModel
        {
            RefundAmount = "0.01",
            OutRequestNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
        };
    }

    public async Task OnPostAsync()
    {
        var request = new AlipayTradeRefundRequest();
        request.SetBodyModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;
    }
}
