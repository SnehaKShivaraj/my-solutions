class Solution {
    public boolean canPartition(int[] nums) {
    int k = 0, n = nums.length;
     for(int i = 0; i< n; i++){
         k += nums[i];
     }
     if(k % 2 == 1) return false;

     k /= 2;
     
     boolean dp[][] = new boolean[n][k + 1];

        for(int i = 0; i < n; i++){
            dp[i][0] = true;
        }
        if(nums[0] <=k) {
            dp[0][nums[0]] = true;
        }
        for(int i = 1; i < n; i++){
            for(int j = 1; j <= k; j++){
                if(nums[i] <= j){
                    dp[i][j] = dp[i - 1][j - nums[i]] ||  dp[i - 1][j];
                    continue;
                }
                dp[i][j] = dp[i - 1][j];
            }
        }
        return dp[n - 1][k];   
    }
}