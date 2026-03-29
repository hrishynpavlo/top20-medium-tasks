namespace TaskRunner;

public class MinimumWindowSubstring
{
    public string MinWindow(string s, string t)
    {
        if(s.Length < t.Length) return string.Empty;

        Dictionary<char, int> need = new(), window = new();
        Result? best = null;
        
        foreach (var c in t)
        {
            if (!need.TryGetValue(c, out var counter))
            {
                need[c] = 1;
                window[c] = 0;
            }
            else
            {
                need[c] = counter + 1;
            }
        }
        
        int left = 0, formed = 0, required = need.Count;
        
        for (int right = 0; right < s.Length; right++)
        {
            var rightSymbol = s[right];

            if (need.TryGetValue(rightSymbol, out var value))
            {
                window[rightSymbol]++;
                if (window[rightSymbol] == value)
                    formed++;
            }
            
            if (formed == required) best = ExchangeBestIfNecessary(best, left, right);

            // move left if necessary
            while (formed == required)
            {
                var leftSymbol = s[left];
                left++;

                if (window.ContainsKey(leftSymbol))
                {
                    if (window[leftSymbol] == need[leftSymbol])
                        formed--;
                    
                    window[leftSymbol]--;
                }
                    
                if(formed == required) best = ExchangeBestIfNecessary(best, left, right);
            }
        }
        
        return best is not null
            ? s[best.StartIndex..(best.StartIndex + best.Length + 1)]
            : string.Empty;
    }

    private Result ExchangeBestIfNecessary(Result? best, int left, int right)
    {
        var bestCandidate = new Result(left, right - left);

        if (best is null || best.Length > bestCandidate.Length)
        {
            return bestCandidate;
        }
        
        return best;
    }
    private record Result(int StartIndex, int Length);
}
