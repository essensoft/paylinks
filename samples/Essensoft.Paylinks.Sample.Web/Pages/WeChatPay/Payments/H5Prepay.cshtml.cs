using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;
using Essensoft.Paylinks.WeChatPay.Payments.Model;
using Essensoft.Paylinks.WeChatPay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments;

public class H5PrepayModel(IWeChatPayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    [BindProperty]
    public WeChatPayH5PrepayBodyModel Input { get; set; }

    public void OnGet()
    {
        Input = new WeChatPayH5PrepayBodyModel
        {
            AppId = _options.AppId,
            MchId = _options.MchId,
            Description = "H5下单测试",
            OutTradeNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
            NotifyUrl = "https://www.domain.com/WeChatPay/Payments/Notify/TransactionSuccess",
            Amount = new CommReqAmountInfo { Total = 1 },
            SceneInfo = new H5ReqSceneInfo { PayerClientIp = string.Empty, H5Info = new H5Info { Type = string.Empty } }
        };
    }

    public async Task OnPostAsync()
    {
        var request = new WeChatPayH5PrepayRequest();
        request.SetBodyModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;
    }
}
