public class Solution {
    public void Solve(char[][] board) {
        int n = board.Length, m = board[0].Length;
        bool[,] visited = new bool[n, m];
        //first row && last row
        for(int i = 0; i < m; i++){
            if(visited[0, i] == false && board[0][i] == 'O'){
                dfs(0, i, visited, board);
            }
            if(visited[n - 1, i] == false && board[n - 1][i] == 'O'){
                dfs(n - 1, i, visited, board);
            }
        }
        for(int i = 0; i < n; i++){
            if(visited[i, 0] == false && board[i][0] == 'O'){
                dfs(i, 0, visited, board);
            }
            if(visited[i, m - 1] == false && board[i][m - 1] == 'O'){
                dfs(i, m - 1, visited, board);
            }
        }
        for(int i = 0; i < n; i++){
            for(int j = 0; j< m; j++){
                if(visited[i, j] == false && board[i][j] == 'O'){
                    board[i][j] = 'X';
                }
            }
        }
    }
    private static void dfs(int row, int col, bool[,] visited, char[][] board){
        visited[row, col] = true;
        int[] delrow = {-1, 0, 1, 0};
        int[] delcol = {0, 1, 0, -1};
        for(int i = 0; i< 4; i++){
            int nrow = row + delrow[i];
            int ncol = col + delcol[i];
            if(nrow >= 0 && nrow < board.Length && ncol >= 0 && ncol < board[0].Length && visited[nrow, ncol] == false && board[nrow][ncol] == 'O'){
                //Console.WriteLine("roe {0}, col {col}, val - {3}", nrow, ncol, board[nrow][ncol]);
                dfs(nrow, ncol, visited, board);
            }
        }
    }
}