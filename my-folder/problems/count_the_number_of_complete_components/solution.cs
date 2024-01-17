public class Solution {
    public int CountCompleteComponents(int n, int[][] edges) {
        var adj = new List<List<int>>();
        var visited = new bool[n];
        for(int i = 0; i <n; i++){
            adj.Add(new List<int>());
        }
        for(int i = 0; i < edges.Length; i++){
            int u = edges[i][0], v = edges[i][1];
            adj[u].Add(v);
            adj[v].Add(u);
        }
        int totCompleteComp = 0;
        for(int i = 0; i < n; i++){
            if(visited[i] is false){
                var pair = bfs(adj, i, visited);
                int nodes = pair.Item1, totedges = pair.Item2;
                if((nodes*(nodes - 1))/2 == totedges){
                    totCompleteComp += 1;
                }
            }
        }
        return totCompleteComp;
    }
    private static Tuple<int, int> bfs(List<List<int>> adj, int node, bool[] visited){
        int nodes = 0, edges = 0;
        var queue = new Queue<int>();
        
        queue.Enqueue(node);

        while(queue.Count > 0){
            int curNode = queue.Dequeue();

            if(visited[curNode] is true){
                continue;
            }
            nodes += 1;
            visited[curNode] = true;

            foreach(int adjNode in adj[curNode]){
                if(visited[adjNode] is false){
                    queue.Enqueue(adjNode);
                    edges += 1;
                }
            } 
        }
        return Tuple.Create(nodes, edges);
    }
}