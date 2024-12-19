namespace Hello.LeetCode.Explores;

public class BinarySearch2
{
    bool IsBadVersion(int version) => default;

    /// <summary>
    /// Finds the first bad version in the range [1, n].<br/>
    /// <br/><br/>
    /// https://leetcode.com/explore/learn/card/binary-search/126/template-ii/947/
    /// </summary>
    /// <param name="n">The total number of versions.</param>
    /// <returns>The version number of the first bad version.</returns>
    /// <remarks>
    /// Utilizes the <c>isBadVersion(version)</c> API and minimizes calls using binary search.
    /// Once a bad version is found, all subsequent versions are also bad.
    /// </remarks>
    /// <example>
    /// <para>
    /// <example>
    /// <code>
    /// Input: n = 5, bad = 4
    /// Output: 4
    /// Explanation:
    ///     isBadVersion(3) -> false
    ///     isBadVersion(4) -> true
    /// So the first bad version is 4.
    /// </code>
    /// </example>
    /// </para>
    /// </example>
    /// <complexity>
    /// Time Complexity: O(log n)
    /// Space Complexity: O(1)
    /// </complexity>
    int FirstBadVersion(int n)
    {
        int min = 1, max = n;
        while (min < max)
        {
            var m = min + (max - min) / 2;
            if (IsBadVersion(m))
            {
                max = m;
            }
            else
            {
                min = m + 1;
            }
        }

        return min;
    }

    /// <summary>
    /// Finds the index of a peak element in a 0-indexed integer array.
    /// A peak element is an element that is strictly greater than its neighbors.
    /// <br/>
    /// https://leetcode.com/explore/learn/card/binary-search/126/template-ii/948/
    /// </summary>
    /// <param name="nums">
    /// A 0-indexed integer array where nums[-1] and nums[n] are considered to be -∞.
    /// </param>
    /// <returns>
    /// The index of any peak element. If the array contains multiple peaks, returns the index of any one of them.
    /// </returns>
    /// <remarks>
    /// This algorithm achieves O(log n) time complexity by using a binary search approach.
    ///
    /// The array is guaranteed to have at least one peak element due to the virtual -∞ at the boundaries.
    /// </remarks>
    /// <example>
    /// <code>
    /// Example 1:
    /// Input: nums = [1, 2, 3, 1]
    /// Output: 2
    /// Explanation: nums[2] = 3 is a peak element because nums[2] > nums[1] and nums[2] > nums[3].
    ///
    /// Example 2:
    /// Input: nums = [1, 2, 1, 3, 5, 6, 4]
    /// Output: 5
    /// Explanation: nums[5] = 6 is a peak element because nums[5] > nums[4] and nums[5] > nums[6].
    /// </code>
    /// </example>
    /// <complexity>
    /// Time Complexity: O(log n)
    /// Space Complexity: O(1)
    /// </complexity>
    int FindPeakElement(int[] nums)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var m = l + (r - l) / 2;
            if (nums[m] < nums[m + 1])
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }

        return l;
    }
}