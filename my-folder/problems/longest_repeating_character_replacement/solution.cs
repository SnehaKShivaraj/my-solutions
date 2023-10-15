public class Solution {
    public int CharacterReplacement(string s, int k) {
        int max = 0, i = 0, j = 0, prev_i = 0;
        var dict = new Dictionary<char, int>();
        while(j < s.Length){
            if(dict.ContainsKey(s[j])){
                dict[s[j]] ++;
            }
            else{
                dict.Add(s[j], 1);
            }

            int max_freq = dict.Max(i => i.Value);
            if(j - i + 1 - max_freq <= k){
                max = Max(max, j - i + 1);
            }
            while(j - i + 1 - max_freq > k){
                if(dict[s[i]] == 0){
                    dict.Remove(s[i]);
                }
                dict[s[i++]]--;
            }
            j++;
        }
        return max;
    }
    private static int Max(int a, int b){
        return a > b ? a : b;
    }
}