public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        IList<IList<string>> res = new List<IList<string>>();
        var dict = new Dictionary<string, int>();
        var mapMerge = new Dictionary<int, List<string>>();
        var disSet = new DisjointSet(accounts.Count);

        for(int i = 0; i < accounts.Count; i++){
            for(int j = 1; j < accounts[i].Count; j++){
                string mail = accounts[i][j];
                if(dict.ContainsKey(mail)){
                    disSet.UnionBySize(dict[mail], i);
                    continue;
                }
                dict.Add(mail, i);
            }
        }
        foreach(var pair in dict){
            string mail = pair.Key;
            int node = pair.Value;

            int u_p = disSet.FindUltimateParent(node);

            if(mapMerge.ContainsKey(u_p)){
                mapMerge[u_p].Add(mail);
                continue;
            }
            else{
                mapMerge.Add(u_p,  new List<string>{mail});

            }
        }

        foreach(var pair in mapMerge){
            var temp = new List<string>{accounts[pair.Key][0]};
            pair.Value.Sort(StringComparer.Ordinal);
            temp.AddRange(pair.Value);
            res.Add(temp);
        }
        return res;
    }
}
class DisjointSet{
    IList<int> size = new List<int>();
    IList<int> parent = new List<int>();

    public DisjointSet(int n){

        for(int i = 0; i <= n; i++){
            size.Add(1);
            parent.Add(i);
        }   
    }
    public void UnionBySize(int x, int y){
        int up_x = FindUltimateParent(x);
        int up_y = FindUltimateParent(y);

        if(up_x == up_y){
            return;
        }

        if(size[up_x] >= size[up_y]){
            parent[up_y] = up_x;
            size[up_x] += size[up_y];
        }
        else{
            parent[up_x] = up_y;
            size[up_y] += size[up_x];
        }
    }
    public int FindUltimateParent(int node){
        var nodes = new List<int>();
        
        while(parent[node] != node){
            nodes.Add(node);
            node = parent[node];
        }

        foreach(int pNode in nodes){
            parent[node] = node;
        }

        return node;
    }
}