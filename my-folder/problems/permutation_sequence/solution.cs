public class Solution {
    public string GetPermutation(int n, int k) {
       
       string output = string.Empty;
       int fact = 1;
        var nums = new List<int>();

        for(int i = 1; i < n; i++){
            fact = fact * i;
            nums.Add(i);
        }
        nums.Add(n);
        k--;
   
        while(true){

            output += nums[k / fact];
            nums.RemoveAt(k / fact);
            if(nums.Count == 0){
                break;
            }
            k = k % fact;
            fact = fact / nums.Count;
        }
       return output;
    }
        /*
            n = 4, K = 17,
            n! = 24
            total permutation block starting with 1 , 2, 3 ... upto n block size = n!/n 24/4 = 6 --
            1 + {2, 3, 4} - Contains 6 permutations starting with 1
            2 + {1, 3, 4} - ... with 2
            3 + {1, 2, 4} - ... with 3
            4 + {1, 2, 3} - ... with 3
            to get the number of 17th seq K/block size ie. 17/6 = 2
            [1,2,3,4] the 17th sequence starts with 2 + 1 {cause of zero based array index} => 3
            
       */ 
}