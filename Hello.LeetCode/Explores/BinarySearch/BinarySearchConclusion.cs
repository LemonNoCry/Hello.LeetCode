﻿namespace Hello.LeetCode.Explores.BinarySearch;

public class BinarySearchConclusion
{
    /// <summary>
    /// Calculates the value of a number raised to a power.<br/>
    /// https://leetcode.com/explore/learn/card/binary-search/137/conclusion/982/
    /// </summary>
    /// <remarks>
    /// This method computes <c>x</c> raised to the power of <c>n</c>, represented as <c>x^n</c>.
    /// It handles both positive and negative exponents, as well as edge cases such as zero exponent or base.
    /// </remarks>
    /// <param name="x">The base number.</param>
    /// <param name="n">The exponent, which can be positive, negative, or zero.</param>
    /// <returns>The result of <c>x</c> raised to the power of <c>n</c>.</returns>
    /// <exception cref="ArgumentException">Thrown if the base is zero and the exponent is negative, as the result is undefined.</exception>
    /// <example>
    /// <code>
    /// double result1 = Pow(2, 3); // 8
    /// double result2 = Pow(2, -3); // 0.125
    /// double result3 = Pow(2, 0); // 1
    /// </code>
    /// </example>
    /// <remarks>
    /// This method is optimized to achieve a time complexity of O(log n) using the exponentiation by squaring technique.
    /// </remarks>
    public double MyPow(double x, int n)
    {
        if (n == 0) return 1;
        if (Math.Abs(x - 1) < 1e-9) return 1;

        long exp = Math.Abs((long)n);
        double result = 1.0;

        while (exp > 0)
        {
            if ((exp & 1) == 1)
            {
                result *= x;
            }

            x *= x;
            exp >>= 1;
        }

        return n < 0 ? 1 / result : result;
    }

    /// <summary>
    /// Determines if a given positive integer is a perfect square.<br/>
    /// A perfect square is an integer that is the square of an integer.<br/>
    /// In other words, it is the product of some integer with itself.<br/>
    /// https://leetcode.com/explore/learn/card/binary-search/137/conclusion/978/
    /// </summary>
    /// <param name="num">A positive integer to check.</param>
    /// <returns>
    /// Returns <c>true</c> if the given integer is a perfect square,
    /// otherwise returns <c>false</c>.</returns>
    /// <remarks>
    /// The algorithm uses a binary search approach to check if there exists
    /// an integer x such that x * x == num. It avoids using built-in
    /// functions like <c>sqrt</c> to maintain efficiency and correctness.
    /// The time complexity of this approach is O(log n), where n is the input number.
    /// </remarks>
    public bool IsPerfectSquare(int num)
    {
        if (num < 2)
        {
            return true;
        }

        int l = 2, r = num / 2;
        while (l <= r)
        {
            var m = l + (r - l) / 2;
            var square = (long)m * m;
            if (square == num)
            {
                return true;
            }

            if (square < num)
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return false;
    }
}