public class Solution {
    public int MinPathSum(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        var dp = new  int[m, n];
        dp[0, 0] = grid[0][0];
        for(int i = 0; i< m; i++){
            for(int j = 0; j< n ; j++){
                if(i == 0 && j == 0) continue;

                int left = int.MaxValue;
                int up = int.MaxValue;

                if(i > 0){
                    up = dp[i - 1, j];
                }
                if(j > 0){
                    left = dp[i, j - 1];
                }
                
                dp[i, j] = Math.Min(up, left) + grid[i][j];
            }
        }
        return dp[m - 1, n - 1];
    }
    private static int minUniquePathSum(int m, int n, int[][] grid, IDictionary<(int, int), int> memo) {
        if( m <= 0 || n <= 0){
            return int.MaxValue;
        }

        if( m == 1 && n == 1){
            return grid[0][0];
        }

        var key = (m, n);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        int minCost = Math.Min(minUniquePathSum(m - 1, n, grid, memo), minUniquePathSum(m, n - 1, grid, memo)); 
        return memo[key] = minCost +  grid[m - 1][n - 1];
    }  
}