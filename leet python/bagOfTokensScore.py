def bagOfTokensScore(tokens, power):
        """
        :type tokens: List[int]
        :type power: int
        :rtype: int
        """
        tokens.sort()
        i = 0
        j = len(tokens) - 1
        score = 0
        out = float('-inf')
        while i <= j and score >= 0 :
            if power >= tokens[i]:
                power -= tokens[i]
                score += 1
                i+=1
                out = max(out,score)
            else:
                power += tokens[j]
                score -= 1
                j -=1
        return out if out >= 0 else 0        

#finished

tokens = [100]
power = 50
print(bagOfTokensScore(tokens,power))