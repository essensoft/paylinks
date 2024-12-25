using Essensoft.Paylinks.Alipay.Client;
using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Mvc;
using Essensoft.Paylinks.Alipay.Mvc.Extensions;
using Essensoft.Paylinks.Alipay.Payments.Notify;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.Alipay.Payments.Notify;

[IgnoreAntiforgeryToken]
public class TradeResultModel(ILogger<TradeResultModel> logger, IAlipayNotifyClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly AlipayClientOptions _options = options.Value.Alipay;

    /// <summary>
    /// 支付成功通知
    /// https://opendocs.alipay.com/open-v3/05pf4k?pathHash=01c6e762
    /// </summary>
    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var parameters = await Request.GetAlipayParametersAsync();
            var notify = await client.ExecuteAsync<AlipayTradeStatusSyncNotify>(parameters, _options);
            // 请务必检查系统内业务状态，避免因重复通知遭受损失。
            logger.LogInformation($"支付成功通知: TradeNo:{notify.TradeNo}, TotalAmount:{notify.TotalAmount}");
            return AlipayNotifyResult.Success;
        }
        catch (AlipayException ex)
        {
            logger.LogError(ex.Message);
            return AlipayNotifyResult.Fail;
        }
    }
}
