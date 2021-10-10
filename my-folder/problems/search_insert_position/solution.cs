public class Solution {
    public int SearchInsert(int[] nums, int target) {

        for(int i=0;i<nums.Length;i++)
        {
          if(target<= nums[i])
              return i;
          else if( i < nums.Length-1 && target > nums[i] && target < nums[i+1])
              return i+1;
        }
        return nums.Length;
    }
}