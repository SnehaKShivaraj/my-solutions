public class Solution {
    public int Tribonacci(int n) {
        return GetTribonacciNumber(n, new Dictionary<int, int>()); 
    }
    private static int GetTribonacciNumber(int n, IDictionary<int, int> memo){
        if(n < 3){
            if(n == 0){
                return 0;
            }
            return 1;
        }
        if(memo.ContainsKey(n)){
            return memo[n];
        }
        return memo[n] = GetTribonacciNumber(n - 1, memo) + GetTribonacciNumber(n - 2, memo) + GetTribonacciNumber(n - 3, memo);
    }
}