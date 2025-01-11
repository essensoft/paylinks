using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Payments.Model;
using Essensoft.Paylinks.WeChatPay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments;

public class GetTradeBillModel(IWeChatPayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    [BindProperty]
    public WeChatPayTradeBillQueryModel Input { get; set; }

    public void OnGet()
    {
        Input = new WeChatPayTradeBillQueryModel { BillDate = DateTimeOffset.Now.AddDays(-1).ToString("yyyy-MM-dd") };
    }

    public async Task OnPostAsync()
    {
        var request = new WeChatPayTradeBillRequest();
        request.SetQueryModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;
    }
}
