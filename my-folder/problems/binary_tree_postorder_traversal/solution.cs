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
    public IList<int> PostorderTraversal(TreeNode root) {
        IList<int> list = new List<int>();
        GetPostorderTraversal(root, list); 
        return list;
    }
    private static void GetPostorderTraversal(TreeNode root, IList<int> list){

        if(root == null){
            return;
        }
        GetPostorderTraversal(root.left, list);
        GetPostorderTraversal(root.right, list);

        list.Add(root.val);

    }
}