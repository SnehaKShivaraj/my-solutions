public class Solution {
    public int MinDistance(string word1, string word2) {
        int lcs = getLCS(word1, word2, word1.Length - 1, word2.Length - 1, new Dictionary<(int, int), int>());

        return (word1.Length - lcs) + (word2.Length - lcs);
    }
    private static int getLCS(string s1, string s2, int i, int j, IDictionary<(int, int), int> memo){
        if(i < 0 || j < 0){
            return 0;
        }
        var key = (i,j);

        if(memo.ContainsKey(key)){
            return memo[key];
        }

        if(s1[i] == s2[j]){
            return memo[key] = 1 + getLCS(s1, s2, i - 1, j - 1, memo);
        }
        return memo[key] = Math.Max(getLCS(s1, s2, i - 1, j, memo), getLCS(s1, s2, i, j - 1, memo));
    }
}