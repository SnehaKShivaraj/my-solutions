public class Solution {
    public int Fib(int n) {
        return GetFibNumber(n);
    }
    private static int GetFibNumber(int n){
        if( n <= 1){
            return n;
        }
        return GetFibNumber(n - 1) + GetFibNumber(n - 2);
    }
}