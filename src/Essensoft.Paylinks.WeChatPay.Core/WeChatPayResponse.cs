using System.Net;
using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Core;

/// <summary>
/// WeChatPay 应答
/// </summary>
public abstract class WeChatPayResponse
{
    #region 错误码和错误提示

    // 详见 https://pay.weixin.qq.com/wiki/doc/apiv3/wechatpay/wechatpay2_0.shtml#part-7

    /// <summary>
    /// 错误码
    /// </summary>
    [JsonPropertyName("code")]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    [JsonPropertyName("message")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误详情
    /// </summary>
    [JsonPropertyName("detail")]
    public Dictionary<string, object>? ErrorDetail { get; set; }

    #endregion

    /// <summary>
    /// 头部信息
    /// </summary>
    [JsonIgnore]
    public WeChatPayHeaders? Headers { get; set; }

    /// <summary>
    /// 原始内容
    /// </summary>
    [JsonIgnore]
    public string? Body { get; set; }

    /// <summary>
    /// HTTP状态码
    /// </summary>
    [JsonIgnore]
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// 应答结果是否成功
    /// </summary>
    [JsonIgnore]
    public bool IsSuccessful => (int)StatusCode is >= 200 and < 300;
}
