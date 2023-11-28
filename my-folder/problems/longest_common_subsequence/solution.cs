public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
       //return getMaxLengthOfSubseq(text1, text2, text1.Length - 1, text2.Length - 1, new Dictionary<(int, int), int>()); 
       return getMaxLengthOfSubseqTab(text1, text2);
    }
    private static int getMaxLengthOfSubseqTab(string text1, string text2){
        int n = text1.Length + 1;
        int m = text2.Length + 1;
        var dp = new int[n, m];

        for(int i = 1; i < n; i++){
            for(int j = 1; j < m; j++){
                if(text1[i - 1] == text2[j - 1]){
                    dp[i, j] = 1 + dp[i - 1, j  - 1];
                    continue;
                }
                dp[i, j]= Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        return dp[n - 1, m - 1];
    }
    private static int getMaxLengthOfSubseq(string text1, string text2, int i, int j, IDictionary<(int, int), int> memo){
        if( i < 0 || j < 0){
            return 0;
        }

        var key = (i, j);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        if(text1[i] == text2[j]){
            return memo[key] = 1 + getMaxLengthOfSubseq(text1, text2, i - 1, j - 1, memo);
        }

        return memo[key] =  Math.Max(getMaxLengthOfSubseq(text1, text2, i - 1, j, memo), 
                        getMaxLengthOfSubseq(text1, text2, i, j - 1, memo));
    }
}