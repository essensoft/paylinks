using System.Net;
using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Core;

/// <summary>
/// 响应
/// </summary>
public abstract class AlipayResponse
{
    #region 错误码和错误提示

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

    #endregion

    /// <summary>
    /// 头部信息
    /// </summary>
    [JsonIgnore]
    public AlipayHeaders? Headers { get; set; }

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
    /// 响应结果是否成功
    /// </summary>
    [JsonIgnore]
    public bool IsSuccessful => (int)StatusCode is >= 200 and < 300;
}
