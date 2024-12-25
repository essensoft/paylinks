using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class InvoiceInfo
{
    [JsonPropertyName("key_info")]
    public InvoiceKeyInfo KeyInfo { get; set; }

    [JsonPropertyName("details")]
    public string Details { get; set; }
}
