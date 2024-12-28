namespace Hello.LeetCode.Explores.BinarySearch;

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

    /// <summary>
    /// Finds the minimum element in a sorted and rotated array of unique elements.<br/>
    /// <br/>
    /// https://leetcode.com/explore/learn/card/binary-search/126/template-ii/949/
    /// </summary>
    /// <param name="nums">
    /// A sorted array of unique integers that has been rotated between 1 and n times,
    /// where n is the length of the array.
    /// </param>
    /// <returns>
    /// The minimum element in the array.
    /// </returns>
    /// <remarks>
    /// This algorithm achieves O(log n) time complexity by using a binary search approach.
    /// The rotation means the array may be split into two sorted subarrays, and the minimum
    /// element is the pivot where the rotation occurred.
    /// </remarks>
    /// <example>
    /// Example 1:
    /// <code>
    /// Input: nums = [3, 4, 5, 1, 2]
    /// Output: 1
    /// Explanation: The original array was [1, 2, 3, 4, 5] rotated 3 times.
    ///
    /// Example 2:
    /// Input: nums = [4, 5, 6, 7, 0, 1, 2]
    /// Output: 0
    /// Explanation: The original array was [0, 1, 2, 4, 5, 6, 7] rotated 4 times.
    ///
    /// Example 3:
    /// Input: nums = [11, 13, 15, 17]
    /// Output: 11
    /// Explanation: The array is not rotated, so the first element is the minimum.
    /// </code>
    /// </example>
    /// <complexity>
    /// Time Complexity: O(log n)
    /// Space Complexity: O(1)
    /// </complexity>
    int FindMin(int[] nums)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var m = l + (r - l) / 2;
            if (nums[m] > nums[r])
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }

        return nums[l];
    }
}