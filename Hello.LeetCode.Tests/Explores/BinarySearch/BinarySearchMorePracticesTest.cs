using Hello.LeetCode.Explores.BinarySearch;
using JetBrains.Annotations;
using Xunit;

namespace Hello.LeetCode.Tests.Explores.BinarySearch;

[TestSubject(typeof(BinarySearchMorePractices))]
public class BinarySearchMorePracticesTest
{
    private BinarySearchMorePractices _binarySearchMorePractices = new();

    [Fact]
    public void Method()
    {
        var result = _binarySearchMorePractices.FindMin([3, 3, 1, 3]);
        Assert.Equal(1, result);
    }
}