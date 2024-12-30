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
}