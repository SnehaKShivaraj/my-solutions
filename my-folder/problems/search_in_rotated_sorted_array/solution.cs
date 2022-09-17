public class Solution {
    public int Search(int[] nums, int target) {
        int low = 0;
        int high = nums.Length;
        
        int partitionIndex = Array.IndexOf(nums, nums.Min());
        int index = BinarySearch(nums, target, low, partitionIndex-1);
        if(index != -1)
            return index;
        return BinarySearch(nums, target, partitionIndex, high-1);
    }

    private int BinarySearch(int[] nums, int target, int start, int end)
    {
       
        while(start <= end)
        {
            int mid = (start + end) / 2;
            if(nums[mid] == target)
                return mid;
            if(target > nums[mid])
                start = mid + 1;
            else
                end = mid - 1;
            
        }
        return -1;
    }

}