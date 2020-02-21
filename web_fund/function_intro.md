# Function Intro

- A function is a way to re-use code so that you don't have to copy paste the same code when you need it to run again, instead, you put that code into a function and just execute the function when you need to and it will execute all the lines of code that were placed inside the function body
- A function may need to be given some information in order to do it's job

## Example

- let's make a simple function to check if someone has enough money to purchase something

### Analogy

- your friend calls you and asks: "Can I afford to buy this thing?"
  - what would you ask your friend in order to answer their question?
    - how much does it cost?
    - how much money do you have?
  - these are the exact pieces of information (**parameters**) that your function would also need to know in order to answer the question / solve the problem
  - The question is a yes or no question, so our function should `return` a `true` or a `false`

### Solution

- ``` js
  function canAffordToBuy(cost, budget) {
    if (cost <= budget) {
      return true;
    }
    else {
      return false;
    }
  }
    ```

  - parameter1 is `cost`
  - parameter2 is `budget`
  - when the function is called / executed, it needs to be given / passed these pieces of information in this order

- ``` js
  canAffordToBuy(10, 20);
    ```

  - argument1 is `10`, the value of the `cost` parameter will be `10`
  - argument2 is `20`, the value of the `budget` parameter will be `20`

### Store the returned value

- ``` js
  var canAffordCar = canAffordToBuy(20000, 15000);
    ```

  1. `canAffordToBuy(20000, 15000);` returns `false`
  2. the variable `canAffordCar` has `false` assigned to it
