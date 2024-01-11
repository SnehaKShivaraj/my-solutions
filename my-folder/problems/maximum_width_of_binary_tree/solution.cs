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
    public int WidthOfBinaryTree(TreeNode root) {
        int res = 0;
        var queue = new Queue<(TreeNode, int)>();
        if(root == null){
            return res;
        }
        queue.Enqueue((root, 0));

        while(queue.Count > 0){
            int size = queue.Count;
            int firstNodeIndex = 0, lastNodeIndex = 0;
            for(int i = 0; i < size; i++){
                var elem = queue.Dequeue();
                int curIndex = elem.Item2;
                var node = elem.Item1;

                if(node.left != null){
                    queue.Enqueue((node.left, curIndex * 2 + 1));
                }
                if(node.right != null){
                    queue.Enqueue((node.right, curIndex * 2 + 2));
                }
                if(i == 0){
                    firstNodeIndex = curIndex;
                }
                if(i == size - 1){
                    lastNodeIndex = curIndex;
                }
            }
            res = Math.Max(res, lastNodeIndex - firstNodeIndex + 1);

        }
        return res;
    }
}