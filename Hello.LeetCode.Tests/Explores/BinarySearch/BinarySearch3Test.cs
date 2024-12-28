using Hello.LeetCode.Explores.BinarySearch;
using JetBrains.Annotations;
using Xunit;

namespace Hello.LeetCode.Tests.Explores.BinarySearch;

[TestSubject(typeof(BinarySearch3))]
public class BinarySearch3Test
{
    [Fact]
    public void FindClosestElements_ReturnsCorrectElements_WhenInputIsValid()
    {
        var binarySearch3 = new BinarySearch3();
        var result = binarySearch3.FindClosestElements([0, 0, 0, 1, 3, 5, 6, 7, 8, 8], 2, 2);
        Assert.Equal([1, 3], result);
    }
}