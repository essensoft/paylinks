using Shouldly;
using Xunit;

namespace Essensoft.Paylinks.Security.Tests;

public class AES_Test
{
    [Fact]
    public void Encrypt_Decrypt_AES_Test()
    {
        var data = Guid.NewGuid().ToString("N");
        var key = Guid.NewGuid().ToString("N");
        var ciphertext = AES.Encrypt(data, key);
        ciphertext.ShouldNotBe(data);
        var plaintext = AES.Decrypt(ciphertext, key);
        plaintext.ShouldBe(data);
    }
}
