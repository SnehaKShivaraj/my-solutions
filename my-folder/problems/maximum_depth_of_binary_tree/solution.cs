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
    public int MaxDepth(TreeNode root) {
        return getTreeHeight(root);
    }
    private static int getTreeHeight(TreeNode node){
        if(node == default){
            return 0;
        }
        int left = getTreeHeight(node.left);
        int right = getTreeHeight(node.right);

        return Math.Max(left, right) + 1;
    }
}