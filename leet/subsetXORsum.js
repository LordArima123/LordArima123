var subsetXORSum = function (nums) {
  let memo = [0];
  for (let i of nums) {
    const loop = memo.length;
    for (let j = 0; j < loop; j++) {
      memo.push(memo[j] ^ i);
    }
  }
  const sum = memo.reduce((a, b) => a + b, 0);
  return sum;
};
const nums = [3, 4, 5, 6, 7, 8];
console.log(subsetXORSum(nums));
