public class Solution {
    public int MinDistance(string word1, string word2) {
        
        return GetMinWays(word1, word2, word1.Length - 1, word2.Length - 1, new Dictionary<(int, int), int>());
    }
    private int GetMinWays(string s, string t, int i, int j, IDictionary<(int, int), int> memo){
        if(j < 0){
            return i + 1;
        }
        
        if(i < 0){
            return j + 1;
        }
        var key = (i, j);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        if(s[i] != t[j]){
            int minOfInsertOrDelete = Math.Min(GetMinWays(s, t, i, j - 1, memo) + 1,  
                                               GetMinWays(s, t, i - 1, j, memo) + 1 );
            return memo[key] = Math.Min(GetMinWays(s, t, i - 1, j - 1, memo) + 1, minOfInsertOrDelete);
        }
        return memo[key] = GetMinWays(s, t, i - 1, j - 1, memo);
    }
}