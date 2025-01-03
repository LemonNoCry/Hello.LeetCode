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
}