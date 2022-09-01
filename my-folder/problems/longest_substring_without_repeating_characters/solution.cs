public class Solution {
    public int LengthOfLongestSubstring(string s) {
              int l=0;
      var set = new List<char>();
      int max=0;
      for(int r=0;r<s.Length;r++)
      {
         while(set.Contains(s[r]))
         {
             set.RemoveAt(0);
         }
          set.Add(s[r]);
          max = max>set.Count?max:set.Count;
             
      }
      return max;
    }
    
}