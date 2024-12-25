using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Payments.Response;

namespace Essensoft.Paylinks.Alipay.Payments.Request;

/// <summary>
/// 查询对账单下载地址
/// </summary>
/// <para>
/// https://opendocs.alipay.com/open-v3/c8d608d7_alipay.data.dataservice.bill.downloadurl.query
/// 查询对账单下载地址
/// 更新时间：2023-11-07 18:58:25
/// </para>
public class AlipayDataDataServiceBillDownloadUrlQueryRequest : IAlipayRequest<AlipayDataDataServiceBillDownloadUrlQueryResponse>
{
    #region IAlipayRequest Members

    public AlipayRequestMethod GetRequestMethod() => AlipayRequestMethod.Get;

    public string GetRequestUrl() => "/v3/alipay/data/dataservice/bill/downloadurl/query";

    private bool _needVerify = true;

    public void SetNeedVerify(bool value) => _needVerify = value;

    public bool GetNeedVerify() => _needVerify;

    private object? _queryModel;

    public void SetQueryModel(object queryModel) => _queryModel = queryModel;

    public object? GetQueryModel() => _queryModel;

    private object? _bodyModel;

    public void SetBodyModel(object bodyModel) => _bodyModel = bodyModel;

    public object? GetBodyModel() => _bodyModel;

    private bool _needEncrypt;

    public bool GetNeedEncrypt() => _needEncrypt;

    public void SetNeedEncrypt(bool value) => _needEncrypt = value;

    #endregion
}
