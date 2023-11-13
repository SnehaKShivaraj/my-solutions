public class Solution {
    public bool CanPartition(int[] nums) {
    int sum = 0;
    foreach(int num in nums){
        sum += num;
    }  
    
    if(sum%2 == 1) return false;

    int l = nums.Length;
    sum /= 2;
    var dp = new bool[l+1, sum+1];
    for(int i = 0; i<=l; i++){
        for(int j = 0; j<=sum; j++){
                
            if(j == 0 ){
                dp[i, j] = true;    
            }                
            else{
                    dp[i, j] = false;
            }
        }
    }
        
    for(int i = 1; i <= l; i++){
        for(int j = 1; j <= sum; j++){
            if(nums[i-1] > j){
                 dp[i, j] = dp[i-1, j];
            }
            else{
                 dp[i, j] = dp[i-1, j - nums[i-1]] || dp[i-1, j];
            }
        }
    }
    return dp[nums.Length, sum];
    
    }
}