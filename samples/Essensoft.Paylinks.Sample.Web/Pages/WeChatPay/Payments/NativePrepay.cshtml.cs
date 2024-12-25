using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;
using Essensoft.Paylinks.WeChatPay.Payments.Model;
using Essensoft.Paylinks.WeChatPay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments;

public class NativePrepayModel(IWeChatPayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    [BindProperty]
    public WeChatPayNativePrepayBodyModel Input { get; set; }

    public void OnGet()
    {
        Input = new WeChatPayNativePrepayBodyModel
        {
            AppId = _options.AppId,
            MchId = _options.MchId,
            Description = "Native下单测试",
            OutTradeNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
            NotifyUrl = "https://www.domain.com/WeChatPay/Payments/Notify/TransactionSuccess",
            Amount = new CommReqAmountInfo { Total = 1 }
        };
    }

    public async Task OnPostAsync()
    {
        var request = new WeChatPayNativePrepayRequest();
        request.SetBodyModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["code_url"] = response.CodeUrl;
        ViewData["response"] = response.Body;
    }
}
