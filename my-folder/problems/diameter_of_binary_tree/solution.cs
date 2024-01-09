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
    public int DiameterOfBinaryTree(TreeNode root) {
        int diameter = 0;
        getDiameterOfTree(root, ref diameter);
        return diameter;   
    }
    private static int getDiameterOfTree(TreeNode node, ref int diameter){
        if(node == default){
            return 0;
        }

        int lh = getDiameterOfTree(node.left, ref diameter);
        int rh = getDiameterOfTree(node.right, ref diameter);

        diameter = Math.Max(diameter, lh + rh);

        return 1 + Math.Max(lh, rh);
    }
}