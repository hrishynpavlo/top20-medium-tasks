namespace TaskRunner;

public class LongestSubstringKDistinct
{
    public int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        if (k == 0) return 0;
        
        int result = 0, left = 0;
        Dictionary<char, int> window = new();
        
        for (int right = 0; right < s.Length; right++)
        {
            var rightSymbol = s[right];

            window[rightSymbol] = window.GetValueOrDefault(rightSymbol, 0) + 1;

            while (window.Count > k)
            {
                var leftSymbol = s[left];
                left++;

                window[leftSymbol]--;
                if (window[leftSymbol] == 0)
                {
                    window.Remove(leftSymbol);
                }
            }
            
            result = Math.Max(result, right - left + 1);
        }

        return result;
    }
}

