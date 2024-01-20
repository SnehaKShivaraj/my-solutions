public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var res = new List<IList<int>>();
        int n = numRows;
        var matrix = new int[n, n];
        matrix[0, n - 1] = 1;

        int pos = n - 1;
        for(int i = 1; i < n; i++){
            pos -= 1;
            for(int j = pos; j < n; j++){

                if(j == n - 1){
                    matrix[i, j] = 1;
                    continue;
                }
                matrix[i, j] = matrix[i - 1, j] + matrix[i - 1, j + 1];
            }
        }
        pos = n;
        for(int i = 0; i < n; i++){
            pos -= 1;
            var list = new List<int>();
            for(int j = pos; j < n; j++){
                list.Add(matrix[i, j]);
            }
            res.Add(list);
        }
        return res;
    }
}