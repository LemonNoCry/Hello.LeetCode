using System.Text;

namespace Hello.LeetCode.Medium;

/// <summary>
/// Given a string s, find the length of the longest substring without repeating characters.
/// </summary>
public class Problem3_LongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        var maxLength = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var hs = new HashSet<char> { s[i] };
            for (int j = i + 1; j < s.Length; j++)
            {
                if (!hs.Add(s[j]))
                {
                    maxLength = Math.Max(maxLength, hs.Count);
                    break;
                }
            }

            maxLength = Math.Max(maxLength, hs.Count);
        }

        return maxLength;
    }

    public int LengthOfLongestSubstring2(string s)
    {
        var maxLength = 0;
        var hs = new HashSet<char>();
        var i = 0;
        var j = 0;
        while (i < s.Length && j < s.Length)
        {
            if (!hs.Contains(s[j]))
            {
                hs.Add(s[j++]);
            }
            else
            {
                hs.Remove(s[i++]);
            }

            maxLength = Math.Max(maxLength, j - i);
        }

        return maxLength;
    }

    public int LengthOfLongestSubstring3(string s)
    {
        var maxLength = 0;
        var charIndex = new Dictionary<char, int>();
        var i = 0;

        for (int j = 0; j < s.Length; j++)
        {
            if (charIndex.ContainsKey(s[j]))
            {
                i = Math.Max(charIndex[s[j]] + 1, i);
            }

            charIndex[s[j]] = j;
            maxLength = Math.Max(maxLength, j - i + 1);
        }

        return maxLength;
    }

    public int LengthOfLongestSubstring4(string s)
    {
        var maxLength = 0;
        var lastIndex = new int[128];
        for (int l = 0, r = 0; r < s.Length; r++)
        {
            l = Math.Max(l, lastIndex[s[r]]);
            maxLength = Math.Max(maxLength, r - l + 1);
            lastIndex[s[r]] = r + 1;
        }

        return maxLength;
    }
}