public class Solution {
    public int MaxArea(int[] height) {
        
        int maxArea = 0;
        int tempArea = 0;
        int l=0; int r = height.Length-1;

        while(l<r)
        {
            //Console.WriteLine(l+":"+r);
            int minHeight = height[l]>=height[r]?height[r]:height[l];
            tempArea = minHeight * (r - l);
            
            if(tempArea > maxArea)
                    maxArea= tempArea;
            
            if(height[l]>height[r])
               r-=1; 
            else if(height[l]<height[r])
                l+=1;
            else{
                
                l+=1;
                r-=1;
            }
        }
        

        return maxArea;
    }
}