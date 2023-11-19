public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        GetAllPermutations(nums, new List<int>(), result, new bool[nums.Length]);
        return result;  
    }

    private static void GetAllPermutations(int[] nums, IList<int> list, IList<IList<int>> result, bool[] frequency){
        if(nums.Length == list.Count){
            result.Add(list.ToList());
            return;
        }

        for(int i = 0; i< nums.Length; i++){
            if(frequency[i] is false){
                list.Add(nums[i]);
                frequency[i] = true;
                GetAllPermutations(nums, list, result, frequency);
                list.Remove(nums[i]);
                frequency[i] = false;
            }
        }

    }
}