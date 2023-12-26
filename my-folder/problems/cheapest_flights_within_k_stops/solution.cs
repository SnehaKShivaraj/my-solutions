public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var adj = new List<List<(int, int)>>();
        var dist = new int[n];
        var queue = new Queue<(int, int, int)>();
        for(int i = 0 ; i < n; i++){
            adj.Add(new List<(int, int)>());
            dist[i] = int.MaxValue;
        }

        for(int i = 0; i < flights.Length; i++){
            int s = flights[i][0], d = flights[i][1], cost = flights[i][2];
            adj[s].Add((d, cost));
        }

        dist[src] = 0;
        queue.Enqueue((0, src, 0));

        while(queue.Count > 0){
            var ds = queue.Dequeue();
            int stops = ds.Item1, node = ds.Item2, cost = ds.Item3;

            if(stops > k ){
                continue;
            }

            foreach(var pair in adj[node]){
                int adjNode = pair.Item1;
                int newPrice = pair.Item2 + cost;

                if(newPrice < dist[adjNode] && stops <= k){
                    dist[adjNode] = newPrice;
                    queue.Enqueue((stops + 1, adjNode, newPrice));
                }
            }
        }

        int minCost = -1;
        if(dist[dst] != int.MaxValue){
            minCost = dist[dst];
        }

        return minCost;
    }
}