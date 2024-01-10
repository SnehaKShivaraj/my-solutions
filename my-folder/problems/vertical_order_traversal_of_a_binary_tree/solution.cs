/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        var queue = new Queue<(TreeNode, int, int)>();
        var map = new SortedDictionary<int, Dictionary<int, SortedSet<int>>>();

        if(root == null){
            return res;
        }

        queue.Enqueue((root, 0, 0));

        while(queue.Count > 0){
            int size = queue.Count;
            for(int i = 0; i < size; i++){

                var elem = queue.Dequeue();

                TreeNode node = elem.Item1;
                int axes = elem.Item2, level = elem.Item3 + 1;


                if(node.left != null){
                    queue.Enqueue((node.left, axes - 1, level));
                }
                
                if(node.right != null){
                    queue.Enqueue((node.right, axes + 1, level));
                }

                if(!map.ContainsKey(axes)){
                    map.Add(axes, new Dictionary<int, SortedSet<int>>());
                }

                if(!map[axes].ContainsKey(level)){
                    
                    map[axes].Add(level, new SortedSet<int>(new DuplicateKeyComparer<int>()));
                }
                    
                map[axes][level].Add(node.val);
            }
        }
        foreach(var elem in map){
            var list = new List<int>();
            foreach(var levelNodes in elem.Value){
                list.AddRange(levelNodes.Value.ToList());      
            }
            res.Add(list);
        }
        return res;     
    }
}
public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
{
    public int Compare(TKey x, TKey y)
    {
        int result = x.CompareTo(y);

        if (result == 0)
            return 1; // Handle equality as being greater
        else          // IndexOfKey(key) since the comparer never returns 0 to signal key equality
            return result;
    }
}