# README

- [Example](https://github.com/neilm813/MouthOopChallenge)

## Challenge Description

- In the real world, a man has a mouth. His mouth can do operations like open/close at the man's will. Another man cannot force a man to do such operations without the man's permission. For example, a doctor can examine his mouth and request him to do such operations and he will follow the doctor's requests after confirming the doctor's identity. For others, he doesn't want them to do such operations. Use OOP Designs to make needed classes with methods to meet those requirements. You can use any language or pseudo- code to write down your results.

## My Analysis of the requirements & challenges

- Since this is an OOP challenge, I believe the mouth should be it's own class
- I interpet "For example, a doctor can examine his mouth" to mean the mouth should be visible to other people, but only the owner can control the mouth
  - the difficulty here is making the mouth it's own class so it can be reusable, allowing it to be `set` only by the owner of the mouth but `get` by anyone so anyone can see the mouth
  - if the mouth's props are made private, then even the owner of the mouth (a class with a mouth prop inside of it) cannot `set` the mouth, so this seems to require making the mouth's props public and solving the `set` only by owner some other way
  - if the mouth is returned as an interface with readonly props, then it cannot be `set`, but this prevents the usage of methods on the mouth that `set` props / fields of the mouth, because returning as an interface would allow access to these methods which could allow the ability for anyone to `set`
