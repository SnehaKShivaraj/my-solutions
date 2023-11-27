public class Solution {
    public int CoinChange(int[] coins, int amount) {
        
    int change = getAllSubSets(coins, coins.Length - 1, amount, new Dictionary<(int, int), int>());
    return change >= int.MaxValue - 1 ? - 1: change;
    }

    private int getAllSubSets(int[] nums, int n, int sum, IDictionary<(int, int), int> memo){
        if( sum == 0){
            return 0;
        }
        if( n < 0){
            return int.MaxValue - 1;
        }

        var key = (n, sum);

        if(memo.ContainsKey(key)){
            return memo[key];
        }

        int ways = getAllSubSets(nums, n - 1, sum, memo);

        if(sum >= nums[n]){
            ways = Math.Min(getAllSubSets(nums, n , sum - nums[n], memo) + 1, ways);

        }

        return memo[key] = ways;
    }
}