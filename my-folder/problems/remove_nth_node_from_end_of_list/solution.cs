/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        int counter = 0;
        ListNode tur = null;
        ListNode prev = null;
        ListNode hare = head;
        
        while( hare != null)
        {
            counter++;
            if(counter == n)
            {
                tur= head;
            }
            else if (counter > n)
            {
                prev = tur;
                tur = tur.next;
            }
            hare = hare.next;
        }
        
        if(tur == head)
        {
            head = tur.next;
        }
        else
        {
            prev.next = tur.next;
            tur= null;
        }
        
        return head;
    }
}