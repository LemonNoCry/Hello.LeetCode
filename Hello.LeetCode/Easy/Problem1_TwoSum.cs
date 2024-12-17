using System.Collections;

namespace Hello.LeetCode.Easy;

/// <summary>
/// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
/// You may assume that each input would have exactly one solution, and you may not use the same element twice.
/// You can return the answer in any order.
/// </summary>
public class Problem1_TwoSum
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [];
    }

    public int[] TwoSum2(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (dict.TryGetValue(complement, out var value) && value != i)
            {
                return [i, value];
            }

            dict[nums[i]] = i;
        }

        return [];
    }

    public int[] TowSum3(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];

                if (nums[j] + nums[j - 1] == target)
                    return [j, j - 1];
            }
        }

        return [];
    }
}