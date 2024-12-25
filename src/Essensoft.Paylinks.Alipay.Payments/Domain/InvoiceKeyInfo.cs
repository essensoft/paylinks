using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class InvoiceKeyInfo
{
    [JsonPropertyName("is_support_invoice")]
    public bool IsSupportInvoice { get; set; }

    [JsonPropertyName("invoice_merchant_name")]
    public string InvoiceMerchantName { get; set; }

    [JsonPropertyName("tax_num")]
    public string TaxNum { get; set; }
}
