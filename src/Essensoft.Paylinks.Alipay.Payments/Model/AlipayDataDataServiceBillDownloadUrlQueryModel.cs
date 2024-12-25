using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayDataDataServiceBillDownloadUrlQueryModel
{
    /// <summary>
    /// 账单类型，商户通过接口或商户经开放平台授权后其所属服务商通过接口可以获取以下账单类型。
    /// </summary>
    [JsonPropertyName("bill_type")]
    public string BillType { get; set; }

    /// <summary>
    /// 账单时间：* 日账单格式为yyyy-MM-dd，最早可下载2016年1月1日开始的日账单。不支持下载当日账单，只能下载前一日24点前的账单数据（T+1），当日数据一般于次日 9 点前生成，特殊情况可能延迟。 * 月账单格式为yyyy-MM，最早可下载2016年1月开始的月账单。不支持下载当月账单，只能下载上一月账单数据，当月账单一般在次月 3 日生成，特殊情况可能延迟。 * 当biz_type为settlementMerge时候，时间为汇总批次结算资金到账的日期，日期格式为yyyy-MM-dd，最早可下载2023年4月17日及以后的账单。
    /// </summary>
    [JsonPropertyName("bill_date")]
    public string BillDate { get; set; }

    /// <summary>
    /// 二级商户smid，这个参数只在bill_type是trade_zft_merchant时才能使用
    /// </summary>
    [JsonPropertyName("smid")]
    public string? Smid { get; set; }
}
