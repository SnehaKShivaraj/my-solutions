public class Solution {
    public int NumEnclaves(int[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        bool[,] visited = new bool[n, m];
        var queue = new Queue<(int, int)>();
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                if( i == 0 || j == 0 || i == n - 1 || j == m - 1){
                    if(grid[i][j] == 1){
                        queue.Enqueue((i, j));
                        visited[i, j] = true;
                    }
                }
            }
        }

        bfs(queue, visited, grid);

        int counter = 0;
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                if(visited[i, j] == false && grid[i][j] == 1){
                    counter += 1;
                }
            }
        }
        return counter;
    }
    private static void bfs(Queue<(int, int)> queue, bool[,] visited, int[][] grid)
    {
        int[] delrow = {-1, 0, 1, 0};
        int[] delcol = {0, 1, 0, -1};

        while(queue.Count > 0){
            var pair = queue.Dequeue();
            int row = pair.Item1;
            int col = pair.Item2;
            for(int i = 0; i < 4; i++){
                int nrow = row + delrow[i];
                int ncol = col + delcol[i];
                if(nrow >= 0 && nrow < grid.Length && ncol >=0 && ncol < grid[0].Length &&
                    visited[nrow, ncol] == false && grid[nrow][ncol] == 1){
                        visited[nrow, ncol] = true;
                        queue.Enqueue((nrow, ncol));
                    }
            }
        }
    }
}