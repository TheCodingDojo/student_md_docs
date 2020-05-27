# Big O Time Complexity Cheat Sheet

- [bigocheatsheet.com](https://www.bigocheatsheet.com/)

## Time Notation Names

### Constant: `O(1)`

- most operations that do not require a loop are considered constant, certain built in methods that seem like they could be constant but aren't are usually those which require a loop under the hood
  - e.g., `Array.splice` which after removing an element from the array must shift the remaining elements to the left to fill in the space left by the removed element. However, `Array.push` and `Array.pop` are `O(1)` operations
- `O(5)`, `O(3)` are still constant, but are simplified to `O(1)`

### Linear: `O(n)`

- as the size of the input grows (represented by `n`), the time it takes grows linearly, i.e., at the same rate
  - `n` is often the length of an array / list, or the number of keys in an object
- `O(2n)`, the two is dropped because it is a constant that does not change based on the size of the input
  - `O(2n)` would be two loops over `n`, one loop after the other, on the same level (not nested)

### Quadratic: `O(n^2)`

- try to avoid if optimizing time over space, usually reducing this to `O(n)` time requires taking up more space (memory), like using a hash table
- `O(n * n)` -> `O(n^2)`
- basic example is `i` loop over array with a nested `j` loop over same array, even if `j = i + 1` it still grows

### Polynomial: `O(n * m)`

- could be worse than `n^2`, would be better, could be linear
- 2d array where `n` is parent array length and `m` is max child array length
- this is used when `n` and `m` are not related, e.g., the child arrays lengths have no known relationship to the parent array's length and are not a fixed length
  - if the child arrays were all known to be length 2, then it would be `O(n * 2)` -> `O(2n)` -> `O(n)`
  - if the child arrays were all length `n`, then it would be `O(n * n)` -> `O(n^2)`
  - if the child arrays were all length `n * n` (`n^2`) then it would be `O(n * (n * n))` -> `O(n * n^2)` -> `O(n^3)`

## Calculating Big O Notation

### Simple Rules

- no loops and no built in methods that loop: `O(1)` constant
- when there is a nested loop, it is often `O(n^2)` quadratic, but there are exceptions
- divide and conquer (such as continually halving an array) is often `O(n log(n))`

### Line By Line Calculation

- write the Big O Notation for each line, multiply anything in a loop, then add it all up and simplify

- ```js
  function firstUnique(arr) {
    // O(1)
    const freq = {};

    // O(n)
    for (const num of arr) {
      // O(1)
      if (freq.hasOwnProperty(num)) {
        // O(1)
        freq[num]++;
      } else {
        // O(1)
        freq[num] = 1;
      }
    }

    // O(n)
    for (const num of arr) {
      // O(1)
      if (freq[num] === 1) {
        // O(1)
        return num;
      }
    }
    // O(1)
    return null;
  }
  ```

  - the constants that are in a loop get multiplied by `n`, but they will be dropped so we can ignore them
  - without constants: `O(n)` + `O(n)` = `O(2n)` -> `O(n)` linear

- ```js
  function firstUniq(arr) {
    // O(n)
    for (let i = 0; i < arr.length; ++i) {
      // O(1)
      let isUnique = true;

      // O(n)
      for (let j = 0; j < arr.length; ++j) {
        // O(1)
        if (i !== j && arr[i] === arr[j]) {
          // O(1)
          isUnique = false;
          // O(1)
          break;
        }
      }
      // O(1)
      if (isUnique) {
        // O(1)
        return arr[i];
      }
    }
    // O(1)
    return null;
  }
  ```

  - after ingoring the constants: `O(n)` \* `O(n)` = `O(n^2)` quadratic
