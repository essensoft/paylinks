using System.Text.Json;
using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;
using Essensoft.Paylinks.WeChatPay.Payments.Model;
using Essensoft.Paylinks.WeChatPay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments;

public class JsapiPrepayModel(IWeChatPayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    [BindProperty]
    public WeChatPayJsapiPrepayBodyModel Input { get; set; }

    public void OnGet()
    {
        Input = new WeChatPayJsapiPrepayBodyModel
        {
            AppId = _options.AppId,
            MchId = _options.MchId,
            Description = "JSAPI下单测试",
            OutTradeNo = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"),
            NotifyUrl = "https://www.domain.com/WeChatPay/Payments/Notify/TransactionSuccess",
            Amount = new CommReqAmountInfo { Total = 1 },
            Payer = new JsapiReqPayerInfo { OpenId = string.Empty }
        };
    }

    public async Task OnPostAsync()
    {
        var request = new WeChatPayJsapiPrepayRequest();
        request.SetBodyModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;

        if (response.IsSuccessful)
        {
            var sdkRequest = new WeChatPayJsapiTransferPaymentRequest { AppId = Input.AppId, Package = "prepay_id=" + response.PrepayId };
            var sdkResponse = await client.SdkExecuteAsync(sdkRequest, _options);
            ViewData["parameter"] = JsonSerializer.Serialize(sdkResponse);
        }
    }
}
