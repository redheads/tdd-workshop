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

// We inject an interface to the system-under-test!
// Mocking frameworks can control the behaviour of the injected object!
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

## Test Doubles

- Mock (spy)
  - emulate **outcoming** interactions
- Stub (dummy, fake)
  - emulate **incoming** interactions

---

![test-double](images/test-double.png)

---

## Test matrix

![test-matrix](images/test-matrix.png)
