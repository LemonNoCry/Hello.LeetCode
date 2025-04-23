using Hello.LeetCode.Explores.BinarySearch;
using JetBrains.Annotations;
using Xunit;

namespace Hello.LeetCode.Tests.Explores.BinarySearch;

[TestSubject(typeof(BinarySearchMorePractices2))]
public class BinarySearchMorePracticesTest2
{
    private readonly BinarySearchMorePractices2 _binarySearchMorePractices = new();

    [Fact]
    public void Method()
    {
        Assert.Equal(18, _binarySearchMorePractices.SplitArrayLargestSumSplitArray([7, 2, 5, 10, 8], 2));
        Assert.Equal(9, _binarySearchMorePractices.SplitArrayLargestSumSplitArray([1,2,3,4,5], 2));
    }
}