def removeDuplicates(nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        k = 0
        j = 0
        num = float('-inf')
        freq = 0
        for i in nums:
            if i > num:
                nums[j] = i
                num = i
                freq =1
                j += 1
                k+=1
            
            else:
                if freq <2:
                    nums[j] = i
                    j +=1
                    freq +=1
                    k+=1
                else:
                    continue
        return k,nums
    
    
nums = [1,1,1,2,2,3]
print(removeDuplicates(nums))