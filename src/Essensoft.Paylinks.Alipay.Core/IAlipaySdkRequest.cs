namespace Essensoft.Paylinks.Alipay.Core;

/// <summary>
/// Alipay SDK请求
/// </summary>
public interface IAlipaySdkRequest
{
    /// <summary>
    /// 获取接口名称
    /// </summary>
    string GetMethod();

    /// <summary>
    /// 设置业务参数模型
    /// </summary>
    /// <param name="bizModel">业务参数模型</param>
    void SetBizModel(object bizModel);

    /// <summary>
    /// 获取业务参数模型
    /// </summary>
    /// <returns>业务参数模型</returns>
    object GetBizModel();

    /// <summary>
    /// 设置是否需要加密
    /// </summary>
    void SetNeedEncrypt(bool value);

    /// <summary>
    /// 获取是否需要加密
    /// </summary>
    bool GetNeedEncrypt();
}
