public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        var dp = new  int[m, n];
        if(obstacleGrid[0][0] == 1){
            return 0;
        }
        dp[0, 0] = 1;
        for(int i = 0; i< m; i++){
            for(int j = 0; j< n ; j++){
                if(i == 0 && j == 0) continue;
                if(obstacleGrid[i][j] == 1) {
                    dp[i, j] = 0;
                    continue;
                }

                dp[i, j] = 0;
                if(i > 0){
                    dp[i, j] += dp[i - 1, j];
                }
                if(j > 0){
                    dp[i, j] += dp[i, j - 1];
                }
                
            }
        }
        return dp[m - 1, n - 1];
    }
    private static int countUniquePaths(int m, int n, int[][] grid, IDictionary<(int, int), int> memo) {
        if( m == 0 && n == 0 && grid[m][n] == 0){
            return 1;
        }

        if( m < 0 || n < 0 || grid[m][n] == 1){
            return 0;
        }
        var key = (m, n);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        return memo[key] = countUniquePaths(m - 1, n, grid, memo) + countUniquePaths(m, n - 1, grid, memo);
    }    
}