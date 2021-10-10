

public class Solution {

 
    public int RemoveDuplicates(int[] nums) {
        var uniqueList=new List<int>();
        //int[] numsCopy=nums;
       // int uniqueArrayIndex=0;
        for(int i=0;i<nums.Length;i++)
        {            

           if(!uniqueList.Contains(nums[i]))
           {
                uniqueList.Add(nums[i]);
           }

        }
       Array.Copy(uniqueList.ToArray(),nums,uniqueList.Count);
        Array.Resize(ref nums,uniqueList.Count);
        return uniqueList.Count;
    }

}