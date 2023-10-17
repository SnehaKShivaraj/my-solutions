public class Solution {
    public int EqualSubstring(string s, string t, int maxCost) {
        int tempCost = 0, max = 0, j = 0;
        
        for(int i = 0; i < s.Length; i++){

            tempCost = tempCost + Math.Abs(t[i] - s[i]);
            if(tempCost <= maxCost){
                max = Max(max, i - j + 1);
                continue;
            }
            while(tempCost > maxCost){
               tempCost -= Math.Abs(s[j] - t[j]);
               j++; 
            }
        }
        return max;  
    }
    private static int Max(int a, int b){
        return a > b ? a : b;
    }
}