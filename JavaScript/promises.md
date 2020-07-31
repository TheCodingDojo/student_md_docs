# Promise Examples

---

## Analogy

- Person1: I'm going to get some coffee, do you want some?
- Person2: Yes
- Person1: I promise to be back with coffee in 15 minutes
- There is no guarantee they will be back in 15 minutes, or with the coffee
- Store could be closed or have a problem and can't give him coffee, or some accident could happen and he may not make it back in 15 minutes or may abandon the task altogether and never be heard from again
- A JavaScript promise WILL get back to you, but it takes an unknown amount of time and could get back to you with an error

---

## `Promise`

- "The Promise object represents the eventual completion (or failure) of an asynchronous operation, and its resulting value." [[mdn docs]](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise)

---

### Async

- A `Promise` is async, we don't know how long it will take for the promise to be fulfilled
- normally code below only runs after the code above it finishes, but async means the code below may run BEFORE the code above it finishes
  - this is to prevent the rest of the code in our app from being delayed by code that takes an unknown amount of time
  - it's like when you are waiting for something to finish, and you go and get some other work done while waiting

---

### A `Promise` helps avoid callback hell

- callback hell is when you have many nested callbacks and your code consequently becomes very indented and hard to read
- because the `.then` and `.catch` methods can be chained onto the returned `Promise` (at same indentation level), they keep things flatter and less nested

---

## Set up fake 'database' with some data

- ```js
  /*
    Rickyism is the term devised by the fans of Trailer Park Boys for Ricky's malapropisms and eggcorns (substitution speech errors.)
  */
  const rickyisms = {
    0: "All for all and one for one.",
    1: "Beauty is in the eye when you hold her.",
    2: "It's clear to see who makes the pants here",
    3: "Can you give me a bit of credjudice?",
    4: "It's water under the fridge.",
    5: "Come to turns with it.",
    6: "Good things come to those at the gate.",
    7: "Don't judge a cover of a book by its look.",
    8: "What comes around is all around."
  };
  ```

---

## Get rickyism (with a delay to simulate API call)

- ```js
  // get single rickyism, can take 0-2 seconds
  function getRickyism(id, errorCallback, successCallback) {
    setTimeout(() => {
      if (rickyisms[id] !== undefined) {
        successCallback(rickyisms[id]);
      } else {
        errorCallback(`Rickyism id ${id} not found.`);
      }
    }, Math.floor(Math.random() * 2000));
  }
  ```

  - which function is `return`ing the rickyism?
    - the anonymous function that is a callback of `setTimeout`, so our `getRickyism` function isn't actually returning anything, so it returns `undefined`

---

### Pre-`Promise` solution to the `return` problem and handling the async timing

- have `getRickyism` accept two callbacks as args, one that will be called if successful, and one called if there is an error

  - you can then write whatever code you want to be executed when it's successful by writing that code in the success callback, same for the error callback

- ```js
  getRickyism(
    10,
    error => {
      console.log(error);
    },
    data => {
      console.log(`Rickyism id ${id}: ${data}`);
    }
  );

  getRickyism(
    2,
    error => {
      console.log(error);
    },
    data => {
      console.log(`Rickyism id ${id}: ${data}`);
    }
  );
  ```

---

### Async issue

- is the **first** `getRickyism` function call above guaranteed to give us a response before the 2nd `getRickyism` call?
  - no, because the first one might randomly take 2 seconds while the second one only takes 0.5 seconds

---

## Example of things that can take unknown amount of time

- reading a file, takes longer depending on how long the file is
- network requests

---

## Converting to using a `Promise`

- ```js
  function getRickyismPromise(id) {
    const newPromiseCallback = (resolve, reject) => {
      setTimeout(() => {
        if (rickyisms[id] !== undefined) {
          resolve(rickyisms[id]);
        } else {
          reject(`Rickyism ${id} not found.`);
        }
      }, Math.floor(Math.random() * 2000));
    };

    return new Promise(newPromiseCallback);
  }
  ```

  - our `getRickyismPromise` function no longer needs to be passed callbacks, because the `Promise` is passed a callback and then our `getRickyismPromise` function will return that promise
  - `console.log(getRickyismPromise(3))`
    - returns the unresolved `Promise` since it was logged before finishing
      - this is why we use `.then` and `.catch` which are called when it's resolved

---

### Handling the `return`ed `Promise`

- `getRickyismPromise(20);`

  - gives us an "Unhandled promise rejection" error because we did not `.catch` the error that was returned by the `Promise`'s `reject` callback

- ```js
  getRickyismPromise(20).catch(error => {
    console.log(error);
  });
  ```

- ```js
  getRickyismPromise(5).catch(error => {
    console.log(error);
  });
  ```

  - nothing logged now, because no error

- ```js
  getRickyismPromise(5)
    .then(data => {
      console.log(`Rickyism: ${data}`);
    })
    .catch(error => {
      console.log(error);
    });
  ```

  - `.then` will now log the data since there is no error

---

## Chaining Promises

- ```js
  // get a rickyism, wait for the data, then get a second rickyism (in order)
  getRickyismPromise(0).then(rickyism1 => {
    getRickyismPromise(1).then(rickyism2 => {
      console.log(`Rickyism1: ${rickyism1}, Rickyism2: ${rickyism2}`);
    });
  });
  ```

- this could get really messy very quickly if we chained it a few more times, and take a lot longer if you have to wait for each one to finish before even starting the next one

---

### `Promise.all` method - solution to chaining promises

- ```js
  Promise.all([
    getRickyismPromise(0),
    getRickyismPromise(1),
    getRickyismPromise(2)
  ]).then(data => {
    console.log(data);
  });
  ```

  - neater, more readable, but also, each one doesn't have to wait for the previous one to finish before it starts. They all start at the same time, but then wait for all to finish before running the `.then`

---

### `.catch` with `Promise.all`

- ```js
  // It's all or nothing, all successful or an error
  Promise.all([
    getRickyismPromise(10),
    getRickyismPromise(1),
    getRickyismPromise(2)
  ])
    .then(data => {
      console.log(data);
    })
    .catch(error => {
      console.log(error);
    });
  ```
