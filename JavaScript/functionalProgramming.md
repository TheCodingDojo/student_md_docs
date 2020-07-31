# Functional Programming (`.forEach`, `.map`, `.filter`)

- just like OOP is a programming paradigm focused around objects, functional programming is a programming paradigm centered around functions
- in JS, functions can be passed to other functions as an argument, in the same way that you can pass an object to a function as an argument
  - the main difference is that if a function is passed as an argument, the corresponding parameter needs to be treated like a function, meaning it can be executed when you want to run the function that was passed in (the callback function, you call the function back at a later at the right time)

---

## Arrow function syntax variations

- arrow functions are not hoisted
- use `()` when there are no parameters just like a regular function

### Regular function for comparison

- equivalent to below isEven arrow function examples

- ```js
  // function declaration (is hoisted, preceding code can execute it)
  function isEven(num) {
    return num % 2 === 0;
  }
  ```

- ```js
  // function expression, function saved in var, is executed the same way (is not hoisted, preceding code cannot execute it)
  const isEven = function (num) {
    return num % 2 === 0;
  };
  ```

### Full long-form arrow function syntax

- ```js
  const isEven = (num) => {
    return num % 2 === 0;
  };
  ```

### Full shorthand arrow function syntax

- no parenthesis are needed if there is a single parameter only
  - parenthesis MUST surround paremeters if there is more than one parameter
- no curly braces are needed if the body of the function is one line of code only
  - curly braces MUST be added as soon as you add another separate line of code
- `return` can be omitted, the result of the function body is automatically returned when not using curly braces
- `const isEven = num => num % 2 === 0;`

  - single param called `num`, implicitly (automatically) returns the result of `num % 2 === 0` which is a boolean

### Shorthand arrow syntax returning an object

- with shorthand, if **returning an object**, then the curly braces are ambiguous, the interpreter thinks the curly braces are for the function body and not the returned object, parenthesis MUST be used in this case if NOT using curly braces for function body and some other cases with more complex expressions

  - ```js
    const personFactory = (firstName, lastName) => ({
      firstName: firstName,
      lastName: lastName,
    });
    ```

### Long-form arrow syntax returning an object

- ```js
  const personFactory = (firstName, lastName) => {
    return { firstName: firstName, lastName: lastName };
  };
  ```

### Arrow function syntax advice

- to start, ALWAYS use the full long-form so you don't run into issues of forgetting to add in parenthesis or curly braces when they are needed, the long-form is the only form that works in all cases
- use shorthand once you become comfortable

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
  const students = [
    { name: "Ricky", attendedLecture: false },
    { name: "Bubbles", attendedLecture: false },
    { name: "Juliann", attendedLecture: false },
  ];
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
  const printOneItem = (item) => {
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

  nums.forEach(function (item, idx) {
    console.log(`The item is: ${item}. The index is: ${idx}`);
  });

  // arrow function long-form, return keyword needed if you need to return something
  nums.forEach((item, idx) => {
    console.log(`The item is: ${item}. The index is: ${idx}`);
  });

  // arrow function shorthand for one line of code after the arrow
  // what is after arrow is implicitly (auto) returned
  // sometimes code after arrow needs to be wrapped in parenthesis
  nums.forEach((item, idx) =>
    console.log(`The item is: ${item}. The index is: ${idx}`)
  );
  ```

  - here, our function is being created on the fly as the first argument
  - just like you can create an array on the fly and pass it to a function, you can create a function on the fly and pass it to a function

    - ```js
      printAllItems([10, 11, 12]);
      ```

### Update array of objects with `.forEach`

- ```js
  const studentsAttendingLecture = ["Bubbles"];
  console.log(students);

  students.forEach((student, idx) => {
    if (studentsAttendingLecture.includes(student.name)) {
      student.attendedLecture = true;
    }
  });
  console.log(students);
  ```

---

### Recreate `.forEach` so we can peak under the hood

- ```js
  // Add new method to the Array.prototype so every array has access to it
  Array.prototype.forEvery = function (callback) {
    // this keyword will refer to the array that .forEvery is called on

    for (let i = 0; i < this.length; ++i) {
      // forEach also sends the whole array to your callback as arg3
      callback(this[i], i, this);
    }
  };

  // call our newly added method on the nums array
  numbers.forEvery((item, idx) => {
    console.log(`Item: ${item} at Idx ${idx}`);
  });
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
  const doubleNums = (nums) => {
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
  const doubledNums = numbers.map((num) => {
    return num * 2;
  });
  console.log(doubledNums);
  ```

---

### Recreate `.map`

- ```js
  Array.prototype.map2 = function (callBack) {
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
  const isEven = (num) => {
    return num % 2 === 0;
  };

  const evensOnly = numbers.filter(isEven);

  console.log(evensOnly);
  ```

---

#### With anon func

- ```js
  const dontBeOdd = numbers.filter(function (num) {
    return num % 2 === 0;
  });

  console.log(dontBeOdd);
  ```

---

### Filter array of objects

- ```js
  const delinquentStudents = students.filter((student) => {
    return student.attendedLecture === false;
  });

  console.log(delinquentStudents);

  const goodBois = students.filter((student) => {
    return student.attendedLecture === true;
  });

  console.log(goodBois);
  ```

---

#### Recreate `.filter`

- ```js
  Array.prototype.where = function (callback) {
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
