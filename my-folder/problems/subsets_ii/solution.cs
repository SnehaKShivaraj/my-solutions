public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        IList<IList<int>> subSetList = new List<IList<int>>{new List<int>()};
        Array.Sort(nums);
        GetAlllUniqueSubSets(nums, 0, subSetList, new List<int>());
        return subSetList;
    }

    private static void GetAlllUniqueSubSets(int[] nums, int index, IList<IList<int>> res, IList<int> list){

        if(index == nums.Length){
            return;
        }

        for(int i = index; i < nums.Length; i++){
            if(i > index && nums[i] == nums[i - 1]){
                continue;
            }
            list.Add(nums[i]);
            res.Add(list.ToList());
            GetAlllUniqueSubSets(nums, i + 1, res, list);
            list.Remove(nums[i]);

        }
    }
}