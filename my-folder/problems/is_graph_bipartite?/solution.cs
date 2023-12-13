public class Solution {
    public bool IsBipartite(int[][] graph) {
        int n = graph.Length;
        var queue = new Queue<int>();
        var adj = new List<List<int>>();
        int[] color  = new int[n];
        Array.Fill(color, -1);

        for(int i = 0; i < n; i++){
            var adjNodes = new List<int>();
            for(int j = 0; j < graph[i].Length; j++){
                adjNodes.Add(graph[i][j]);
            }
            adj.Add(adjNodes);
        }
        for(int i = 0; i < adj.Count; i++){
            if(color[i] == -1){
                if(!bfs(i, queue, adj, color)){
                    return false;
                }
            }
        }
        return true;   
    }
    private static bool bfs(int start, Queue<int> queue, List<List<int>> adj, int[] color){
        queue.Enqueue(start);
        color[start] = 0;

        while(queue.Count > 0){
            int node = queue.Dequeue();
            foreach(var neighbour in adj.ElementAt(node)){
                if(color[neighbour] == -1){
                    color[neighbour] = 1 - color[node];
                    queue.Enqueue(neighbour);
                }
                else if(color[neighbour] == color[node]){
                    return false;
                }
            }
        }
        return true;
    }
}