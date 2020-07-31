# OOP & Prototype Intro

- `node path/to/fileName.js` to run
- `nodemon path/to/fileName.js` to auto refresh & run on code change
- [What is this in JS - doc to share](https://github.com/TheCodingDojo/student_md_docs/blob/master/CA-OC/JavaScript/what_is_this.md)

## Prototype

- Prototype: "a first, typical or preliminary model of something, especially a machine, from which other forms are developed or copied."
- JS is a prototype based language, different from languages with classical inheritance (like C# and Java)
- Prototypal Inheritance: A prototype is a WORKING object instance. Objects inherit directly from other objects.
  - working object instance refers to the fact that it is not a blueprint like a class, it is an actual working instance already, unlike a class which is not an instance itself, because it is a blueprint used to create instances.
  - proof the prototype is a working object:
    - `Array.prototype.push('this is a working prototype');`
    - `Array.prototype[0]`

## Bracket vs Dot notation refresher

- if your key is stored in a variable (or is a non string), you must use brackets
  - this is because anything after the dot is treated as the key name itself
    - if you put a var name after the dot, it will try to find a key named the same as the var name instead of using the value inside the var

## `Class` Keyword

- `Class` keyword in js is "syntactical sugar"
- at our level, we can work with js classes in more or less the same way as we do in other languages, but there are some differences

- ```js
  class Foo {}
  typeof Foo; // 'function'
  ```

- "In JavaScript, class inheritance is implemented on top of prototypal inheritance" - Eric Elliot
  - it's not exactly the same as classical inheritance though, you can read about this if you want to know more, it's beyond the scope currently

## Ways to Create Objects

### Object Literal

- no blueprint, just use curly braces to create an object with the structure you need at that time

- ```js
  const objectLiteral = {
    key1: "val1",
    key2: "val2",
    methodName: function() {
      console.log("method on object literal");
    }
  };
  ```

### Factory Function

- function that takes in params and uses them to build and return an object literal

- ```js
  function HumanFactory(firstName, lastName, height) {
    return {
      firstName: firstName,
      lastName: lastName,
      // shorthand: can omit the colon when param name is same as key name
      height,
      fullName: function() {
        console.log(`${this.firstName} ${this.lastName}`);
      },
      // shorthand method
      fullName2() {
        console.log(`${this.firstName} ${this.lastName}`);
      }
    };
  }
  ```

### Constructor function

- `class` keyword is "syntactical sugar" (makes syntax more appetizing) for a constructor function
- constructor function takes parameters that get assigned to keys on `this` object (the new object being created). Similar to `self` in python
- `return` is implicit: `this` new object will be returned automatically
- needs to be invoked / called with `new` keyword

- ```js
  function HumanConstructor(firstName, lastName, height) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.height = height;

    // this method is duplicated onto every instance
    // can manually add it to prototype so it is shared instead
    this.fullName = function() {
      console.log(`${this.firstName} ${this.lastName}`);
    };
  }

  const humanFromConstructorFn = new HumanConstructor("Isaac", "G", "5'8");
  ```

### Class

- ```js
  // syntactical sugar for HumanConstructor
  class Human {
    constructor(firstName, lastName, height) {
      this.firstName = firstName;
      this.lastName = lastName;
      this.height = height;
    }
    // added to the prototype because it's outside the constructor
    fullName() {
      console.log(`${this.firstName} ${this.lastName} FROM PROTOTYPE`);
    }
  }

  const humanFromClass = new Human("fn", "ln", "height");
  ```

  - `console.log(humanFromClass)`
    - notice that `fullName` is not visible as a key on the object
    - open up `__proto__` and you will see `fullName` is there, shared from the proto
    - if `fullName` method was added in the `constructor` it would be a method directly on every instance, this takes up more space because the method is duplicated to every instance instead of a single method that is shared

## More `.prototype` examples

- `Array.prototype.print = function() { console.log(this.join(", ")) };`
  - now every new array will come with this `print` method
- `console.log([])`
  - open up `__proto__`, this is where you can see all the methods an array comes with automatically, like `.push` and `.pop`, but these are not directly on the new array, they are inherited from the proto
- `.prototype` is not available on instances, only on the constructor
- `.__proto__` is available anywhere

## Advanced Extras

### To avoid methods on objects created from factory functions being copied to every object:

- ```js
  const carProto = {
    drive() {
      console.log("Vroom!");
    }
  };

  const factoryCar = () => Object.create(proto);
  ```

  - [Object.create](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Object/create) can be combined with [Object.assign](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Object/assign) to assign incoming props to the new object that is created. Keys present in both **source** and **target** will take the value from **source**
  - src: [Eric Elliot - Factory Functions vs Costructor Functions vs Classes](https://medium.com/javascript-scene/javascript-factory-functions-vs-constructor-functions-vs-classes-2f22ceddf33e)
