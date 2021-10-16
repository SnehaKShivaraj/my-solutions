public class Solution {
    public int RomanToInt(string s) {
        var add = new Dictionary<char,int>();
        add.Add('I',1);
        add.Add('V',5);
        add.Add('X',10);
        add.Add('L',50);
        add.Add('C',100);
        add.Add('D',500);
        add.Add('M',1000);
        int integer=0;
       for (int i = 0; i < s.Length; i++)
    {
        if (i + 1 < s.Length && add[s[i]] < add[s[i + 1]])
        {
            integer -= add[s[i]];
        }
        else
        {
            integer += add[s[i]];
        }
    }
        return integer;
    }
}