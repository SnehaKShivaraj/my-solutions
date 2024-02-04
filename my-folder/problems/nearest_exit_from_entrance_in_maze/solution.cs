public class Solution {
    public int NearestExit(char[][] maze, int[] entrance) {
        int minSteps = int.MaxValue;
        var queue= new Queue<(int, int, int)>();
        int m = maze.Length, n = maze[0].Length;
        var visited = new bool[m, n];

        queue.Enqueue((entrance[0], entrance[1], -1));

        var delRow = new int[]{-1, 0, +1, 0};
        var delCol = new int[]{0, +1, 0, -1};

        while(queue.Count > 0){
            var item = queue.Dequeue();
            int row = item.Item1, col = item.Item2, steps = item.Item3;


            if(steps != -1 && (row == 0 || col == 0 || row == m - 1 || col == n -1)){
                minSteps = Math.Min(minSteps, steps);
            }

            if(steps == -1){
                steps = 0;
                visited[row, col] = true; 
            }
            for(int i = 0; i < 4; i++){
                int nrow = delRow[i] + row;
                int ncol = delCol[i] + col;

                if(nrow >= 0 && nrow < m && ncol >= 0 && ncol < n && visited[nrow, ncol] is false && maze[nrow][ncol] == '.'){
                    queue.Enqueue((nrow, ncol, steps + 1));
                    visited[nrow, ncol] = true;
                }
            }
        }

        return minSteps == int.MaxValue ? -1 : minSteps;
    }
}