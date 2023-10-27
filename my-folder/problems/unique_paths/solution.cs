public class Solution {
public int UniquePaths(int m, int n) {
      return uniquePath(m, n, new Dictionary<string, int>());
    }
    private int uniquePath(int m, int n, IDictionary<string, int> memo){
        if(m == 0 || n == 0) return 0;
        if(m == 1 && n == 1) return 1;
        string key = m + "+" + n;
        if(memo.ContainsKey(key)) return memo[key];

        int value = uniquePath(m-1, n, memo) + uniquePath(m, n-1, memo);
        if(!memo.ContainsKey(key)) memo.Add(key, value);

        return memo[key];
    }
}
