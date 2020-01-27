**now** you know the **tooling**!

---

Let's use **testing** to **DRIVE** our **development**!

---

## Recap: Traditional approach

- Design
- Implementation
- Test

---

### Drawbacks when writing tests at end

- low test coverage
- late testing: rethink problem
- knowledge of implementation: changes how tests are written
- not automated

---

## Test-Driven Development (TDD)

- Design
- Test
- Implementation

---

## TDD Workflow

- Red
- Green
- Refactor

---

![tdd-cycle](images/TDD.png)

---

- no code without test
- untested code should not go live
- baby steps: only write code to make test pass

---

## TDD patterns

- isolated tests
- Test List (on paper, not in code -> small steps)
- Test first -> less "stress"
- Assert first
- use Test data (vs realistic data)

---

## red bar patterns

Patterns decribing

- when to write tests
- where to write tests
- when to stop writing test

---

## red bar patterns

- Starter test
- Explaining test
- Regression test
- One step test

---

### Starter test

- Output equals input
- input as small as possible

---

### Explaining test

- Test should explain what is happening

---

### Regression test

- small test reproducing error
- why wasn't the test there before?
- Redesign?

---

### One step test

- Categorize tasks by difficulty
  - Obvious
  - no idea
  - WAT?
  - **this I can do**

---

## green bar patterns

Patterns describing how to go from red to green

- obvious implementation
- triangulation
- "fake it til you make it"

---

### Obvious implementation

- simple enough -> just implement it (driving in 2nd gear)
- BUT: if you encounter surprising red bars -> take smaller steps ("be prepared to downshift")

---

### Triangulation

- Abstract only if you have 2 or more examples
- Use when you are really unsure about correct abstraction.
- Prefer "fake it til you make it" or "Obvious Implementation"

---

### fake it til you make it

- return a constant and gradually replace constants with variables until you have the real code
- Why would you do something that you know you have to rip out?
  - having something running is better than not having something running
  - psychological: green bar -> convidence to refactor
  - scope control: ignore potential future problem -> focus in simple problem -> repeat

---

### Transformation Priority Premise

- ...gradually replace constants with variables...
- taken one step further
- [Example using Transformation Priority Premise](https://codurance.com/2015/05/18/applying-transformation-priority-premise-to-roman-numerals-kata/)

---

### Advantages of TDD

- high test coverage
- increases modularity
- improves maintainability
- implicit documentation

---

let's code

Fizz-Buzz Kata

---

## Schools of TDD

- **Classical**
  - aka Detroit, Chicago, "inside-out", "fake it til you make it"
  - K. Beck: Test-Driven Development By Example
- **London** 
  - aka moquist, "outside-in"
  - Freeman & Pryce: Growing Object Oriented Software Guided by Tests
- Munich: [David Voelkl](https://www.youtube.com/watch?v=n62HN2DHDEU)
- Hamburg: [Ralph Westpfahl](https://ralfw.de/2019/07/hamburg-style-tdd/)
