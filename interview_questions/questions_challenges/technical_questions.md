# [Trello Board](https://trello.com/b/aUV3OKmx/tech-interview-questions)

# 2nd Job In Industry
## 12.02.19
- Was at first job for 3 months then got laid off
- 2nd job took a few months to find, went from $65k/y to 97k/y

### Questions
1. what to do if displaying data on web page from the db when the data in the db is changing frequently?
    - open a socket if you need to get the data too frequently for separate calls
    - call the db on a set interval to get updated data
    - provide a refresh data button for the client to press when they need the new data

### Challenges
#### Weather App
- was given 1 week
- build an app that consumes a weather API to display weather data and deploy it via google cloud
- during follow up in person interview, was asked to add a few recommended changes to this app within 2 hours alotted time
  1. change `await` calls to be async 

# 1st Job After Bootcamp
## 01/16/2020
### Questions
- What does REST stand for / what is it for
- What does API stand for?
- How do you handle asyncrhonous API calls in JS
  - Promises, Observables, Callbacks
- Do you know what PEP8 is?
- What is functional programming
- What is a class vs what is an object
- What is a function decorator
- What is a singleton

### Algos
- Input: Array of ints 1 through 100 in order with one integer missing
- Output: The missing integer