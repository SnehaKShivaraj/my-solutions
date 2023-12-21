public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {

        var list = new List<int>();

        list = KanhsTopoSort(numCourses, prerequisites);

        if(list.Count < numCourses){
            return new int[0];
        }
        list.Reverse();
        return list.ToArray();
    }

    private static List<int> KanhsTopoSort(int numCourses, int[][] prerequisites){
        var inDegree = new int[numCourses];
        var queue = new Queue<int>();
        var adj = new List<List<int>>();
        var list = new List<int>();
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
            list.Add(node);

            foreach(int edge in adj[node]){
                inDegree[edge]--;

                if(inDegree[edge] == 0){
                    queue.Enqueue(edge);
                }
            }
        }
        return list;
    }
}