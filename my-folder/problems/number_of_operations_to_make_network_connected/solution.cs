public class Solution {
    public int MakeConnected(int n, int[][] connections) {
        var disjointSet = new DisjointSet(n);
        int extraEdges = 0;
        for(int i = 0; i < connections.Length; i++){
            int u = connections[i][0], v = connections[i][1];

            if(disjointSet.findUltimateParent(u) == disjointSet.findUltimateParent(v)){
                extraEdges += 1;
                continue;
            }

            disjointSet.UnionBySize(u, v);
        }
        int totComponents = 0;
        for(int i = 0; i < n; i++){
            if(disjointSet.Parent[i] == i){
                totComponents += 1;
            }
        }

        if(extraEdges >= totComponents - 1 ){
            return totComponents - 1;
        }
        return -1;
    }
}
public class DisjointSet{
    private IList<int> size = new List<int>();
    private IList<int> parent = new List<int>();
    
    public IList<int> Parent { get{return parent;}}

    public DisjointSet(int n){
        for(int i = 0; i <= n; i++){
            size.Add(1);
            parent.Add(i);
        }
    }
    public void UnionBySize(int nodeA, int nodeB){
        int upNodeA = findUltimateParent(nodeA);
        int upNodeB = findUltimateParent(nodeB);

        if(upNodeA == upNodeB){
            return;
        } 

        if(size[upNodeA] >= size[upNodeB]){
            parent[upNodeB] = upNodeA;
            size[upNodeA] += size[upNodeB];
        }
        else{
            parent[upNodeA] = upNodeB;
            size[upNodeB] += size[upNodeA];
        }
    }
    public int findUltimateParent(int node){
        var parentNodes = new List<int>();
        int ultimateParent = node;
        /*
        Until the parent node of a node is itself keep tracing backwards to find
        ultimate parent of a node
        */
        while(parent[ultimateParent] != ultimateParent){
            parentNodes.Add(ultimateParent);
            ultimateParent = parent[ultimateParent];
        }

        foreach(int parentNode in parentNodes){
            parent[parentNode] = ultimateParent;
        }

        return ultimateParent;
    }
}