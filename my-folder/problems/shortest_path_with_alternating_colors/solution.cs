public class Solution {
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges) {
        var bGraph = new List<List<int>>();
        var rGraph = new List<List<int>>();
        var queue = new Queue<(int, int)>();
        var bResult = new int[n];
        var rResult = new int[n];

        var result = new int[n];

        for(int i = 0 ; i < n; i++){
            bGraph.Add(new List<int>());
            rGraph.Add(new List<int>());
            if(i > 0){
                bResult[i] = int.MaxValue;
                rResult[i] = int.MaxValue;
            }
        }
        for(int i = 0; i < blueEdges.Length; i++){
            int a = blueEdges[i][0], b = blueEdges[i][1];
            bGraph[a].Add(b);
        }
        for(int i = 0; i < redEdges.Length; i++){
            int u = redEdges[i][0], v = redEdges[i][1];
            rGraph[u].Add(v);

        }
        //0 - red 1 - blue
        queue.Enqueue((0, 0));
        queue.Enqueue((0, 1));
        while(queue.Count > 0){
            var pair = queue.Dequeue();
            int node = pair.Item1, color = pair.Item2;
            //if color is 0 already then pick red
            var adj = color == 0? rGraph : bGraph;
            foreach(int adjNode in adj[node]){
                var res = color == 0 ? bResult : rResult;
                int cost = color == 0 ? rResult[node] : bResult[node];
                if(res[adjNode] == int.MaxValue){
                    res[adjNode] = 1 + cost;
                    queue.Enqueue((adjNode, 1 - color));
                }
            }

        }

        for(int i = 0; i < n; i++){
            result[i] = Math.Min(bResult[i], rResult[i]);

            if(result[i] == int.MaxValue){
                result[i] = -1;
            }
        }
        return result;

    }
}