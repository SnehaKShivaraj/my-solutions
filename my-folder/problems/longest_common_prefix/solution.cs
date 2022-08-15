public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        string lPrefix = "";
        foreach(var letter in strs[0])
        {
            string temp = lPrefix+letter ;
            if(!strs.All(str=>str.StartsWith(temp)))
            {
                   break;
            }
            lPrefix = temp;   
        }
        
        return lPrefix;
    }

}