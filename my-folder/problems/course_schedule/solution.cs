public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        return KanhsTopoSort(numCourses, prerequisites);
    }
    private static bool KanhsTopoSort(int numCourses, int[][] prerequisites){
        var inDegree = new int[numCourses];
        var queue = new Queue<int>();
        var adj = new List<List<int>>();
        int counter = 0;

        for(int i = 0; i < numCourses; i++){
            adj.Add(new List<int>());
        }

        for(int i = 0; i < prerequisites.Length; i++){

            adj[prerequisites[i][0]].Add(prerequisites[i][1]);
            inDegree[prerequisites[i][1]]++;
        }

        for(int i = 0; i < numCourses; i++){
            if(inDegree[i] == 0){
                queue.Enqueue(i);
            }
        }

        while(queue.Count > 0){
            int node = queue.Dequeue();
            counter++;

            foreach(int edge in adj[node]){
                inDegree[edge]--;

                if(inDegree[edge] == 0){
                    queue.Enqueue(edge);
                }
            }
        }
        return counter == numCourses;
    }
    private static bool DfsTopoSort(int numCourses, int[][] prerequisites){
        var visited = new bool[numCourses];
        var stack = new Stack<int>();
        var adj = new List<List<int>>();

        for(int i = 0; i < numCourses; i++){
            adj.Add(new List<int>());
        }

        for(int i = 0; i < prerequisites.Length; i++){

            adj[prerequisites[i][0]].Add(prerequisites[i][1]);
        }

        for(int i = 0; i < numCourses; i++){

            if(visited[i] is false){
                Dfs(i, adj, visited, stack);
            }
        }

        return stack.Count == numCourses;
    }
    
    private static void Dfs(int node, List<List<int>> adj, bool[] visited, Stack<int> stack){

        visited[node] = true;

        foreach(int edge in adj[node]){
            
            if(visited[edge] is false){
                Dfs(edge, adj, visited, stack);
            }
        }

        stack.Push(node);
    }
}