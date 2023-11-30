public class Solution {
    public int MaxProfit(int[] prices) {
        return GetMaxProfit(prices, 0, true, new Dictionary<(int, bool), int>());
    }
    private static int GetMaxProfit(int[] prices, int i, bool canBuy, IDictionary<(int, bool), int> memo){
        if(i == prices.Length){
            return 0;
        }
        
        var key = (i, canBuy);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        if(canBuy){
            //When bought reduce the cp from profit and set block further buys otherwise just take profit as no cp involved.
            return memo[key] = Math.Max(GetMaxProfit(prices, i + 1, false, memo) - prices[i], GetMaxProfit(prices, i + 1, true, memo));
        }
        return memo[key] = Math.Max(GetMaxProfit(prices, i + 1, true, memo) + prices[i], GetMaxProfit(prices, i + 1, false, memo));
    }
}