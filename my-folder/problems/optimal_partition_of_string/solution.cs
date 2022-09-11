public class Solution {
    public int PartitionString(string s) {
        
        var list = new List<string>();
        
        string temp = "";
        for(int i=0; i< s.Length; i++)
        {
            if(temp.Contains(s[i]))
            {
                list.Add(temp);
                temp=s[i].ToString();
            }
            else
            {
                temp+=s[i].ToString();
            }
        }
        if( !string.IsNullOrEmpty(temp))
                list.Add(temp);
        return list.Count;
        
    }
}