public class Solution {
    public int OrangesRotting(int[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        var copy = grid;
        var queue = new Queue<(int, int, int)>();
        int counter = -0;
        var delrow = new int[]{-1, 0, 1, 0};
        var delcol = new int[]{0, 1, 0, -1};

        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                if(grid[i][j] == 2){
                    queue.Enqueue((i, j, 0));   
                }
            }
        }
        while(queue.Count > 0){
            var front = queue.Dequeue();
            counter = Math.Max(counter, front.Item3);

            int row = front.Item1;
            int col = front.Item2;
            for(int i = 0; i < 4; i++){
                    int nrow = row + delrow[i];
                    int ncol = col + delcol[i];
                    if( nrow >= 0 && nrow < n && ncol >= 0 && ncol < m &&
                        copy[nrow][ncol] == 1){
                            copy[nrow][ncol] = 2;
                            queue.Enqueue((nrow, ncol, front.Item3 + 1));
                        }
                
            }
        }
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                if(copy[i][j] == 1){
                    return -1;  
                }
            }
        }
        return counter;
    }
}