def removeElement(nums, val):
        """
        :type nums: List[int]
        :type val: int
        :rtype: int
        """
        i = 0
        counter = 0
        for n in nums:
            if n != val:
                counter +=1
                nums[i] = n
                i+=1
        while i < len(nums):
            nums[i] = None
            i+=1
        return counter,nums
    
#return count numbers in the Array after remove the value       
        
nums = [0,1,2,2,3,0,4,2]
val = 2
print(removeElement(nums,val))