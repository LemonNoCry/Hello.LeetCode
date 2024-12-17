using Hello.LeetCode.Medium;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace Hello.LeetCode.Tests.Medium;

[TestSubject(typeof(Problem2_AddTowNumbers))]
public class Problem2_AddTowNumbersTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Problem2_AddTowNumbersTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void METHOD()
    {
        var n1 = 1;
        int? n2 = null;
        int? n3 = 0;
        int? n4 = 0;

        n3 += n1 + n2.GetValueOrDefault(); // n3 = (n3 + n1 + n2 ) ?? 0;
        _testOutputHelper.WriteLine(n3.ToString());
        Assert.Equal(n1 + n2, n3);

        n4 += n1 + (n2 ?? 0); // n3 = n3 + n1 + n2 ?? 0;
        _testOutputHelper.WriteLine(n4.ToString());
        Assert.Equal(n1 + n2 ?? 0, n4);
    }
}