public class Solution {
    public int MinCost(int n, int[] cuts) {
        int size = cuts.Length + 2;
        var arr = new int[size];
        for(int i = 0; i < cuts.Length; i++){
            arr[i + 1] = cuts[i]; 
        }
        arr[size - 1] = n;
        Array.Sort(arr);
        return GetMinCost(arr, 1, cuts.Length, new Dictionary<(int, int), int>());
    }
    private static int GetMinCost(int[] cuts, int i, int j, IDictionary<(int, int), int> memo){
        if(i > j){
            return 0;
        }

        var key = (i, j);
        if(memo.ContainsKey(key)){
            return memo[key];
        }
        int minCost = int.MaxValue;
        for(int ind = i; ind <= j; ind++){
            int cost = cuts[j + 1] - cuts[i - 1];
            cost += GetMinCost(cuts, i, ind - 1, memo);
            cost += GetMinCost(cuts, ind + 1, j, memo);

            minCost = Math.Min(minCost, cost);
        }
        return memo[key] = minCost;
    }
}