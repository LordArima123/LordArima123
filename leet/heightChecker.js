/**
 * @param {number[]} heights
 * @return {number}
 */
var heightChecker = function (heights) {
  const sorted = heights.slice().sort((a, b) => a - b);
  let res = 0;
  for (let i = 0; i < sorted.length; i++) {
    if (sorted[i] !== heights[i]) {
      res += 1;
    }
  }
  return res;
};
// Finish
heights = [5, 1, 2, 3, 4];
console.log(heightChecker(heights));
