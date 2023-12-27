public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int[,] cost = new int[n, n];
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                if(i == j){
                    cost[i, i] = 0;
                    continue;
                }
                cost[i, j] = int.MaxValue;
            }
        }

        for(int i = 0; i < edges.Length; i++){
            int u = edges[i][0], v = edges[i][1], w = edges[i][2];

            cost[u, v] = w;
            cost[v, u] = w;
        }

        for(int k = 0; k < n; k++){
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    if(cost[i, k] != int.MaxValue && cost[k, j] != int.MaxValue){
                        cost[i, j] = Math.Min(cost[i, j], cost[i, k] + cost[k, j]);
                    }
                }
            }
        }
        //(city, total number of cities that present city can reach)
        var pair = (-1, n);

        for(int i = 0; i < n; i++){
            int counter = 0;
            for(int j = 0; j < n; j++){
                Console.Write(cost[i, j]+" ");

                if(cost[i, j] <= distanceThreshold){
                    counter += 1;
                }
            }
            
            if(counter <= pair.Item2 ){
                pair.Item1 = i;
                pair.Item2 = counter; 
            }
        }

        return pair.Item1;
    }
}