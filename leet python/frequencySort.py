def frequencySort(s):
        """
        :type s: str
        :rtype: str
        """
        hash = {}
        out = ''
        for i in s:
            if i not in hash:
                hash[i] = 1
            else:
                hash[i] = hash[i]+1
        while len(hash) > 0:
            c = max(hash, key=hash.get)
            print(c)
            out = out + c*hash[c]
            hash.pop(c)
        return out     
 #finished

        
        
        
s = 'tree'
print(frequencySort(s))