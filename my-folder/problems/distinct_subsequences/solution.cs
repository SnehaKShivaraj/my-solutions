public class Solution {
    public int NumDistinct(string s, string t) {
        return GetTotalWaysOfSubSeq(s, t, s.Length - 1, t.Length - 1, new Dictionary<(int, int), int>());
    }
    private int GetTotalWaysOfSubSeq(string s, string t, int i, int j, IDictionary<(int, int), int> memo){
        if(j < 0){
            return 1;
        }
        
        if(i < 0){
            return 0;
        }
        var key = (i, j);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        if(s[i] == t[j]){
            return memo[key] = GetTotalWaysOfSubSeq(s, t, i - 1, j - 1, memo) + GetTotalWaysOfSubSeq(s, t, i - 1, j, memo);
        }
        return memo[key] = GetTotalWaysOfSubSeq(s, t, i - 1, j, memo);
    }
}