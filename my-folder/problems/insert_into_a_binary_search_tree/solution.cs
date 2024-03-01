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
        var newNode = new TreeNode(val);
        if(root == null){
            return newNode;
        }

        var cur = root;
        while(cur != null){
            if(val > cur.val){
                if(cur.right == null){
                    cur.right = newNode;
                    break;
                }
                cur = cur.right;
            }
            else{
                if(cur.left == null){
                    cur.left = newNode;
                    break;
                }
                cur = cur.left;
            }
        }
        return root;    
    }
}