public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var result = new List<IList<int>>();
        GetAllSubsets(nums, nums.Length - 1, new List<int>(), result);
        return result;
    }
    private static void GetAllSubsets(int[] nums, int n, IList<int> list, IList<IList<int>> result){
        if( n < 0){
            result.Add(list.ToList());
            return;
        }

        list.Add(nums[n]);
        GetAllSubsets(nums, n - 1, list, result);
        list.RemoveAt(list.Count - 1);
        GetAllSubsets(nums, n - 1, list, result);

    }
}