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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if(root == null){
            return new TreeNode(val);
        }
        var cur = root;
        while(true){
            if(cur.val > val){
                if(cur.left != null){
                    cur = cur.left;
                }
                else{
                    cur.left = new TreeNode(val);
                    break;
                }
            }
            else{
                if(cur.right != null){
                    cur = cur.right; 
                }
                else{
                    cur.right = new TreeNode(val);
                    break;
                }
            }
        }
        return root;
    }
}