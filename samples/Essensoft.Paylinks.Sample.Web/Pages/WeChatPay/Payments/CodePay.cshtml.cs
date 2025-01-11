using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;
using Essensoft.Paylinks.WeChatPay.Payments.Model;
using Essensoft.Paylinks.WeChatPay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments;

public class CodePayModel(IWeChatPayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    [BindProperty]
    public WeChatPayTransactionsCodePayBodyModel Input { get; set; }

    public void OnGet()
    {
        Input = new WeChatPayTransactionsCodePayBodyModel
        {
            AppId = _options.AppId,
            MchId = _options.MchId,
            Description = "付款码支付测试",
            OutTradeNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
            Payer = new Payer { AuthCode = string.Empty },
            Amount = new Amount { Total = 1 },
            SceneInfo = new CodeReqSceneInfo { StoreInfo = new CodeReqStoreInfo { Id = string.Empty } }
        };
    }

    public async Task OnPostAsync()
    {
        var request = new WeChatPayTransactionsCodePayRequest();
        request.SetBodyModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;
    }
}
