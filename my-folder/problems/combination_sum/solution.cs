public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {

        IList<IList<int>> combinationSumList = new List<IList<int>>(); 

        ConstructCombinationSum(candidates, 0, target, combinationSumList, new List<int>());
        return  combinationSumList;
    }
    private void ConstructCombinationSum(int[] candidates, int i, int sum, IList<IList<int>> combinationSumList, IList<int> list){
        if(sum == 0){
            combinationSumList.Add(list.ToList());
            return;
        }

        if(i == candidates.Length){
            return;
        }
        if(sum >= candidates[i]){
            list.Add(candidates[i]);
            ConstructCombinationSum(candidates, i, sum - candidates[i], combinationSumList, list);
            list.Remove(candidates[i]);
        }
        ConstructCombinationSum(candidates, i + 1, sum, combinationSumList, list);
    }
}