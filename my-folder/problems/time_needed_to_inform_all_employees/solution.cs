public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        var queue = new Queue<(int, int)>();
        var graph = new List<List<int>>();
        
        for(int i = 0; i < n; i++){
            graph.Add(new List<int>());
        }
        for(int i = 0; i < manager.Length; i++){
            int m = manager[i];
            if(m > -1){
                graph[m].Add(i); 
            }           
        }
        int cost = 0;
        queue.Enqueue((0, headID));
        while(queue.Count > 0){
            var pair = queue.Dequeue();
            int nodeInformCost = pair.Item1, node = pair.Item2;
            cost = Math.Max(nodeInformCost, cost);

            foreach(int adj in graph[node]){
                int nodeCost = nodeInformCost + informTime[node];
                queue.Enqueue((nodeCost, adj));
            }
        }

        return cost;
    }
}