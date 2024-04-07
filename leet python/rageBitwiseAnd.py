def rangeBitwiseAnd(left, right):
        """
        :type left: int
        :type right: int
        :rtype: int
        """
        i = 0
        
        while left != right:
            left >>= 1
            right >>= 1
            i+=1
            
                
        return left <<i
            
        
    
    
left = 5
right = 5
print(rangeBitwiseAnd(left,right))