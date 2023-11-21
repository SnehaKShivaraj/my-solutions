public class Solution {
    public int ClimbStairs(int n) {
        var dp = new int[n + 1];
        Array.Fill(dp, -1);
        return GetTotalWaysToClimbStairs(n, dp);
    }
    private static int GetTotalWaysToClimbStairs(int n, int[] dp){
        if( n <= 2){
            return n;
        }
        if(dp[n] != -1){
            return dp[n];
        }
        return dp[n] =  GetTotalWaysToClimbStairs(n - 1, dp) + 
                        GetTotalWaysToClimbStairs(n - 2, dp);
        
    }
}