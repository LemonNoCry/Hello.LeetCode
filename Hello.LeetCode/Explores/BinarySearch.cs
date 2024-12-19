namespace Hello.LeetCode.Explores;

public class BinarySearch
{
    /// <summary>
    /// Binary Search<br/>
    /// <br/>
    /// Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.<br/>
    /// You must write an algorithm with O(log n) runtime complexity.<br/>
    /// <br/><br/>
    /// https://leetcode.com/explore/learn/card/binary-search/138/background/1038/<br/>
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int Search(int[] nums, int target)
    {
        int SearchInternal(int[] nums, int left, int right, int target)
        {
            if (left == right) return -1;
            int mid = left + (right - left) / 2;
            if (target == nums[mid]) return mid;
            if (target < nums[mid]) return SearchInternal(nums, left, mid, target);
            return SearchInternal(nums, mid + 1, right, target);
        }

        return SearchInternal(nums, 0, nums.Length, target);
    }

    /// <summary>
    /// Given a non-negative integer x, return the square root of x rounded down to the nearest integer.<br/>
    /// <br/>
    /// The returned integer should be non-negative as well.<br/>
    /// You must not use any built-in exponent function or operator.<br/>
    /// For example, do not use pow(x, 0.5) in C++ or x ** 0.5 in Python.<br/>
    /// <br/><br/>
    /// https://leetcode.com/explore/learn/card/binary-search/125/template-i/950/<br/>
    /// </summary>
    /// <param name="x">The non-negative integer to find the square root of.</param>
    /// <returns>The square root of x rounded down to the nearest integer.</returns>
    public int MySqrt(int x)
    {
        if (x == 0) return 0;

        int MySqrtInternal(int min, int max)
        {
            if (min > max)
            {
                return max;
            }

            var m = min + (max - min) / 2;
            var square = (long)m * m;
            if (square == x)
            {
                return m;
            }

            return square < x ? MySqrtInternal(m + 1, max) : MySqrtInternal(min, m - 1);
        }

        return MySqrtInternal(1, x);
    }

    int guess(int num) => default;

    /// <summary>
    /// Guess Number Higher or Lower <br/>
    /// <br/>
    /// We are playing the Guess Game. The game is as follows:<br/>
    /// I pick a number from 1 to n. You have to guess which number I picked.<br/>
    /// Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.<br/>
    /// You call a pre-defined API int guess(int num), which returns three possible results:<br/>
    /// -1: Your guess is higher than the number I picked (i.e. num &gt; pick).<br/>
    /// 1: Your guess is lower than the number I picked (i.e. num &lt; pick).<br/>
    /// 0: Your guess is equal to the number I picked (i.e. num == pick).<br/>
    /// Return the number that I picked.
    /// <br/><br/>
    /// https://leetcode.com/explore/learn/card/binary-search/125/template-i/951/<br/>
    /// </summary>
    /// <param name="n">The upper bound of the range to guess from.</param>
    /// <returns>The number that I picked.</returns>
    public int GuessNumber(int n)
    {
        int min = 1, max = n;
        while (min <= max)
        {
            var m = min + (max - min) / 2;
            switch (guess(m))
            {
                case 0:
                    return m;
                case > 0:
                    min = m + 1;
                    break;
                default:
                    max = m - 1;
                    break;
            }
        }

        return -1;
    }

    /// <summary>
    /// Searches for a target value in a rotated sorted array with distinct integers.
    /// <br/><br/>
    /// https://leetcode.com/explore/learn/card/binary-search/125/template-i/952/<br/>
    /// </summary>
    /// <param name="nums">
    /// An integer array that is initially sorted in ascending order and may be rotated
    /// at an unknown pivot index. The rotation means the array takes the form:
    /// [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]].
    ///
    /// For example:
    /// - Input: nums = [0,1,2,4,5,6,7] (sorted array)
    /// - After rotation at index 3: nums = [4,5,6,7,0,1,2]
    ///
    /// The array does not contain duplicate elements.
    /// </param>
    /// <param name="target">
    /// The integer value to search for in the array. This value is guaranteed to be
    /// unique if it exists within the array.
    /// </param>
    /// <returns>
    /// Returns the index of the target value if it is found within the array.
    /// If the target value does not exist in the array, returns -1.
    /// </returns>
    /// <remarks>
    /// - The algorithm should run in O(log n) time complexity, meaning it must utilize
    ///   an approach such as binary search.
    /// - The input array is guaranteed to contain distinct values.
    /// </remarks>
    public int Search2(int[] nums, int target)
    {
        int l = 0, r = nums.Length - 1;
        while (l <= r)
        {
            var m = l + (r - l) / 2;
            if (nums[m] == target) return m;

            if (nums[l] <= nums[m])
            {
                if (nums[l] <= target && target < nums[m])
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            else
            {
                if (nums[m] < target && target <= nums[r])
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }
        }

        return -1;
    }
}