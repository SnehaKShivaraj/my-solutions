public class Solution {
    public int[] SortedSquares(int[] nums) {
        var array = new int[nums.Length];
        for(int i=0;i<=nums.Length-1;i++)
        {
            array[i]=nums[i]*nums[i];

        }
        for(int i=0;i<nums.Length-1;i++)
        {
            for(int j=0;j<nums.Length-i-1;j++)
            {
                if(array[j]>array[j+1])
                {
                   int temp=array[j];
                    array[j]=array[j+1];
                    array[j+1]=temp;

                }
            }
        }
        return array;
    }
}