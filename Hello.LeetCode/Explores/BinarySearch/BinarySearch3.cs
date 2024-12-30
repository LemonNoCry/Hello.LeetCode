namespace Hello.LeetCode.Explores.BinarySearch;

public class BinarySearch3
{
    /// <summary>
    /// Finds the starting and ending position of a target value in a sorted array.
    /// <br/>
    /// https://leetcode.com/explore/learn/card/binary-search/135/template-iii/944/
    /// </summary>
    /// <param name="nums">
    /// A sorted integer array in non-decreasing order.
    /// </param>
    /// <param name="target">
    /// The integer value to search for in the array.
    /// </param>
    /// <returns>
    /// An array of two integers where the first element is the starting position and
    /// the second element is the ending position of the target in the array.
    /// If the target is not found, returns [-1, -1].
    /// </returns>
    /// <remarks>
    /// This algorithm achieves O(log n) runtime complexity by using binary search.
    /// The approach involves finding the leftmost and rightmost indices of the target separately.
    /// </remarks>
    /// <example>
    /// Example 1:
    /// <code>
    /// Input: nums = [5, 7, 7, 8, 8, 10], target = 8
    /// Output: [3, 4]
    /// Explanation: The target value 8 starts at index 3 and ends at index 4.
    ///
    /// Example 2:
    /// Input: nums = [5, 7, 7, 8, 8, 10], target = 6
    /// Output: [-1, -1]
    /// Explanation: The target value 6 is not in the array.
    ///
    /// Example 3:
    /// Input: nums = [], target = 0
    /// Output: [-1, -1]
    /// Explanation: The array is empty, so the target is not found.
    /// </code>
    /// </example>
    /// <complexity>
    /// Time Complexity: O(log n)
    /// Space Complexity: O(1)
    /// </complexity>
    public int[] SearchRange(int[] nums, int target)
    {
        return [FindLeft(nums, target), FindRight(nums, target)];

        int FindLeft(int[] inputArray, int targetValue)
        {
            int l = 0, r = inputArray.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (inputArray[m] < targetValue)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return l < inputArray.Length && inputArray[l] == targetValue ? l : -1;
        }

        int FindRight(int[] inputArray, int targetValue)
        {
            int l = 0, r = inputArray.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (inputArray[m] > targetValue)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            return r >= 0 && inputArray[r] == targetValue ? r : -1;
        }
    }

    /// <summary>
    /// Finds the k closest integers to x in a sorted integer array.
    /// <br/>
    /// https://leetcode.com/explore/learn/card/binary-search/135/template-iii/945/
    /// <br/>
    /// The result is returned in ascending order. An integer a is closer to x than an integer b if:
    /// <para>1. |a - x| &lt; |b - x|, or</para>
    /// <para>2. |a - x| == |b - x| and a &lt; b.</para>
    /// </summary>
    /// <param name="arr">
    /// A sorted integer array in ascending order.
    /// </param>
    /// <param name="k">
    /// The number of closest integers to find.
    /// </param>
    /// <param name="x">
    /// The target integer to compare distances against.
    /// </param>
    /// <returns>
    /// A sorted list of the k closest integers to x.
    /// </returns>
    /// <remarks>
    /// The algorithm should run in O(log n + k) time complexity:
    /// <list type="bullet">
    /// <item>O(log n): Finding the starting position using binary search.</item>
    /// <item>O(k): Collecting the k closest elements.</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// Example 1:
    /// Input: arr = [1,2,3,4,5], k = 4, x = 3
    /// Output: [1,2,3,4]
    /// Explanation: The 4 closest elements to 3 are [1, 2, 3, 4].
    ///
    /// Example 2:
    /// Input: arr = [1,1,2,3,4,5], k = 4, x = -1
    /// Output: [1,1,2,3]
    /// Explanation: The 4 closest elements to -1 are [1, 1, 2, 3].
    /// </code>
    /// </example>
    /// <complexity>
    /// <para>Time Complexity: O(log n + k)</para>
    /// <para>Space Complexity: O(k) for the result.</para>
    /// </complexity>
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        int l = 0, r = arr.Length - k;

        while (l < r)
        {
            int m = l + (r - l) / 2;
            if (x - arr[m] > arr[m + k] - x)
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }

        return arr[l..(l + k)];
    }
}