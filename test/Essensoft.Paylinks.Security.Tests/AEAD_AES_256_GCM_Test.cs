using Shouldly;
using Xunit;

namespace Essensoft.Paylinks.Security.Tests;

public class AEAD_AES_256_GCM_Test
{
    [Fact]
    public void Encrypt_Decrypt_AEAD_AES_256_GCM_Test()
    {
        var nonce = Guid.NewGuid().ToString("N")[..12];
        var data = Guid.NewGuid().ToString("N");
        var associatedData = Guid.NewGuid().ToString("N");
        var key = Guid.NewGuid().ToString("N");
        var ciphertext = AEAD_AES_256_GCM.Encrypt(nonce, data, associatedData, key);
        ciphertext.ShouldNotBe(data);
        var plaintext = AEAD_AES_256_GCM.Decrypt(nonce, ciphertext, associatedData, key);
        plaintext.ShouldBe(data);
    }
}
