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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();
        var queue = new Queue<TreeNode>();

        if(root == default){
            return result;
        }
        queue.Enqueue(root);
        while(queue.Count > 0){
            int levelSize = queue.Count;
            var levelList = new List<int>();
 
            for(int i = 0 ; i < levelSize; i++){
                var node = queue.Dequeue();

                if(node.left != default){
                    queue.Enqueue(node.left);
                }
                if(node.right != default){
                    queue.Enqueue(node.right);
                }
                levelList.Add(node.val);
            }
            result.Add(levelList);
        }

        return result;
    }
}