public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adj = new List<List<(int, int)>>();

        for(int i = 0; i <= n; i++){
            adj.Add(new List<(int, int)>());
        }
        for(int i = 0 ; i < times.Length; i++){
            int u = times[i][0], v = times[i][1], w = times[i][2];
            adj[u].Add((v, w));
        }

        int[] dist = new int[n + 1];
        for(int i = 1; i < n + 1; i++){
            dist[i] = int.MaxValue;
        }
        //node, price
        var set = new SortedSet<(int, int)>();
        dist[k] = 0;
        set.Add((k, 0));

        while(set.Count > 0){
            var pair = set.First();
            set.Remove(pair);
            int node = pair.Item1, wt = pair.Item2;
            
             foreach(var adjPair in adj[node]){
                int adjNode = adjPair.Item1;
                int adjWt = adjPair.Item2 + wt;
                
                if(adjWt < dist[adjNode]){
                    set.Add((adjNode, adjWt));
                    dist[adjNode] = adjWt;
                }

            }
           
        }

        int minCost = 0;
        for(int i = 1; i < n + 1; i++){
            if(dist[i] == int.MaxValue){
                return -1;
            }
            minCost = Math.Max(minCost, dist[i]);
        }
        return minCost;
    }
}