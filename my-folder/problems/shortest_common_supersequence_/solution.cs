public class Solution {
    public string ShortestCommonSupersequence(string str1, string str2) {
       //string lcs = getLCS(str1, str2, str1.Length - 1, str2.Length - 1, new Dictionary<(int, int), string>());
       int n = str1.Length;
       int m = str2.Length;
       var dp = new int[n + 1, m + 1];
       for(int i = 1; i <= n; i++){
           for(int j = 1; j <= m; j++){
               if(str1[i - 1] == str2[j - 1]){
                   dp[i, j] = dp[i - 1, j- 1] + 1;
                   continue;
               }
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
           }
       }
        string seq  = String.Empty;
        while(n > 0 && m > 0){
            if(str1[n - 1] == str2[m - 1]){
                seq += str1[n - 1];
                n--;
                m--;
                continue;
            }
            if(dp[n - 1, m] > dp[n, m - 1]){
                seq += str1[n - 1];
                n--;
                continue;
            }
            seq += str2[m - 1];
            m--;
        }
        while(n > 0){
            seq += str1[n - 1];
            n--;
        }
        while(m > 0){
            seq += str2[m - 1];
            m--;
        }
        StringBuilder sb = new StringBuilder(seq);
        for(int k = 0; k < seq.Length/2; k++){
            char tmp = sb[k];
            sb[k] = sb[seq.Length - k - 1];
            sb[seq.Length - k - 1] = tmp;
        }
        return sb.ToString();
    }
    private static string getLCS(string s1, string s2, int i, int j, IDictionary<(int, int), string> memo){
        //pending
        if(i < 0 || j < 0){
            return "";
        }
        var key = (i,j);

        if(memo.ContainsKey(key)){
            return memo[key];
        }

        if(s1[i] == s2[j]){
            return memo[key] = s1[i] + getLCS(s1, s2, i - 1, j - 1, memo);
        }
        string leftSeq = getLCS(s1, s2, i - 1, j, memo);
        string rightSeq = getLCS(s1, s2, i, j - 1, memo);

        string res = "";
        if(leftSeq.Length > rightSeq.Length){
            res = leftSeq;
        }
        else{
            res = rightSeq;
        }
        return memo[key] = res;
    }
}