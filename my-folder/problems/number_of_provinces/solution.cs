public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        var adj = new List<List<int>>();

        for(int i = 0; i < isConnected.Length; i++){
            var list = new List<int>();
            for(int j = 0; j < isConnected[0].Length; j++){
                if(i != j && isConnected[i][j] == 1){
                    list.Add(j);
                }
            }
            adj.Add(list);
        }
        bool[] visited = new bool[isConnected.Length];
        int provincesCount = 0;
        for(int i = 0; i < isConnected.Length; i++){
            if(visited[i] == false){
                provincesCount += 1;
                visited[i] = true;
                dfs(adj, visited, i);
            }
        }
        return provincesCount;

    }
    private static void dfs(List<List<int>> adj, bool[] visited, int node){
        foreach(var neighbour in adj[node]){
            if(visited[neighbour] == false){
                visited[neighbour] = true;
                dfs(adj, visited, neighbour);
            }
        }
    }
}