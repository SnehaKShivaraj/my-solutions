public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        int[,] dist = new int[n, m];
        var queue = new Queue<(int, int, int)>();

        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                dist[i, j] = (int)1e9;
            }
        }
        if(grid[0][0] == 0){
            dist[0, 0] = 0;
            queue.Enqueue((0, 0, 0));
        }

        int[] delRow = new int[8]{-1, -1, 0, +1, +1, +1, 0, -1};
        int[] delCol = new int[8]{ 0, +1, +1, +1, 0, -1, -1, -1};
        while(queue.Count > 0){
            var costCell = queue.Dequeue();
            int row = costCell.Item1, col = costCell.Item2, cost = costCell.Item3;

            for(int i = 0; i < 8; i++){
                int nrow = row + delRow[i] ;
                int ncol = col + delCol[i] ;

                if(nrow >= 0 && ncol >= 0 && nrow < n && ncol < m && grid[nrow][ncol] == 0 ){
                    if(cost + 1 < dist[nrow, ncol]){
                        dist[nrow, ncol] = cost + 1;
                        queue.Enqueue((nrow, ncol, dist[nrow, ncol]));
                    }
                }
            }

        }

        if(dist[n - 1, m - 1] == (int)1e9){
            return -1;
        }
        return dist[n - 1, m - 1] + 1;
    }
}