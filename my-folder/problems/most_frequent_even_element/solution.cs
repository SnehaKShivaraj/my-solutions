public class Solution {
    public int MostFrequentEven(int[] nums) {
        var evenList = nums.Where(num => num % 2 == 0);
        
        if(!evenList.Any())
            return -1;
        var list = evenList.GroupBy(num => num).Select(grp => new
            {
                number = grp.Key,
                count = grp.Count()
            });
        
        int maxCount = list.Max(i=>i.count);
        return list.Where( grp => grp.count == maxCount).Min(i=>i.number);
    }
}