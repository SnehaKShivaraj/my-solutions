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
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> list = new List<int>();
        GetInOrderTraversal(root, list); 
        return list;
    }
    private static void GetInOrderTraversal(TreeNode root, IList<int> list){

        if(root == null){
            return;
        }
        GetInOrderTraversal(root.left, list);
        list.Add(root.val);

        GetInOrderTraversal(root.right, list);
    }
}