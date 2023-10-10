public class Solution {
    public int LengthOfLongestSubstring(string s) {
        
        var set = new List<char>();
        int i = 0, j = 0, max = 0;
        while(j < s.Length)
        {
            if(!set.Contains(s[j]))
            {
                set.Add(s[j]);
            }
            else{
                while(s[j] != s[i])
                {
                    set.Remove(s[i]);
                    i++;
                }
                i++;
            } 
            max = Maximum(max, j - i + 1);
            j++;   
        }
        return max;

    }
    private static int Maximum(int num1, int num2)
    {
        return num1 > num2 ? num1 : num2;
    }
}