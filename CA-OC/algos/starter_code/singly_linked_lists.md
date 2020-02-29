# Singly Linked List

## Starter Code

- ```js
  class Node {
    constructor(data) {
      this.data = data;
      this.next = null;
    }
  }

  class SList {
    constructor() {
      this.head = null;
    }

    // add your functions/methods here
    method1() {
      // method1's code
    }

    method2() {
      // method2's code
    }
  }

  const mySList = new SList();
  ```

  - `mySList` will come with all the methods that were added in the class definition
  - use the `this` keyword inside the classe's methods to refer to the `SList` instance that the method was called on
    - `mySList.method1()`: inside `method1`, the value of `this` will be `mySList`

## Alternate way to add methods to class

- ```js
  NameOfClass.prototype.newMethodsName = function(params) {
    // method's code here
    // 'this' keyword to refer to the instance the method was called on
  };
  ```
