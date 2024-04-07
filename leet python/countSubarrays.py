def countSubarrays(nums, k):
        """
        :type nums: List[int]
        :type k: int
        :rtype: int
        """
        res = 0
        maxi = max(nums)
        max_count = 0
        for right in nums:
            if right == maxi:
                max_count +=1
            if max_count >= k:
                res +=1
        for left in nums:
            if left == maxi:
                max_count -= 1
            if max_count >= k:
                res += 1
            else:
                break
        return res
    

nums = [1,3,2,3,3]
k = 2
print(countSubarrays(nums,k))