public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
        var result = new int[2];
        return TwoSumRecursive(nums, target, 0, result);
        
    }
    private int GetIndex(int[] nums, int rem, int k)
    {
        int index =0;
         for(int j=k;j< nums.Length;j++)
         {
                if(nums[j] == rem)
                {
                    index =j;
                    break;
                }
                    
         }
        return index;
        
    }
    private int[] TwoSumRecursive(int[] nums, int target, int i, int[] resultArray) {
        
            if (i >= nums.Length)
                return new int[0];

            int rem = target - nums[i];
            if (nums.Contains(rem))
            {
                if (rem != nums[i] || (rem == nums[i] && nums.Count(s => s == rem) > 1))
                {
                    resultArray[0] = i;
                    resultArray[1] = GetIndex(nums, rem, i + 1);
                    return resultArray;
                }

            }
             return  TwoSumRecursive(nums, target, i+1, resultArray);
        
    }
}