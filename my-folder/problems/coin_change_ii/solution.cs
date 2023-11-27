public class Solution {
    public int Change(int amount, int[] coins) {
        return CountWaysToMakeChange(coins, coins.Length - 1, amount, new Dictionary<(int, int), int>());
    }

    private int CountWaysToMakeChange(int[] nums, int n, int sum, IDictionary<(int, int), int> memo){
        if( sum == 0){
            return 1;
        }
        if( n < 0){
            return 0;
        }

        var key = (n, sum);

        if(memo.ContainsKey(key)){
            return memo[key];
        }

        int ways = CountWaysToMakeChange(nums, n - 1, sum, memo);
        if(sum >= nums[n]){
            ways += CountWaysToMakeChange(nums, n , sum - nums[n], memo);
        }
        return memo[key] = ways;
    }
}