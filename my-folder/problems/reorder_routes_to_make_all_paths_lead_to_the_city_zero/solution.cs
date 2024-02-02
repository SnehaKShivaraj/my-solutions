public class Solution {
    public int MinReorder(int n, int[][] connections) {
        int result = 0;
        var queue = new Queue<int>();
        var adj = new List<List<int>>();
        var back = new List<List<int>>();

        for(int i = 0; i < n; i++){
            adj.Add(new List<int>());
            back.Add(new List<int>());
        }
        for(int i = 0; i < connections.Length; i++){
            adj[connections[i][0]].Add(connections[i][1]);
            back[connections[i][1]].Add(connections[i][0]);
        }

        var visited = new bool[n];

                queue.Enqueue(0);
                while(queue.Count > 0){
                    int node = queue.Dequeue();
                    visited[node] = true;

                    foreach(int adjNode in adj[node]){
                        if(visited[adjNode] == false){
                            result += 1;
                            queue.Enqueue(adjNode);
                        }
                    }
                    foreach(int adjNode in back[node]){
                        if(visited[adjNode] is false){
                            queue.Enqueue(adjNode);
                        }
                    }
                }
            
            
            

        return result;
    }
}