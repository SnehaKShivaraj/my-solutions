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
    public IList<int> RightSideView(TreeNode root) {
            //code here
            var list= new List<int>();
            ReversePreOrder(root, 0, list);
            return list;
        }
        private static void ReversePreOrder(TreeNode node, int level, IList<int> list){
            if(node == null){
                return;
            }
            
            if(list.Count == level){
                list.Add(node.val);
            }
            ReversePreOrder(node.right, level + 1, list);
            ReversePreOrder(node.left, level + 1, list);

        }
}