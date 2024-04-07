def canJump(nums):
        """
        :type nums: List[int]
        :rtype: bool
        """
        curr_pos = 0
        
        while curr_pos + nums[curr_pos] < len(nums)-1:
            max_pos = curr_pos + nums[curr_pos]
            new_pos = curr_pos
            while new_pos <= max_pos:
                new_pos +=1
                if new_pos + nums[new_pos] > max_pos:
                    curr_pos = new_pos
                    break
                elif new_pos == max_pos or nums[curr_pos] ==0:
                    return False
        return True
    
nums = [3,0,8,2,0,0,1]
print(canJump(nums))