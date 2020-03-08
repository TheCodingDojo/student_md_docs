# Functional Programming (`.forEach`, `.map`, `.filter`)

- just like OOP is a programming paradigm focused around objects, functional programming is a programming paradigm centered around functions
- in JS, functions can be passed to other functions as an argument, in the same way that you can pass an object to a function as an argument
  - the main difference is that if a function is passed as an argument, the corresponding parameter will needs to be treated like a function, meaning it can be executed when you want to run the function that was passed in (the callback function, you call the function back at a later time, when appropriate)

---

## `nodemon`

- run file with `nodemon` if you want it to auto re-run after code changes are detected
- `nodemon fileName`
- `nodemon path/to/fileName`

---

## Arrow function syntax variations

- if there's only 1 parameter, the parenthesis around the single parameter can be omitted
  - as soon as you need to add another parameter, you must add the parenthesis back
- if the body of the function is one line, no curly braces are needed and no `return` is needed, it will auto `return` the result of the 1 line of code (implicit return)
  - as soon as your function body needs to be more than 1 line, you must add the curly braces in and explicityly write `return` if the function should `return` something

---

### Advice

- to start, always use parenthesis and curly braces because this is the only way you won't accidentally run into an error by forgetting to add them back in if you need them later on
- then when used to it, start using the shorthand

---

## Why would you want to pass a function to another function

- if you have a function and you want to allow the caller of the function to give you more complex instructions that you can't anticipate, all you need to do is have your function say: just give me the instructions you want and I will follow them (pass me a function that has the code you want to be executed and I will execute it for you at the right time)

---

## `.forEach` explanation ([MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/forEach))

- `.forEach` is a method available to arrays
- `.forEach` takes a callback as an argument
- `.forEach` will loop over the array it was called on and execute your provided callback and pass the current item from the loop to your callback so your callback can do whatever you tell it to do with the item (run some conditions and update the item based on the conditions for example)

---

### Print ints from arr

---

#### Q: how would we do this without `.forEach`?\*

- ```js
  const numbers = [1, 2, 3, 4, 5];

  function printAllItems(arr) {
    for (let i = 0; i < arr.length; ++i) {
      console.log(`The item is: ${arr[i]}`);
    }
  }

  printAllItems(numbers);
  ```

- `.forEach` is basically a loop over an array already written for us, then we just tell `.forEach` what we want to do with each item in the arr

---

#### With `.forEach`

- ```js
  const printOneItem = item => {
    console.log(`The item is: ${item}`);
  };

  numbers.forEach(printOneItem);
  ```

---

#### Q: What if you needed the index?\*

- `.forEach` is already sending us the index as the 2nd argument to our callback function
- all we need to do then, is add a parameter to receive that index that is already being passed to our callback

- ```js
  const printOneItem = (item, idx) => {
    console.log(`The item is: ${item}. The index is: ${idx}`);
  };
  ```

---

#### Anonymous function passed to `.forEach`

- if this function is never going to be called elsewhere, only this one time in the `.forEach`, defining it outside with a name is unnecessary

- ```js
  // multiple syntax variations that do the same thing:

  nums.forEach(function(item, idx) {
    console.log(`The item is: ${item}. The index is: ${idx}`);
  });

  // arrow function long-form, return keyword needed if you need to return something
  nums.forEach((item, idx) => {
    console.log(`The item is: ${item}. The index is: ${idx}`);
  });

  // arrow function shorthand for one line, wrap in parens, what is in parens is implicit (auto) returned
  nums.forEach((item, idx) =>
    console.log(`The item is: ${item}. The index is: ${idx}`)
  );
  ```

  - here, our function is being created on the fly as the first argument
  - this is just like calling a function and creating an array on the fly as an argument

    - ```js
      printAllItems([10, 11, 12]);
      ```

---

### Recreate `.forEach` so we can peak under the hood

- ```js
  // Add new method to the Array.prototype so every array has access to it
  Array.prototype.forEvery = function(callback) {
    // this keyword will refer to the array that .forEvery is called on

    for (let i = 0; i < this.length; ++i) {
      // forEach also sends the whole array to your callback as arg3
      callback(this[i], i, this);
    }
  };

  // call our newly added method on the nums array
  numbers.forEvery((item, idx) => console.log(`Item: ${item} at Idx ${idx}`));
  ```

---

## `.map` explanation ([MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/map))

- `.map` is a built in method available to be called on any array
- `.map` is used a lot in React
- `.map` returns a new array based on the array it was called on, where each item in the new array is usually the original item after it is transformed in some way that you specify your callback function that you pass to `.map` as an argument
- `.map` will iterate over the array it was called on, for every iteration, `.map` will execute the callback function you passed to it and send the current item from the loop to your callback function. Whatever your callback function returns will be put into the new array. This is where the callback function has some instructions for transforming the item it's given.

---

### Create a new array with each int doubled without `.map`

- ```js
  const doubleNums = nums => {
    const doubledNums = [];

    for (let i = 0; i < nums.length; ++i) {
      doubledNums.push(nums[i] * 2);
    }

    return doubledNums;
  };

  console.log(doubleNums(numbers));
  ```

---

### Double nums WITH `.map`

- `.map` does all of this for us, all it needs to know, is what do we want the new item to be on each iteration

- ```js
  const doubledNums = numbers.map(num => num * 2);
  console.log(doubledNums);
  ```

---

### Recreate `.map`

- ```js
  Array.prototype.map2 = function(callBack) {
    const newArr = [];

    for (let i = 0; i < this.length; i++) {
      const newItem = callBack(this[i], i, this);
      newArr.push(newItem);
    }
    return newArr;
  };
  ```

---

## `.filter` explanation

- `.filter` is a method available to arrays
- it returns a new array with only the items in it that pass the filter test defined in the callback function you pass to `.filter` as an argument
- `.filter` loops over every item in the array it was called on, executes the callback you passed to `.filter`, passing the current item from the loop to your callback, and if your callback returns `true`, it will keep the item, if it return `false`, it will not add that item to the new array

---

### New Array with only even numbers without `.filter`

- ```js
  function getEvens(nums) {
    const evens = [];

    for (let i = 0; i < nums.length; ++i) {
      if (nums[i] % 2 === 0) {
        evens.push(nums[i]);
      }
    }

    return evens;
  }
  console.log(getEvens(numbers));
  ```

---

### Using `.filter` to get only even numbers

---

#### With named func

- ```js
  const isEven = num => num % 2 === 0;
  const evensOnly = numbers.filter(isEven);

  console.log(evensOnly);
  ```

---

#### With anon func

- ```js
  const dontBeOdd = numbers.filter(function(num) {
    return num % 2 === 0;
  });

  console.log(dontBeOdd);
  ```

---

#### Recreate `.filter`

- ```js
  Array.prototype.where = function(callback) {
    const filteredArr = [];

    for (let i = 0; i < this.length; ++i) {
      const currItem = this[i];
      const shouldKeepItem = callback(currItem, i, this);

      if (shouldKeepItem === true) {
        filteredArr.push(currItem);
      }
    }
    return filteredArr;
  };
  ```

---
