public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var dict = new Dictionary<int,int>();
        var res = new int[2];
        for(int i=0 ; i< nums.Length; i++)
        {
            int rem = target - nums[i];
            if(dict.ContainsKey(rem))
            {
                res[0]= dict[rem];
                res[1] = i;
                break;
            }
            if(!dict.ContainsKey(nums[i]))
                dict.Add(nums[i],i);
        }
        return res;
    }

  
}