using Hello.LeetCode.Explores.BinarySearch;
using JetBrains.Annotations;
using Xunit;

namespace Hello.LeetCode.Tests.Explores.BinarySearch;

[TestSubject(typeof(BinarySearchConclusion))]
public class BinarySearchConclusionTest
{
    [Fact]
    public void MyPow()
    {
        var test = new BinarySearchConclusion();
        var result = test.MyPow(2, 10);
    }
}