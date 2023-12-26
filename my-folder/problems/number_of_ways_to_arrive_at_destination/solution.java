class Pair{
    long first; 
    int second;
    Pair(long first, int second)
    {
        this.first = first;
        this.second = second;
    }
}

class Solution {
    public int countPaths(int n, int[][] roads) {
    ArrayList<ArrayList<Pair>> adj = new ArrayList<>();
       int m = roads.length;
       
       for(int i=0; i<n; i++)
            adj.add(new ArrayList<>());
        for(int i=0; i<m; i++)
        {
            adj.get(roads[i][0]).add(new Pair(roads[i][2], roads[i][1]));
            adj.get(roads[i][1]).add(new Pair(roads[i][2], roads[i][0]));
        }
        
        PriorityQueue<Pair> pq = new PriorityQueue<Pair>((x, y) -> (int)(x.first - y.first));
        pq.add(new Pair(0, 0));
        
        int[] ways = new int[n];
        Arrays.fill(ways, 0);
        ways[0] = 1;
        
        long[] dist = new long[n];
        Arrays.fill(dist, Long.MAX_VALUE);
        dist[0] = 0;
        
        int mod = (int)(1e9 + 7);

        while(!pq.isEmpty())
        {
            long dt = pq.peek().first;
            int node = pq.peek().second;
            pq.remove();
            
            for(int i=0; i<adj.get(node).size(); i++)
            {
                int adjNode = adj.get(node).get(i).second;
                long edW = adj.get(node).get(i).first;
                
                if(dt + edW < dist[adjNode])
                {
                    dist[adjNode] = dt + edW;
                    pq.add(new Pair(dist[adjNode], adjNode));
                    ways[adjNode] = ways[node] % mod;
                }
                else if(dt + edW == dist[adjNode])
                    ways[adjNode] = (ways[adjNode] + ways[node]) % mod;
            }
        }
        return ways[n-1] % mod;  
    }
}