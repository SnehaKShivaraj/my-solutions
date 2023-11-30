public class Solution {
    public int MaxProfit(int[] prices) {
        int minCostPrice =  prices[0];
        int maxProfit = 0;
        
        for(int i = 1; i < prices.Length; i++){
            maxProfit = Math.Max(prices[i] - minCostPrice, maxProfit);
            minCostPrice = Math.Min(prices[i], minCostPrice);
        }
        return maxProfit;
    }
}