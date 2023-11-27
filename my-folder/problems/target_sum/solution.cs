public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        int tot = nums.Sum();
        if(tot - target < 0 || (tot - target) % 2 == 1){
            return 0;
        }
        return getAllSubSets(nums, nums.Length - 1, (tot - target)/2, new Dictionary<(int, int), int>());
    }

    private int getAllSubSets(int[] nums, int n, int sum, IDictionary<(int, int), int> memo){
        if( sum == 0 && n < 0){
            return 1;
        }
        if( n < 0){
            return 0;
        }

        var key = (n, sum);

        if(memo.ContainsKey(key)){
            return memo[key];
        }

        int ways = getAllSubSets(nums, n - 1, sum, memo);
        if(sum >= nums[n]){
            ways += getAllSubSets(nums, n - 1, sum - nums[n], memo);
        }
        return memo[key] = ways;
    }
}