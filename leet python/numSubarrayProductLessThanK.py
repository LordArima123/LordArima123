def numSubarrayProductLessThanK(nums, k):
        """
        :type nums: List[int]
        :type k: int
        :rtype: int
        """
        left = 0 
        right = 0
        count = 0
        product = 1
        while left < len(nums):
            if product < k :
                product *= nums[right]
                count += right - left + 1
                right += 1
            else:
                product //= nums[left]
                left += 1
        return count
    
# use while  
nums = [10,5,2,6]
k = 100
print(numSubarrayProductLessThanK(nums,k))