public class Solution {
    public int Rob(int[] nums) {
        var dp = new int[nums.Length];
        Array.Fill(dp, 0);

        dp[0] = nums[0];
        for(int i = 1; i < nums.Length; i++){
            int sum = nums[i];
            if(i > 1){
                sum +=  dp[i - 2];
            }
            dp[i] = Math.Max(sum,
                        dp[i - 1]);
        };
        return dp[nums.Length - 1];    
    }
}