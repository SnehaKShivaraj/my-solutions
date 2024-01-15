public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        var visited = new bool[n];
        var adjList = new List<List<int>>();

        for(int i = 0 ; i < n; i++){
            adjList.Add(new List<int>());
        }
        for(int i = 0; i < edges.Length; i++){
            int u = edges[i][0];
            int v = edges[i][1];
            adjList[u].Add(v);
            adjList[v].Add(u);
        }
        bfs(visited, source, adjList);
        //dfs(visited, source, adjList);
        return visited[destination];
    }
    private static void bfs(bool[] visited, int source, List<List<int>> adj){
        var queue = new Queue<int>();

        queue.Enqueue(source);
        while(queue.Count > 0){
            int node = queue.Dequeue();
            visited[node] = true;

            foreach(int adjNode in adj[node]){
                if(visited[adjNode] is false){
                    queue.Enqueue(adjNode);
                }
            }
        }
    }
    private static void dfs(bool[] visited, int node, List<List<int>> adj){
        visited[node] = true;

        foreach(int adjNode in adj[node]){
            if(visited[adjNode] is false){
                dfs(visited, adjNode, adj);
            }
        }
    }
}