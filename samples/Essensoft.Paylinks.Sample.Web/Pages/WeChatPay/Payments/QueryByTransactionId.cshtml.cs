using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Payments.Model;
using Essensoft.Paylinks.WeChatPay.Payments.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments;

public class QueryByTransactionIdModel(IWeChatPayClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    [BindProperty]
    public string TransactionId { get; set; }

    [BindProperty]
    public WeChatPayQueryByTransactionIdQueryModel Input { get; set; }

    public void OnGet()
    {
        Input = new WeChatPayQueryByTransactionIdQueryModel { MchId = _options.MchId };
    }

    public async Task OnPostAsync()
    {
        var request = new WeChatPayQueryByTransactionIdRequest { TransactionId = TransactionId };
        request.SetQueryModel(Input);
        var response = await client.ExecuteAsync(request, _options);
        ViewData["response"] = response.Body;
    }
}
