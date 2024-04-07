def findCheapestPrice(n, flights, src, dst, k):
        """
        :type n: int
        :type flights: List[List[int]]
        :type src: int
        :type dst: int
        :type k: int
        :rtype: int
        """
        dep = [0]
        arr = [0]
        cost =[0]
        stop = 0[]



    
n = 4 
flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]] 
src = 0 
dst = 3
k = 1
print(findCheapestPrice(n,flights,src,dst,k))