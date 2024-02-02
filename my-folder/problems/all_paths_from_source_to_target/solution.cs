public class Solution {
    private static int target = 0;
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        IList<IList<int>> result = new List<IList<int>>();
        target = graph.Length - 1;
        var adj = new List<List<int>>();

        for(int i = 0; i <= target; i++){
            adj.Add(new List<int>());
        }

        for(int i = 0; i < graph.Length; i++){
            for(int j = 0; j < graph[i].Length; j++){
                adj[i].Add(graph[i][j]);
            }
        }
        dfs(adj, 0, new List<int>(){0}, result);
        return result;
    }
    private static void dfs(List<List<int>> adj, int node, IList<int> path, IList<IList<int>> result){

        if(node == target){
            result.Add(path.ToList());
            return;
        }
        foreach(int adjNode in adj[node]){
            path.Add(adjNode);
            dfs(adj, adjNode, path, result);
            path.Remove(adjNode);
        }
    }
}