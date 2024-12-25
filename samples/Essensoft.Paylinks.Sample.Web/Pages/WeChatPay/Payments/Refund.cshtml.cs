using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;
using Essensoft.Paylinks.WeChatPay.Payments.Model;
using Essensoft.Paylinks.WeChatPay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments;

public class RefundModel(IWeChatPayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    [BindProperty]
    public WeChatPayRefundBodyModel Input { get; set; }

    public void OnGet()
    {
        Input = new WeChatPayRefundBodyModel
        {
            OutRefundNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
            Amount = new RefundAmount { Refund = 1, Total = 1, Currency = "CNY" },
            NotifyUrl = "https://www.domain.com/WeChatPay/Payments/Notify/RefundResult"
        };
    }

    public async Task OnPostAsync()
    {
        var request = new WeChatPayRefundRequest();
        request.SetBodyModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;
    }
}
