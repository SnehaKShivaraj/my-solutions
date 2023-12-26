public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        var set = new SortedSet<(int, int, int)>();
        int n = heights.Length, m = heights[0].Length;
        int[,] dist = new int[n, m];
        int minEffort = 0;
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                dist[i, j] = (int)1e9;
            }
        }
        dist[0, 0] = 0;
        set.Add((0, 0, 0));

        int[] delRow = new int[4]{-1, 0, +1, 0};
        int[] delCol = new int[4]{0, +1, 0, -1};
        while(set.Count > 0){
            var effortCell = set.First();
            int effort = effortCell.Item1, row = effortCell.Item2, col = effortCell.Item3;
            set.Remove(effortCell);

            if(row == n - 1 && col == m -1){
                minEffort = effort;
                break;
            }
            for(int i = 0; i < 4; i++){
                int nrow = delRow[i] + row;
                int ncol = delCol[i] + col;
                
                if(nrow >= 0 && nrow < n && ncol >=0 && ncol < m){
                    int distance = Math.Abs(heights[row][col] - heights[nrow][ncol]);
                    int newEffort = Math.Max(distance, effort);
                    if(newEffort < dist[nrow, ncol]){
                        dist[nrow, ncol] = newEffort;
                        set.Add((newEffort, nrow, ncol));
                    }
                }
            }
        }
        return minEffort;
    }
}