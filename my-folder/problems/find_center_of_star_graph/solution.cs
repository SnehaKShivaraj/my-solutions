public class Solution {
    private static void AddOrUpdate(IDictionary<int, int> dict, int key){
        if(dict.ContainsKey(key)){
            dict[key] += 1;
            return;
        }
        dict.Add(key, 1); 
    }
    public int FindCenter(int[][] edges) {
        //(node, tot connecting edges)
        var dict = new Dictionary<int, int>();

        for(int i = 0; i < edges.Length; i++){
            AddOrUpdate(dict, edges[i][0]);
            AddOrUpdate(dict, edges[i][1]);
        }

        (int, int) centerNode = (0, 0);


        foreach(var pair in dict){
            if(pair.Value >= centerNode.Item2){
                centerNode = (pair.Key, pair.Value);
            }
        }
        return centerNode.Item1;
    }

}