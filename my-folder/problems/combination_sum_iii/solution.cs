public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var result = new List<IList<int>>();

        int[] nums = new int[9];
        for(int i = 0; i < 9; i++){
            nums[i] = i + 1;
        }
        GetAllCombinationsSumSeq(nums, nums.Length, k, n, new List<int>(), result);

        return result;
    }
    private static void GetAllCombinationsSumSeq(int[] nums, int index, int k, int sum, IList<int> list, IList<IList<int>> result){
        if( sum == 0 && k == 0){
            result.Add(list.ToList());
            return; 
        }

        if(sum <= 0 || k <= 0 || index <= 0){
            return;
        }
        list.Add(nums[index - 1]);
        GetAllCombinationsSumSeq(nums, index - 1, k - 1, sum - nums[index - 1], list, result);
        
        list.RemoveAt(list.Count - 1);
        GetAllCombinationsSumSeq(nums, index - 1, k, sum, list, result);

    }
}