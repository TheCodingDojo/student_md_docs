# Hash Tables / Hash Map (Algorithm focused)

- A hash table in JavaScript is simply an object, in Python it is a dictionary, in Java, there is a datatype `class Hashtable`
- It is called a hash table / hash map because the keys, which are strings, are "hashed" into an integer, and the integer is used in an **underlying array as an index to access the value which is why it is `O(1)` constant time to access / look up a value, just like indexing an array is**. Essentially making it so you can name indexes with a string for readability. The same string will always hash into the same integer each time

---

## Common Uses

### Frequency Table

- to count the frequency of each item in an array

- ```js
  const arr = ["a", "z", "a", "x", "x"];
  const freq = {};

  for (const char of arr) {
    if (freq.hasOwnProperty(char)) {
      freq[char]++;
    } else {
      // first occurrence found
      freq[char] = 1;
    }
  }
  ```

- ```txt
    freq now looks like this:
    {
      a: 2,
      x: 2,
      z: 1
    }
  ```

### Seen Table

- same as frequency table except if you only care about if the item exists in the array or not, you don't need to count the frequency, just keep track of if it was seen
- this is commonly used for de-duping, if the item has been seen before, it's a duplicate.

- ```txt
  {
    a: true,
    x: true,
    z: true
  }
  ```

## Limitations

- keys are always strings, this means the integer `1` and the string `"1"` will be treated the same, meaning in a frequency table, they are counted together

  - if you have an array mixed with strings and integers, you cannot use a hash table to count the frequency of each item unless you want to count integers and strings that can be parsed into the same int as the same value

- ```js
  const obj = {
    1: "val",
  };

  obj.hasOwnProperty(1); // true
  obj.hasOwnProperty("1"); // true
  obj[1]; // "val"
  obj["1"]; // "val"
  ```

## Order NOT Guaranteed

- the order that the keys were added in is not guaranteed to be the same order that the keys are looped in and may vary from browser to browser
- the ordering of object keys in JS does follow some patterns that have been formalized, but there are quite a few rules and it's still usually better to use the below instead if order matters
- if order is important you need to use an array or the built in `Map` obect which is a type of hash table that preservers the order that the keys were inserted in, the `Map` object can also handle **objects AS keys** instead of only strings

  - you could also loop over an array that is in the order you want it to be in, and then use the items in that array to access the values in the hash table which will then access them in the same order as the array, since the array is being looped over

- ```js
  const obj = {};
  obj[-5] = -5;
  obj[5] = 5;

  // -5 will come second despite being added first
  ```
