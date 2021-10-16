public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var indexes = new int[2];
        for(int i=0;i<nums.Length;i++)
        {
            for(int j=0;j<nums.Length-1;j++)
            {
                if(i==j)
                    continue;
                if(nums[i]+nums[j] == target)
                {
                    indexes[0]=i;
                    indexes[1]=j;
                    return indexes;
                } 
            }        
        }
    return indexes;
    }
}