using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Mvc;
using Essensoft.Paylinks.WeChatPay.Mvc.Extensions;
using Essensoft.Paylinks.WeChatPay.Payments.Notify;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments.Notify;

[IgnoreAntiforgeryToken]
public class TransactionSuccessModel(ILogger<TransactionSuccessModel> logger, IWeChatPayNotifyClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    /// <summary>
    /// 支付成功回调通知
    /// https://pay.weixin.qq.com/doc/v3/merchant/4012791861
    /// </summary>
    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var headers = await Request.GetWeChatPayHeadersAsync();
            var body = await Request.GetWeChatPayBodyAsync();
            var notify = await client.ExecuteAsync<WeChatPayTransactionSuccessNotify>(headers, body, _options);
            // 请务必检查系统内业务状态，避免因重复通知遭受损失。
            logger.LogInformation($"支付成功通知: TransactionId:{notify.TransactionId}, TotalAmount:{notify.Amount.Total}");
            return WeChatPayNotifyResult.Success;
        }
        catch (WeChatPayException ex)
        {
            logger.LogError(ex.Message);
            return WeChatPayNotifyResult.Fail;
        }
    }
}
