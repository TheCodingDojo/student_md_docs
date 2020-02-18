# Basic Dozen Algos

## Starter Code

- ``` js
  for (let i = 0; i < arr.length; i++) {
    // your code here
  }

  // no parameters or as many as needed
  function funcName (param1, param2) {
    // your code here
  }

  // execute function, no args or as many as the function needs (corresponding to params)
  // the arguments are the actual values you give to your func to be accessed via the parameter names
  funcName(arg1, arg2);
    ```

## Function Example

### Define the function

- ``` js
  function addTwo(n1, n2) {
    return n1 + n2;
  }
    ```

  - `n1` is the name of paremeter1, `n2` is the name of parameter2
  - parameters are placeholders for the actual values that will be passed in to the function when it is executed

### Execute the function

- ``` js
  var sum = addTwo(5, 10);
    ```

  - `5` is argument1, `10` is argument2
  - arguments are the actual values that are passed in to the function when it is executed
  - `n1` will have the value `5` and `n2` will have the value `10`
  - `var sum = addTwo(5, 10);` returns the result of the addition and assigns that result into the `var` named `sum`

## Basic Dozen

1. Print integers 1 through 100
2. Print integers 1 through 100 backwards
3. Print integers evenly divisible by 5 that are between 1 and 100
4. Function: return the sum of a given array of integers
5. Function: Given an array of integers, create and return a new array that has only the even integers
6. Function: Given an array of integers, print the average of only the odd numbers
7. Function: Given an array of integers, replace negative numbers with the string 'negative' and positive numbers with the string 'positive'
8. Function: Given an array of integers, return the sum of the min and the max values
9. Function: Given an array, swap the first and the last items
10. Function: Given an array and an integer, return a count of how many integers are less than the Function: given integer
11. Function: Given a start integer and a stop integer, print integers from the start (inclusive) to the stop (exclusive)
12. Function: Given an array, shift each item to the right 1 index, replace the first item with 0