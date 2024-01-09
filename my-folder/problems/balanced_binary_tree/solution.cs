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
    public bool IsBalanced(TreeNode root) {
        return checkIfTreeIsBalanced(root) > -1 ? true : false;
    }
    private static int checkIfTreeIsBalanced(TreeNode node){
        if(node == default){
            return 0;
        }
        int left = checkIfTreeIsBalanced(node.left);

        int right = checkIfTreeIsBalanced(node.right);
        
        if(left == -1 || right == -1 || Math.Abs(left - right) > 1){
            return -1;
        }

        return Math.Max(left, right) + 1;
    }
}