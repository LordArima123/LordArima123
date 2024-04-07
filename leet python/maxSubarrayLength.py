def maxSubarrayLength(nums, k):
        """
        :type nums: List[int]
        :type k: int
        :rtype: int
        """
        memo = {}
        i,j,out = 0,0,0
        while j < len(nums):
            memo[nums[j]] += 1
            while memo[nums[j]] > k:
                memo[nums[i]] -= 1  
                i+=1
            j+=1
            
            out = max(out,j-i)
        return out
            
            
            
            
            
            
nums = [1,2,3,1,2,3,1,2,3]
k = 3
print(maxSubarrayLength(nums,k))