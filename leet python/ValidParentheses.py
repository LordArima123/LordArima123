def isValid(s):
        """
        :type s: str
        :rtype: bool
        """
        out = False
        open = ['(','{','[']
        close = [')','}',']']
        reminder = []
        if len(s)%2 == 1 or s[0] in close:
            return False
        for i in range(len(s)):
            if s[i] in open:
                 print('rmd',reminder)
                 reminder.append(s[i])
            elif s[i] in close and len(reminder) == 0:
                 return False
            elif s[i] in close and s[i] == close[open.index(reminder[-1])]:
                 out = True
                 reminder.pop()
            else:
                 return False
            
          

        return out
    
s = "(([]){})"
print(isValid(s))