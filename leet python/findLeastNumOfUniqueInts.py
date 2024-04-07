def findLeastNumOfUniqueInts(arr, k):
        """
        :type arr: List[int]
        :type k: int
        :rtype: int
        """
        memo = {}
        for i in arr:
            if i not in memo:
                memo[i] = 1
            else:
                memo[i]+=1
        sorted_memo = sorted(memo.items(), key = lambda x:x[1])
        for key,value in sorted_memo:
            if value <= k:
                k -= value
                memo.pop(key)
            else:
                return len(memo)
        return len(memo)
    
arr = [5,5,4]
k=1
print(findLeastNumOfUniqueInts(arr,k))
