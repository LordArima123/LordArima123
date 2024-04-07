def minimumLength(s):
        """
        :type s: str
        :rtype: int
        """
        pref = 0
        suff = len(s)-1
        
        while pref < suff and s[pref] == s[suff]:
            char =s[pref]
            while pref <= suff and s[pref] == char:
                pref +=1
            while suff >= pref and s[suff] == char:
                suff -=1
        return suff-pref+1
s = "abbbbbbbbbbbbbbbbbbba"
print(minimumLength(s))