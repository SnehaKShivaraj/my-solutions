public class Solution {
    public int MaxUncrossedLines(int[] nums1, int[] nums2) {
        return LCS(nums1, nums2, nums1.Length - 1, nums2.Length - 1, new Dictionary<(int, int), int>());
    }
    private static int LCS(int[] nums1, int[] nums2, int i, int j, IDictionary<(int,int), int> memo){
        if(i < 0 || j < 0){
            return 0;
        }
        var key = (i, j);
        if(memo.ContainsKey(key)){
            return memo[key];
        }
        if(nums1[i] == nums2[j]){
            return memo[key] = 1 + LCS(nums1, nums2, i - 1, j - 1, memo);
        }

        return memo[key] = Math.Max(LCS(nums1, nums2, i, j - 1, memo), LCS(nums1, nums2, i - 1, j, memo));
    }
}