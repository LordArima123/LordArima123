var tribonacci = function (n) {
  var memo = {};
  for (var i = 0; i <= n; i++) {
    if (i == 0) res = 0;
    else if (i < 3) res = 1;
    else {
      res = memo[i - 3] + memo[i - 2] + memo[i - 1];
    }
    memo[i] = res;
  }
  return memo[n];
};

console.log(tribonacci(25));
