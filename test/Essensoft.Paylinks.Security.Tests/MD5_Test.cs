using Shouldly;
using Xunit;

namespace Essensoft.Paylinks.Security.Tests;

public class MD5_Test
{
    [Fact]
    public void MD5_ComputeHash_Test()
    {
        var hash = MD5.ComputeHash("Hello World");
        hash.ShouldBe("B10A8DB164E0754105B7A99BE72E3FE5");
    }
}
