# What is `this` in JS?
- other languages have the same concept, but it may be named differently, such as: `self`

# Analogy
- ask yourself what the word `this` is used for in natural language?
- it can be used to refer to anything, the listener knows what it refers to based on the context of the conversation
  - the word `this` can be used multiple times in a conversation where each time it is used it refers to something else, because as the context of the converstaion changes, the word `this` will also change what it refers to
- In code, there is a context to the code that is executing, just like there is a context to a conversation
  - it is referred to as the 'execution context'.
    - how, when, and from where is the function being executed is what determins the context and the value of the `this` keyword
  - for example: is the function being executed from within an object or from the global scope (not nested in any other code)
    - since these are two different contexts, the value of the `this` keyword will be different from one context to another
    - if it is a non-arrow function that is inside of an object, usually `this` will refer to the object that the function is inside of. When a function is inside of an object it is generally referred to as a method.
    - if the function is in the global scope (not nested in any other code), `this` will refer to the browser's `Window` object

  
# `function` vs Arrow Function
- regular functions and arrow functions will determine the value of the `this` keyword differently
- it's not a perfect analogy, but imagine two different people interpreting the context of a conversation differently, they both might think the word `this` in the conversation is referring to something different.
- in short, `function` determines the value of `this` on their own, whereas "An arrow function does not have its own `this`. The `this` value of the enclosing lexical scope is used"

## `.bind` and `.call`
- `.bind`. and `.call` are two methods that can be used on non arrow functions to manually set the value of `this` so that when the function is executed, the value of `this` will be whatever was manually specified
- you likely won't have to use `.bind` and `.call` much for now
- sometimes when these methods are needed for a regular function, converting it to an arrow function will make `this` point to what you want it to be and then you won't need to use these methods

# Advice
- It's confusing to try to understand or memorize how the two different types of functions differ regarding the `this` keyword
- I wouldn't spend too much time worrying about it, instead, if you just remember to verify what the value of `this` is (`console.log(this)`), you will be fine. And if it's not the value you want, you can test out using the other type of function and through practicing in this way, you will get used to it.
- Generally, methods of objects / classes should be normal functions so that `this` will point to the object that the method is inside of, which is helpful
  - however, in some frameworks like react, when using class based components, using an arrow function for methods of the component class will help make `this` stay pointed to that particular instance of the class
