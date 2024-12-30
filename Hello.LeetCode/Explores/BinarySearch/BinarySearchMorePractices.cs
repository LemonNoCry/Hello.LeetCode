using System.Collections;

namespace Hello.LeetCode.Explores.BinarySearch;

public class BinarySearchMorePractices
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/binary-search/144/more-practices/1031/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindMin(int[] nums)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var mid = l + (r - l) / 2;
            if (nums[mid] > nums[r])
            {
                l = mid + 1;
            }
            else if (nums[mid] < nums[r])
            {
                r = mid;
            }
            else
            {
                r--;
            }
        }

        return nums[l];
    }

    /// <summary>
    /// Finds the intersection of two integer arrays, returning an array of unique elements that are present in both arrays.<br/>
    /// https://leetcode.com/explore/learn/card/binary-search/144/more-practices/1034/
    /// </summary>
    /// <remarks>
    /// The intersection of two arrays consists of all the unique elements that appear in both arrays.
    /// The order of the elements in the result is not specified.
    /// </remarks>
    /// <param name="nums1">The first integer array to compare.</param>
    /// <param name="nums2">The second integer array to compare.</param>
    /// <returns>
    /// An array of integers representing the intersection of the two input arrays.
    /// Each element in the result is unique and appears in both <paramref name="nums1"/> and <paramref name="nums2"/>.
    /// </returns>
    /// <example>
    /// <code>
    /// int[] nums1 = { 1, 2, 2, 1 };
    /// int[] nums2 = { 2, 2 };
    /// int[] result = Intersection(nums1, nums2); // result will be { 2 }
    /// </code>
    /// </example>
    /// <exception cref="ArgumentNullException">
    /// Thrown if either <paramref name="nums1"/> or <paramref name="nums2"/> is null.
    /// </exception>
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);

        int i = 0, j = 0;
        var result = new List<int>();

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] == nums2[j])
            {
                result.Add(nums1[i]);
                while (i < nums1.Length && nums1[i] == result[^1]) i++;
                while (j < nums2.Length && nums2[j] == result[^1]) j++;
            }
            else if (nums1[i] < nums2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// https://leetcode.com/explore/learn/card/binary-search/144/more-practices/1029/
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public int[] Intersection2(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);

        int i = 0, j = 0;
        var result = new List<int>();

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] == nums2[j])
            {
                result.Add(nums1[i]);
                i++;
                j++;
            }
            else if (nums1[i] < nums2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return result.ToArray();
    }

    public int[] TwoSum(int[] numbers, int target)
    {
        int l = 0, r = numbers.Length - 1;

        while (l < r)
        {
            if (numbers[l] + numbers[r] == target)
            {
                return [l + 1, r + 1];
            }
            else if (numbers[l] + numbers[r] < target)
            {
                l++;
            }
            else
            {
                r--;
            }
        }

        return default;
    }
}