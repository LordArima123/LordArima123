def largestPerimeter(nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        nums.sort()
        out = sum(nums)
        
        for i in range(len(nums)-1,0,-1):
            print(i)
            if i < 3 and out - nums[i] <= nums[i]:
                return -1
            elif out - nums[i] <= nums[i]:
                out -= nums[i]
            else:
                return out
  #//finished  

nums =[5,5,50]
print(largestPerimeter(nums))
