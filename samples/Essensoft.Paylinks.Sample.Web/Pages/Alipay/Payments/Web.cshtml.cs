using Essensoft.Paylinks.Alipay.Client;
using Essensoft.Paylinks.Alipay.Payments.Model;
using Essensoft.Paylinks.Alipay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.Alipay.Payments;

public class WebModel(IAlipayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly AlipayClientOptions _options = options.Value.Alipay;

    [BindProperty]
    public AlipayTradePagePayBizModel Input { get; set; }

    public void OnGet()
    {
        Input = new AlipayTradePagePayBizModel
        {
            OutTradeNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
            TotalAmount = "0.01",
            Subject = "电脑网站支付测试",
            ProductCode = "FAST_INSTANT_TRADE_PAY",
            NotifyUrl = "https://www.domain.com/Alipay/Payments/Notify/TradeResult"
        };
    }

    public async Task OnPostAsync()
    {
        var request = new AlipayTradePagePayRequest();
        request.SetBizModel(Input);
        ViewData["response"] = await client.PageExecuteAsync(request, _options);
    }

    public async Task<IActionResult> OnPostJump()
    {
        var request = new AlipayTradePagePayRequest();
        request.SetBizModel(Input);
        return new ContentResult
        {
            Content = await client.PageExecuteAsync(request, _options),
            ContentType = "text/html"
        };
    }
}
