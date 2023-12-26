public class Solution {
    public int CountPaths(int n, int[][] roads) {
        var ways = new int[n];
        var dist = new long[n];
        for(int i = 0; i <n; i++){
            dist[i]= long.MaxValue;
        }

        var adj = new List<List<(int, long)>>();
        for(int i = 0; i < n; i++){
            adj.Add(new List<(int, long)>());
        }

        for(int i = 0; i < roads.Length; i++){
            int u = roads[i][0], v = roads[i][1], price = roads[i][2];
            adj[u].Add((v, price)); 
            adj[v].Add((u, price)); 

        }
        int mod = (int) (1e9 + 7);
        var set = new SortedSet<(long, int)>();

        dist[0] = 0;
        ways[0] = 1;
        //(price, node)
        set.Add((0, 0));

        while(set.Count() > 0){
            var pair = set.First();
            set.Remove(pair);
            long price = pair.Item1;
            int node = pair.Item2;


            foreach(var item in adj[node]){

                int adjNode = item.Item1;
                long edW = item.Item2;
                long newPrice = price + edW;

                if(newPrice < dist[adjNode]){
                    dist[adjNode] = newPrice;
                    ways[adjNode] = ways[node];
                    set.Add((newPrice, adjNode));   
                }

                else if(newPrice == dist[adjNode]){
                    ways[adjNode] = (ways[adjNode] + ways[node])% mod;
                }
            }
        }
        return (ways[n - 1]) % mod;
    }
}