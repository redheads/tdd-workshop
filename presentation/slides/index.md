---
title: Testing
theme: sky
revealOptions:
    transition: 'fade'
    controls: false
    progress: false
    autoPlayMedia: true
    transitionSpeed: slow

---

FILE: 01-intro.md

---

FILE: 02-tooling.md

---

## What should we test?

---

## What should we test?

- **focus on user stories**, not on technical details
- **often evokes better design!**

---

Let's code!

---

## Integration testing

- testing how different components interact
- composing interactions

---

## Integration testing

- Always a good indicator for
  - decoupling
  - correct layer of abstraction

---

```csharp
// Arrange
var mailer = Substitute.For<IMailer>();

var validCustomer = new ValidCustomer();
var sut = new RegistrationService(mailer);

// Act
sut.Register(validCustomer);

// Assert
mailer.Received().Send();
```

---

## What should we test?

---

## What should we test?

- **focus on user stories**, not on technical details
- **often evokes better design!**
- when testing technical details:
  - focus on happy path
  - bug report: write a test demonstrating the bug; then fix the bug
  - keep techn. tests maintainable!

---

FILE: 99-exit.md
