def firstUniqChar(s):
        """
        :type s: str
        :rtype: int
        """
        for i in s:
            if s.count(i)==1:
                return s.index(i)

s = 'leetcode'
print(firstUniqChar(s))