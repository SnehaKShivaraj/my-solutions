public class Solution {
    public bool IsValid(string s) {
    var stack = new Stack<char>();
    var dict = new Dictionary<char,char>();
    dict.Add('(',')');
    dict.Add('{','}');
    dict.Add('[',']');   
    foreach(char i in s)
    {
        if(i == '(' || i =='{' || i == '[')
            stack.Push(i);
        else
        {
            if(stack.Count == 0)
                return false;
            char elem = stack.Pop();
            if( dict[elem] != i)
                return false;
        }
    }
    
    return stack.Count == 0 ;    
    }
}