public class Solution {
    public int MinFallingPathSum(int[][] matrix) {

      
        int min = int.MaxValue;
        for(int i = 0 ; i < matrix.Length; i++){ 
            min = Math.Min(GetMinFallingPathSum(matrix, matrix.Length - 1, i, new Dictionary<(int, int), int>()), min);
        }
        return min;
    }
    private static int GetMinFallingPathSum(int[][] matrix, int row, int col, IDictionary<(int, int), int> memo){
        
        if(col < 0 || col >= matrix[0].Length){
            return int.MaxValue;
        }
        if(row == 0){
            return matrix[row][col];
        }

        var key = (row, col);
        if(memo.ContainsKey(key)){
            return memo[key];
        }
        return memo[key] = Math.Min(Math.Min(GetMinFallingPathSum(matrix, row - 1, col - 1, memo), 
                                GetMinFallingPathSum(matrix, row - 1, col, memo)),
                                         GetMinFallingPathSum(matrix, row - 1, col + 1, memo))
                                + matrix[row][col];
    }
}