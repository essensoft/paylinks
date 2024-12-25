using Essensoft.Paylinks.Alipay.Client;
using Essensoft.Paylinks.Alipay.Payments.Model;
using Essensoft.Paylinks.Alipay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.Alipay.Payments;

public class AppModel(IAlipayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly AlipayClientOptions _options = options.Value.Alipay;

    [BindProperty]
    public AlipayTradeAppPayBizModel Input { get; set; }

    public void OnGet()
    {
        Input = new AlipayTradeAppPayBizModel
        {
            OutTradeNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
            TotalAmount = "0.01",
            Subject = "App支付测试",
            NotifyUrl = "https://www.domain.com/Alipay/Payments/Notify/TradeResult"
        };
    }

    public async Task OnPostAsync()
    {
        var request = new AlipayTradeAppPayRequest();
        request.SetBizModel(Input);
        ViewData["response"] = await client.SdkExecuteAsync(request, _options);
    }
}
