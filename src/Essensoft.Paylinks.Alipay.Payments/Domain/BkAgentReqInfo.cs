using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class BkAgentReqInfo
{
    /// <summary>
    /// 收单机构在清算组织登记或分配的机构代码
    /// </summary>
    [JsonPropertyName("acq_code")]
    public string? AcqCode { get; set; }

    /// <summary>
    /// 终端设备类型，受理方可参考终端注册时的设备类型填写。
    /// </summary>
    [JsonPropertyName("device_type")]
    public string? DeviceType { get; set; }

    /// <summary>
    /// 终端设备实时经纬度信息，格式为纬度/经度，+表示北纬、东经，-表示南纬、西经。
    /// </summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>
    /// 收单机构在清算组织登记的商户编码
    /// </summary>
    [JsonPropertyName("merch_code")]
    public string? MerchCode { get; set; }

    /// <summary>
    /// 终端类型填写为 02、 03、04、05、06、08、09 或 10 时，必 须填写终端序列号。
    /// </summary>
    [JsonPropertyName("serial_num")]
    public string? SerialNum { get; set; }
}
