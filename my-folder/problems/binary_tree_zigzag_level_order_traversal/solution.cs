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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        var queue = new Queue<TreeNode>();

        if(root == null){
            return res;
        }
        int counter = 0;
        queue.Enqueue(root);

        while(queue.Count > 0){
            int size = queue.Count;
            var list = new List<int>();

            for(int i = 0; i < size; i++){
                TreeNode node = queue.Dequeue();

                list.Add(node.val);

                if(node.right != null){
                    queue.Enqueue(node.right);
                }

                if(node.left != null){
                    queue.Enqueue(node.left);
                }

            }
            counter += 1;
            if(counter %2 == 1){
                list.Reverse();
            }
            res.Add(list);
        }
        return res;     
    }
}