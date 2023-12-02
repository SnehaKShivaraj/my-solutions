public class Solution {
    public int LengthOfLIS(int[] nums) {
        //return GetIncreasingSubSeqLen(nums, 0, -1, new Dictionary<(int, int), int>());
        return GetIncreasingSubSeqLenTab(nums);
    }
    private static int GetIncreasingSubSeqLenTab(int[] nums){
        var dp = new int[nums.Length + 1, nums.Length + 1];

        for(int i = nums.Length - 1; i >= 0; i--){
            for(int j = i - 1; j >= -1; j--){
                dp[i, j + 1] = dp[i + 1, j + 1];
                if(j  == -1 || nums[j ] < nums[i]){
                    dp[i, j + 1] = Math.Max(dp[i, j + 1], 1 + dp[i + 1, i + 1] );
                }
            }
        }
        return dp[0, 0];
    }
    private static int GetIncreasingSubSeqLen(int[] nums, int cur, int prev, IDictionary<(int, int), int> memo){
        if(cur == nums.Length){
            return 0;
        }
        var key = (cur, prev);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        if(prev == -1 || nums[prev] < nums[cur]){
            return memo[key] = Math.Max(GetIncreasingSubSeqLen(nums, cur + 1, prev, memo), 
                            GetIncreasingSubSeqLen(nums, cur + 1, cur, memo) + 1);
        }
        return memo[key] = GetIncreasingSubSeqLen(nums, cur + 1, prev, memo);
    }
}