public class Solution {
    public bool IsMatch(string s, string p) {
       return GetMinWays(s, p, s.Length - 1, p.Length - 1, new Dictionary<(int, int), bool>()); 
    }
    private bool GetMinWays(string s, string t, int i, int j, IDictionary<(int, int), bool> memo){
        if(j < 0 && i < 0){
            return true;
        }
        
        if(i >= 0 && j < 0){
            return false;
        }

        if(i < 0 && j >= 0){
            for(int index = j; index >= 0; index--){
                if(t[index] != '*'){
                    return false;
                }
            }
            return true;
        }
        var key = (i, j);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        if(s[i] == t[j] || t[j] == '?'){
            return memo[key] = GetMinWays(s, t, i - 1, j - 1, memo);
        }

        if(t[j] == '*'){
            return memo[key] = GetMinWays(s, t, i, j - 1, memo) || GetMinWays(s, t, i - 1, j, memo);
        }
        return false;
    }
}