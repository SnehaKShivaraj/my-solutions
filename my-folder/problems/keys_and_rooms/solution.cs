public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var queue = new Queue<int>();
        var visited = new bool[rooms.Count];

        queue.Enqueue(0);
        while(queue.Count > 0){
            int node = queue.Dequeue();

            visited[node] = true;

            foreach(int adjNode in rooms[node]){
                if(visited[adjNode] is false){
                    queue.Enqueue(adjNode);
                }
            }
        }
        for(int i = 0; i < rooms.Count; i++){
            if(visited[i] == false){
                return false;
            }
        }
        return true;
    }
}