public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        IList<IList<int>> combinationList = new List<IList<int>>();
        Array.Sort(candidates);
        UniqueCombinationSum(candidates, target, 0, combinationList, new List<int>());
        return combinationList;
    }
    private void UniqueCombinationSum(int[] candidates, int target, int index, IList<IList<int>> combinationList, IList<int> list){

        if(target == 0){
            combinationList.Add(list.ToList());
            return;
        }
        for(int i = index; i< candidates.Length; i++){
            if(i > index && candidates[i] == candidates[i - 1]){
                continue;
            }
            if(candidates[i] > target){
                break;
            }
            list.Add(candidates[i]);
            UniqueCombinationSum(candidates, target - candidates[i], i + 1, combinationList, list);

            list.Remove(candidates[i]);
        }

    }
}