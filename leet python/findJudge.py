def findJudge(n, trust):
        """
        :type n: int
        :type trust: List[List[int]]
        :rtype: int
        """
        people = [0] * (n+1)
        judge = [0] * (n+1)
        for i,j in trust:
            people[i] +=1
            judge[j] +=1
        for k in range(1,n+1):
            if judge[k] == n-1 and people[k] == 0:
                return k
        return -1
    
trust =[[1,3],[2,3],[3,1]]
n =3
print(findJudge(n,trust))
