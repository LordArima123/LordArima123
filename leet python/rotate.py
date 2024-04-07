def rotate(nums, k):
        """
        :type nums: List[int]
        :type k: int
        :rtype: None Do not return anything, modify nums in-place instead.
        """
        #i = 0
        #rmd = nums[i]
        #for j in range(len(nums)):
        #    if i+k < len(nums):
        #        i += k 
        #        nums[i],rmd = rmd,nums[i]
        #    else:
        #        i = i+k-len(nums)
        #        nums[i],rmd = rmd,nums[i]
        #return nums       
        
        #move 1 side first        
            
nums = [-1,-100,3,99]
k = 2
print(rotate(nums,k))