public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        var adj = new List<List<int>>();
        var list = new List<int>();
        var inDeg = new int[graph.Length];
        var queue = new Queue<int>();
        
        for(int i = 0; i < graph.Length; i++){
            adj.Add(new List<int>());
        }

        for(int i = 0; i < graph.Length; i++){
            
            for(int j = 0; j < graph[i].Length; j++){
                //reversing the out node to in 
                int outNode = graph[i][j];
                adj[outNode].Add(i);
                inDeg[i]++;
            }
        }

        for(int i = 0; i < graph.Length; i++){
            if(inDeg[i] == 0){
                queue.Enqueue(i);
            }
        }

        while(queue.Count > 0){
            int node = queue.Dequeue();
            list.Add(node);

            foreach(int edge in adj[node]){
                inDeg[edge]--;
                if(inDeg[edge] == 0){
                    queue.Enqueue(edge);
                }
            }
        }

        list.Sort();

        return list;
    }
}