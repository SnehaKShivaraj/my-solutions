public class Solution {
    public int MinInsertions(string s) {
    string reversedString = "";

        for(int i = s.Length - 1 ; i >= 0; i--){
            reversedString += s[i];
        }
        int lcs = getMaxLengthOfSubseq(s, reversedString, s.Length - 1, s.Length - 1, new Dictionary<(int, int), int>());

        return s.Length - lcs;
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