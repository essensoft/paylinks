using System.Net;
using System.Text;

namespace Essensoft.Paylinks.Alipay.Core.Utilities;

public static class AlipayDictionaryUtilities
{
    public static string BuildQuery(IDictionary<string, string> reqDict)
    {
        var sb = new StringBuilder();

        foreach (var kv in reqDict)
        {
            if (!string.IsNullOrEmpty(kv.Key) && !string.IsNullOrEmpty(kv.Value))
            {
                sb.Append(kv.Key + "=" + WebUtility.UrlEncode(kv.Value) + "&");
            }
        }

        return sb.Length > 0 ? sb.ToString()[..^1] : string.Empty;
    }

    public static string BuildRequestUrl(string reqUrl, IDictionary<string, string> reqDict)
    {
        var query = BuildQuery(reqDict);
        return !string.IsNullOrEmpty(query) ? reqUrl + "?" + query : string.Empty;
    }

    public static string BuildRequestForm(string reqUrl, IDictionary<string, string> reqDict)
    {
        var sb = new StringBuilder();
        sb.Append($"<form id='alipaySubmit' name='alipaySubmit' action='{reqUrl}?charset=UTF-8' method='POST' style='display:none;'>");

        foreach (var kv in reqDict)
        {
            if (!string.IsNullOrEmpty(kv.Key) && !string.IsNullOrEmpty(kv.Value))
            {
                sb.Append($"<input  name='{kv.Key}' value='{kv.Value}'/>");
            }
        }

        sb.Append("<input type='submit' value='POST' style='display:none;'></form>");
        sb.Append("<script>document.forms['alipaySubmit'].submit();</script>");

        return sb.ToString();
    }
}
