using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Payments.Model;
using Essensoft.Paylinks.WeChatPay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments;

public class ReverseModel(IWeChatPayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    [BindProperty]
    public string OutTradeNo { get; set; }

    [BindProperty]
    public WeChatPayReverseBodyModel Input { get; set; }

    public void OnGet()
    {
        Input = new WeChatPayReverseBodyModel
        {
            AppId = _options.AppId,
            MchId = _options.MchId
        };
    }

    public async Task OnPostAsync()
    {
        var request = new WeChatPayReverseRequest { OutTradeNo = OutTradeNo };
        request.SetBodyModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;
    }
}
