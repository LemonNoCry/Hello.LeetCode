namespace Hello.LeetCode.Explores.BinarySearch;

public class BinarySearchMorePractices2
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/binary-search/146/more-practices-ii/1039/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindDuplicate(int[] nums)
    {
        int l = 1, r = nums.Length - 1;
        while (l < r)
        {
            var m = l + (r - l) / 2;
            var count = 0;
            foreach (var num in nums)
            {
                if (num <= m)
                {
                    count++;
                }
            }

            if (count > m)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return l;
    }

    public int FindDuplicate2(int[] nums)
    {
        var slow = nums[0];
        var fast = nums[0];

        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        slow = nums[0];
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }

    /// <summary>
    /// https://leetcode.com/explore/learn/card/binary-search/146/more-practices-ii/1040/
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;
        int low = 0, high = m;
        int left = (m + n + 1) / 2;

        while (low <= high)
        {
            int mid1 = (low + high) / 2;
            int mid2 = left - mid1;

            int L1 = (mid1 == 0) ? int.MinValue : nums1[mid1 - 1];
            int R1 = (mid1 == m) ? int.MaxValue : nums1[mid1];
            int L2 = (mid2 == 0) ? int.MinValue : nums2[mid2 - 1];
            int R2 = (mid2 == n) ? int.MaxValue : nums2[mid2];

            if (L1 <= R2 && L2 <= R1)
            {
                if ((m + n) % 2 == 1)
                    return Math.Max(L1, L2);
                return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2.0;
            }

            if (L1 > R2)
                high = mid1 - 1;
            else
                low = mid1 + 1;
        }

        return default;
    }

    /// <summary>
    /// Find K-th Smallest Pair Distance<br/>
    /// https://leetcode.com/explore/learn/card/binary-search/146/more-practices-ii/1041/
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int SmallestDistancePair(int[] nums, int k)
    {
        Array.Sort(nums);

        var low = 0;
        var high = nums[^1] - nums[0];

        while (low < high)
        {
            var mid = low + (high - low) / 2;
            var count = CountPairsWithMaxDistance(nums, mid);
            if (count < k)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;

        int CountPairsWithMaxDistance(int[] ns, int maxDistance)
        {
            int count = 0;
            int arraySize = ns.Length;
            int left = 0;

            for (int right = 0; right < arraySize; ++right)
            {
                // Adjust the left pointer to maintain the window with distances <= maxDistance
                while (ns[right] - ns[left] > maxDistance)
                {
                    ++left;
                }

                // Add the number of valid pairs ending at the current right index
                count += right - left;
            }

            return count;
        }
    }

    /// <summary>
    /// Split Array Largest Sum <br/>
    /// https://leetcode.com/explore/learn/card/binary-search/146/more-practices-ii/1042/ 
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int SplitArrayLargestSumSplitArray(int[] nums, int k)
    {
        var left = 0;
        var right = 0;
        foreach (int num in nums)
        {
            left = Math.Max(left, num);
            right += num;
        }

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (CanSplit(nums, mid, k))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private bool CanSplit(int[] nums, int maxSum, int k)
    {
        int count = 1;
        int sum = 0;

        foreach (var num in nums)
        {
            sum += num;
            if (sum > maxSum)
            {
                count++;
                sum = num;
            }
        }

        return count <= k;
    }
}