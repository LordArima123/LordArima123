
#def numSquares(n):
#        """
#        :type n: int
#        :rtype: int
#        """
#        if n<=3:
#            return n
#        
#        perfsquares = []
#        i = 1
#        while i**2<=n:
#            perfsquares.append(i**2)
#            i+=1
#        if n in perfsquares:
#            return 1
#        def min_ignore_none(a,b):
#            if a is None:
#                return b
#            if b is None:
#                return a
#            return min(a,b)
#        memo = {}
#        memo[0] = 0
#        for i in range(1, n+1):
#            for square in perfsquares:
#                subproblem = i - square
#                if subproblem <0:
#                    continue
#                
#                memo[i] = min_ignore_none(memo.get(i),memo.get(subproblem)+1)
#        return memo[n]
    
#slow

def numSquares (n):
        dp = [float('inf')] * (n + 1)
        dp[0] = 0
        for i in range(1, n + 1):
            print(dp)
            min_val = float('inf')
            j = 1
            while j * j <= i:
                min_val = min(min_val, dp[i - j * j] + 1)
                j += 1
            dp[i] = min_val
        return dp[n]
#        

print(numSquares(12))
