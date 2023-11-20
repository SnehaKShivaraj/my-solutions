public class Solution {
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> result = new List<IList<string>>();
        var list = new List<string>();
        GetAllPalindromePartitions(s, 0, list, result);

        return result;
    }
    private static void GetAllPalindromePartitions(string s, int partition, IList<string> list, IList<IList<string>> result){

        if(s.Length == partition){
            result.Add(list.ToList());
            return;
        }

        for(int i = partition; i < s.Length; i++){
            
            string sb = s.Substring(partition, i + 1 - partition);
            if(IsPalidrome(sb)){
                list.Add(sb);
                //Console.WriteLine(string.Join(",",list ) + " : "+ i );

                GetAllPalindromePartitions(s, i + 1, list, result);
                list.RemoveAt(list.Count - 1);
            }
        }

    }
    private static bool IsPalidrome(string s){
        for(int i = 0; i< s.Length/2; i++){
            if(s[i] != s[s.Length - i - 1]){
                return false;
            }
        }
        return true;
    }
}