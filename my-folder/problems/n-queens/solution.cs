public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        IList<IList<string>> result = new List<IList<string>>(); 

        int[] rowHash = new int[n], upperDiagonalHash = new int[2 * n - 1], lowerDiagonalHash = new int[2 * n - 1];
        string s = new string('.', n);
        var board = new List<string>();

        for (int i = 0; i < n; i++) {
            board.Add(s);
        }

        GetAllNQueenSolutions(0, n, rowHash, upperDiagonalHash, lowerDiagonalHash, board, result);
        
        return result;
    }

    private static void GetAllNQueenSolutions(int col,
                                              int n, 
                                              int[] rowHash, 
                                              int[] upperDiagonalHash, 
                                              int[] lowerDiagonalHash, 
                                              IList<string> board, 
                                              IList<IList<string>> result){
        if( col == n){


            result.Add(board.ToList());
            return;
        }

        for(int row = 0; row < n; row++){
            if(rowHash[row] == 0 &&
                lowerDiagonalHash[row + col] == 0 &&
                upperDiagonalHash[n - 1 + row - col] == 0){

                    board[row] = Construct(board[row], col, 'Q');
                    rowHash[row] = lowerDiagonalHash[row + col] = upperDiagonalHash[n - 1 + row - col] = 1;

                    GetAllNQueenSolutions(col + 1, n, rowHash, upperDiagonalHash, lowerDiagonalHash, board, result);

                    board[row] = Construct(board[row], col, '.');
                    rowHash[row] = lowerDiagonalHash[row + col] = upperDiagonalHash[n - 1 + row - col] = 0;
                }
        }
    }
    private static string Construct(string s, int index, char newChar){
        var sb = new StringBuilder(s);
        sb[index] = newChar;
        return sb.ToString();
    }
}