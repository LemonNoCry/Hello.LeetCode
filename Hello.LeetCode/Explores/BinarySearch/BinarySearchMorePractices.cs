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
}