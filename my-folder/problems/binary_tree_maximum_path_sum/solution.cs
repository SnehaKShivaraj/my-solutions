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
    public int MaxPathSum(TreeNode root) {
        int pathSum = int.MinValue;
        getMaxPathSum(root, ref pathSum);
        return pathSum;
    }
        private static int getMaxPathSum(TreeNode node, ref int pathSum){
        if(node == default){
            return 0;
        }

        int lSum = Math.Max(0, getMaxPathSum(node.left, ref pathSum));
        int rSum = Math.Max(0, getMaxPathSum(node.right, ref pathSum));

        pathSum = Math.Max(pathSum, lSum + rSum + node.val);

        return node.val + Math.Max(lSum , rSum);
    }
}