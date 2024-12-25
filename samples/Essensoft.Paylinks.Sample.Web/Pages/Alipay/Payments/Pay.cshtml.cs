using Essensoft.Paylinks.Alipay.Client;
using Essensoft.Paylinks.Alipay.Payments.Model;
using Essensoft.Paylinks.Alipay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.Alipay.Payments;

public class PayModel(IAlipayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly AlipayClientOptions _options = options.Value.Alipay;

    [BindProperty]
    public AlipayTradePayBodyModel Input { get; set; }

    public void OnGet()
    {
        Input = new AlipayTradePayBodyModel
        {
            OutTradeNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
            TotalAmount = "0.01",
            Subject = "付款码支付测试",
            Scene = "bar_code",
            NotifyUrl = "https://www.domain.com/Alipay/Payments/Notify/TradeResult"
        };
    }

    public async Task OnPostAsync()
    {
        var request = new AlipayTradePayRequest();
        request.SetBodyModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;
    }
}
