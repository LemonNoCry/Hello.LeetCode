namespace Hello.LeetCode.Hard;

/// <summary>
/// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
/// The overall run time complexity should be O(log (m+n)).
/// </summary>
public class Problem4_MedianofTwoSortedArrays
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var nums3 = nums1.Concat(nums2).ToArray();
        Array.Sort(nums3);

        if (nums3.Length % 2 == 0)
        {
            return (nums3[nums3.Length / 2 - 1] + nums3[nums3.Length / 2]) / 2.0;
        }

        return nums3[nums3.Length / 2];
    }

    public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
    {
        int l = 0, r = 0;
        int m1 = 0, m2 = 0;
        for (int i = 0; i <= nums1.Length + nums2.Length; i++)
        {
            m2 = m1;

            if (l != nums1.Length && r != nums2.Length)
            {
                m1 = nums1[l] < nums2[r] ? nums1[l++] : nums2[r++];
            }
            else if (l < nums1.Length)
            {
                m1 = nums1[l++];
            }
            else if (r < nums2.Length)
            {
                m1 = nums2[r++];
            }
            else
            {
                break;
            }
        }

        if ((nums1.Length + nums2.Length) % 2 == 0)
        {
            return (m1 + m2) / 2.0;
        }

        return m1;
    }

    public double FindMedianSortedArrays3(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays3(nums2, nums1);
        }

        int x = nums1.Length;
        int y = nums2.Length;
        int low = 0;
        int high = x;

        while (low <= high)
        {
            int partitionX = (low + high) / 2;
            int partitionY = (x + y + 1) / 2 - partitionX;

            int maxLeftX = partitionX == 0 ? int.MinValue : nums1[partitionX - 1];
            int minRightX = partitionX == x ? int.MaxValue : nums1[partitionX];

            int maxLeftY = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];
            int minRightY = partitionY == y ? int.MaxValue : nums2[partitionY];

            if (maxLeftX <= minRightY && maxLeftY <= minRightX)
            {
                if ((x + y) % 2 == 0)
                {
                    return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
                }

                return Math.Max(maxLeftX, maxLeftY);
            }

            if (maxLeftX > minRightY)
            {
                high = partitionX - 1;
            }
            else
            {
                low = partitionX + 1;
            }
        }

        throw new InvalidOperationException();
    }
}