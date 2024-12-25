using System.Text;

namespace Essensoft.Paylinks.Security;

public static class MD5
{
    public static string ComputeHash(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            throw new ArgumentNullException(nameof(data));
        }

        using var md5 = System.Security.Cryptography.MD5.Create();
        return Convert.ToHexString(md5.ComputeHash(Encoding.UTF8.GetBytes(data)));
    }
}
