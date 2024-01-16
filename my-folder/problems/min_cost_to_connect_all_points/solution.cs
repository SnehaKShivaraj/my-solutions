public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        var visited = new bool[points.Length];
        var dist = new int[points.Length];

        for(int i = 1; i < dist.Length; i++){
            dist[i] = int.MaxValue;
        }
        var queue = new SortedSet<(int, int)>();
        //cost, node
        queue.Add((0, 0));
        int totCost = 0;
        while(queue.Count > 0){
            var pointAndCost = queue.First(); 
            queue.Remove(pointAndCost);
            int cost = pointAndCost.Item1, u = pointAndCost.Item2;

            int x1 = points[u][0], y1 = points[u][1];

            if(visited[u] == true){
                continue;
            }
            visited[u] = true;
            totCost += cost;
            for(int i = 0; i < points.Length; i++){
                int x2 = points[i][0], y2 = points[i][1];

                int newCost = Math.Abs(x2 - x1) + Math.Abs(y2 - y1);
                if( newCost < dist[i]){
                    dist[i] = newCost;
                    queue.Add((newCost, i));
                }
            }
        }

        return totCost;
    }
}