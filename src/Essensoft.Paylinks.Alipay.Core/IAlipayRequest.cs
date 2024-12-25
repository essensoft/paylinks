namespace Essensoft.Paylinks.Alipay.Core;

/// <summary>
/// Alipay 请求
/// </summary>
/// <typeparam name="T">响应</typeparam>
public interface IAlipayRequest<T> where T : AlipayResponse
{
    /// <summary>
    /// 获取请求方式
    /// </summary>
    AlipayRequestMethod GetRequestMethod();

    /// <summary>
    /// 获取请求接口
    /// </summary>
    string GetRequestUrl();

    /// <summary>
    /// 设置是否需要验签
    /// </summary>
    void SetNeedVerify(bool value);

    /// <summary>
    /// 获取是否需要验签
    /// </summary>
    bool GetNeedVerify();

    /// <summary>
    /// 设置是否需要加密
    /// </summary>
    void SetNeedEncrypt(bool value);

    /// <summary>
    /// 获取是否需要加密
    /// </summary>
    bool GetNeedEncrypt();

    /// <summary>
    /// 设置URL参数模型
    /// </summary>
    /// <param name="queryModel">URL参数模型</param>
    void SetQueryModel(object queryModel);

    /// <summary>
    /// 获取URL参数模型
    /// </summary>
    /// <returns>URL参数模型</returns>
    object? GetQueryModel();

    /// <summary>
    /// 设置JSON参数模型
    /// </summary>
    /// <param name="bodyModel">JSON参数模型</param>
    void SetBodyModel(object bodyModel);

    /// <summary>
    /// 获取JSON参数模型
    /// </summary>
    /// <returns>JSON参数模型</returns>
    object? GetBodyModel();
}
