public class Solution {
    public int LengthOfLastWord(string s) {
        int len=0;
        bool complete=false;
        for(int i=s.Length-1;i>=0;i--){
            if(char.IsLetter(s[i]))
            {
                len++;
                complete=true;
            }
            else{
                if(complete)
                return len;
            }
        }
        return len;
    }
}