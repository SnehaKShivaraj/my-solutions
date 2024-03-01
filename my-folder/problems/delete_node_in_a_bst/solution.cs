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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if(root == default){
            return default;
        }
        var cur = root;
        TreeNode prev = null;
        while(cur != null){

            if(cur.val == key){
                var subtree = RebuildTree(cur);
                if(prev == null){
                    return subtree;
                }
                if(subtree == null){
                    if(prev.left != null && prev.left.val == key){
                        prev.left = null;
                    }
                    if(prev.right != null && prev.right.val == key){
                        prev.right = null;
                    }
                    break;
                }
                if(prev.val < subtree.val){
                    prev.right = subtree;
                    break;
                }
                if(prev.val > subtree.val){
                    prev.left = subtree;
                    break;
                }
            }
            prev = cur;
            if(key > cur.val){
                cur = cur.right;
            }
            else{
                cur= cur.left;
            }

        }
        return root;
    }
    private static TreeNode RebuildTree(TreeNode node){
            var leftChild = node.left;
            var rightChild = node.right;  
            if(rightChild == null && leftChild == null){
                return null;
            }
            
            if(rightChild == null){
                return leftChild;
            }

            if(leftChild == null){
                return rightChild;
            }

            node = rightChild;
            while(rightChild.left != null){
                rightChild = rightChild.left;
            }
            rightChild.left = leftChild;
            return node;
    } 
}