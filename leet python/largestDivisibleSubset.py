def largestDivisibleSubset(nums):
        """
        :type nums: List[int]
        :rtype: List[int]
        """
        nums.sort()
        n = len(nums)
        dp = [1] * n
        max_size, max_index = 1, 0

        for i in range(1, n):
            for j in range(i):
                if nums[i] % nums[j] == 0:
                    dp[i] = max(dp[i], dp[j] + 1)
                    
                    if dp[i] > max_size:
                        max_size = dp[i]
                        max_index = i
        
        out = []
        num = nums[max_index]
        for i in range(max_index,-1,-1):
            if num%nums[i]==0 and dp[i] == max_size:
                out.append(nums[i])
                num = nums[i]
                max_size -=1
                print(out)

        return out
        
        
        
        
        
nums = [2,3,4,5,6]
print(largestDivisibleSubset(nums))