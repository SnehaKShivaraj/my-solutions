public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        return Math.Min(GetMinCost(cost, cost.Length - 1, new Dictionary<int, int>()), 
                        GetMinCost(cost, cost.Length - 2, new Dictionary<int, int>()));
    }
    private static int GetMinCost(int[] cost, int n, IDictionary<int, int> memo){
        if(n < 2){
            return cost[n];
        }
        if(memo.ContainsKey(n)){
            return memo[n];
        }
        return memo[n] = Math.Min(GetMinCost(cost, n - 1, memo), GetMinCost(cost, n - 2, memo)) + cost[n];
    }
}