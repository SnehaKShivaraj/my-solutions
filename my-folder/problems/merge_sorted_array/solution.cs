public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        m--;
        n--;
        for(int i=nums1.Length-1;i>=0;i--)
        {
            if(n<0)
                return;
            if(m>=0 && nums1[m]>nums2[n])
            {
                nums1[i]=nums1[m];
                m--;
            }
            else{
                nums1[i]=nums2[n];
                n--;
            }
        }
    }

}