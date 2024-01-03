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
    public IList<int> PreorderTraversal(TreeNode root) {
        IList<int> list = new List<int>();
        GetPreOrderTraversal(root, list); 
        return list;
    }
    private static void GetPreOrderTraversal(TreeNode root, IList<int> list){

        if(root == null){
            return;
        }
        list.Add(root.val);
        GetPreOrderTraversal(root.left, list);
        GetPreOrderTraversal(root.right, list);
    }
}