def firstMissingPositive(nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        memo = [0] * (len(nums)+1)
        for i in nums:
            if i <= 0:
                continue
            elif i < len(nums)+1:
                memo[i] += 1
        return memo.index(0)
    
    


nums= [1,2,3,5,4]
print(firstMissingPositive(nums))