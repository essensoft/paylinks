using Essensoft.Paylinks.Alipay.Client;
using Essensoft.Paylinks.Alipay.Payments.Model;
using Essensoft.Paylinks.Alipay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.Alipay.Payments;

public class WapModel(IAlipayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly AlipayClientOptions _options = options.Value.Alipay;

    [BindProperty]
    public AlipayTradeWapPayBizModel Input { get; set; }

    public void OnGet()
    {
        Input = new AlipayTradeWapPayBizModel
        {
            OutTradeNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
            TotalAmount = "0.01",
            Subject = "手机网站支付测试",
            ProductCode = "QUICK_WAP_WAY",
            NotifyUrl = "https://www.domain.com/Alipay/Payments/Notify/TradeResult"
        };
    }

    public async Task OnPostAsync()
    {
        var request = new AlipayTradeWapPayRequest();
        request.SetBizModel(Input);
        ViewData["response"] = await client.PageExecuteAsync(request, _options);
    }

    public async Task<IActionResult> OnPostJumpAsync()
    {
        var request = new AlipayTradeWapPayRequest();
        request.SetBizModel(Input);
        return new ContentResult
        {
            Content = await client.PageExecuteAsync(request, _options),
            ContentType = "text/html"
        };
    }
}
