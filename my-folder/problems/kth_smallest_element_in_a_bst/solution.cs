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
    public int KthSmallest(TreeNode root, int k) {
        int res = 0, counter = 0;
        FindKthSmallest(root, k, ref counter, ref res);
        return res;
    }
    private void FindKthSmallest(TreeNode root, int k, ref int counter,ref int res){
        if(root == null){
            return;
        }
        FindKthSmallest(root.left, k, ref counter, ref res);
        counter += 1;
        if(counter == k){
            res = root.val;
            return;
        }

        FindKthSmallest(root.right, k, ref counter, ref res);
    }
}