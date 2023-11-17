public class Solution {
    public bool CanPartition(int[] nums) {
        /*
        [1,5,11,5] sum = 23/2 =11 
        11 - 1 = 10 - 5 = 5 - 5 = 0
        11 = 11

        */ 
        int sum = 0;

        foreach(int i in nums){
            sum+= i;
        }

        if(sum % 2 == 1){
            return false;
        } 
        
        return SubSetSum(nums, sum/2, nums.Length, new Dictionary<(int, int), bool>()); 
    }
    static bool SubSetSum(int[] nums, int sum, int n, IDictionary<(int, int), bool> dict){

        if(sum == 0 ){
            return true;
        }
        
        if(n == 0){
            return false;
        }
        (int, int) key = (sum, n);

        if(dict.ContainsKey(key))
            return dict[key];

        if(sum >= nums[n - 1]){
            return dict[key] = SubSetSum(nums, sum - nums[n - 1], n - 1, dict) || SubSetSum(nums, sum, n - 1, dict) ;
        }
        return dict[key] = SubSetSum(nums, sum, n - 1, dict);
    }
}