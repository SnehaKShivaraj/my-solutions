public class Solution {
    public int MaxProfit(int[] prices) {
    return GetMaxProfit(prices, 0, true, 0, new Dictionary<(int, bool, int), int>());
    }
    private static int GetMaxProfit(int[] prices, int i, bool canBuy, int tot, IDictionary<(int, bool, int), int> memo){
        if(i == prices.Length || tot >= 2){
            return 0;
        }
        
        var key = (i, canBuy, tot);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        if(canBuy){
            //When bought reduce the cp from profit and set block further buys otherwise just take profit as no cp involved.
            return memo[key] = Math.Max(GetMaxProfit(prices, i + 1, false, tot, memo) - prices[i], GetMaxProfit(prices, i + 1, true, tot, memo));
        }
        return memo[key] = Math.Max(GetMaxProfit(prices, i + 1, true, tot + 1, memo) + prices[i], GetMaxProfit(prices, i + 1, false, tot, memo));
    }
}