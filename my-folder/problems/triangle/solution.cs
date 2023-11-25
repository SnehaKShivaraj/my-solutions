public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        int m = triangle.Count;
        int n = triangle[m - 1].Count;
        var dp = new int[m, n];
        for(int j = 0; j < n; j++){
            dp[n - 1, j] = triangle[m - 1][j];
        }

        for(int i = m - 2; i >= 0; i--){
            for(int j = i; j >= 0; j--){
                dp[i, j] = triangle[i][j];
                dp[i, j] += Math.Min(dp[i + 1, j], dp[i + 1, j + 1]);

            }
        }
        return dp[0, 0];
        //return GetMinimumPath(triangle, 0, 0, new Dictionary<(int, int), int>());
    }
    private static int GetMinimumPath(IList<IList<int>> triangle, int row, int rowIndex, IDictionary<(int, int), int> memo){
        if( row == triangle.Count){
            return 0;
        }
        var key = (row, rowIndex);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        int minCostPath = Math.Min(GetMinimumPath(triangle, row + 1, rowIndex, memo),
                          GetMinimumPath(triangle, row + 1, rowIndex + 1, memo));

        return memo[key] = minCostPath + triangle[row][rowIndex];
    }
}