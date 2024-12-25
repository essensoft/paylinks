using Essensoft.Paylinks.WeChatPay.Client;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Mvc;
using Essensoft.Paylinks.WeChatPay.Mvc.Extensions;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;
using Essensoft.Paylinks.WeChatPay.Payments.Notify;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essensoft.Paylinks.Sample.Web.Pages.WeChatPay.Payments.Notify;

[IgnoreAntiforgeryToken]
public class RefundResultModel(ILogger<RefundResultModel> logger, IWeChatPayNotifyClient client, IOptions<PaylinksOptions> options) : PageModel
{
    private readonly WeChatPayClientOptions _options = options.Value.WeChatPay;

    /// <summary>
    /// 退款结果通知
    /// https://pay.weixin.qq.com/docs/merchant/apis/jsapi-payment/refund-result-notice.html
    /// </summary>
    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var headers = await Request.GetWeChatPayHeadersAsync();
            var body = await Request.GetWeChatPayBodyAsync();
            var notify = await client.ExecuteAsync<WeChatPayRefundResultNotify>(headers, body, _options);
            // 请务必检查系统内业务状态，避免因重复通知遭受损失。
            switch (notify.RefundStatus)
            {
                case WeChatPayRefundStatus.Success:
                    {
                        logger.LogInformation($"退款成功通知: TransactionId:{notify.TransactionId}, TotalAmount:{notify.Amount.Total}");
                    }
                    break;
                case WeChatPayRefundStatus.Closed:
                    {
                        logger.LogInformation($"退款关闭通知: TransactionId:{notify.TransactionId}, TotalAmount:{notify.Amount.Total}");
                    }
                    break;
                case WeChatPayRefundStatus.Abnormal:
                    {
                        logger.LogInformation($"退款异常通知: TransactionId:{notify.TransactionId}, TotalAmount:{notify.Amount.Total}");
                    }
                    break;
            }

            return WeChatPayNotifyResult.Success;
        }
        catch (WeChatPayException ex)
        {
            logger.LogError(ex.Message);
            return WeChatPayNotifyResult.Fail;
        }
    }
}
