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

## Hello World unit test

```csharp
// production code
public int Add(int a, int b) => a + b;

// test code
[Test]
public void Add_1_and_1_returns_2()
    => Assert.That(Add(1, 1), Is.EqualTo(2));
```

---

## C# Testing frameworks

- MSTest
  - the "Internet Explorer" of testing frameworks
- NUnit
  - port of JUnit
  - very stable & actively maintained
- xUnit
  - successor of NUnit
  - modern & very modular
  - Microsoft uses xUnit

---

## NUnit basics

- `TestFixture` attribute on test class
- `Test` attribute on method
- `SetUp`, `TearDown`, `SetUpFixture`, `TearDownFixture`
- parameterized test
  - [https://github.com/nunit/docs/wiki/Parameterized-Tests](https://github.com/nunit/docs/wiki/Parameterized-Tests)

---

## Optional: xUnit basics

- no attribute on test class needed
- `Fact` attribute on method
- no setup/teardown: use ctor and `Dispose` instead
- parameterized test
  - [parameterized test with xUnit](https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/)

---

## NUnit assertions

[https://github.com/nunit/docs/wiki/Assertions](https://github.com/nunit/docs/wiki/Assertions)

- Classic model (deprecated!): [https://github.com/nunit/docs/wiki/Classic-Model](https://github.com/nunit/docs/wiki/Classic-Model)
- Constraint model: [https://github.com/nunit/docs/wiki/Constraint-Model](https://github.com/nunit/docs/wiki/Constraint-Model)

---

## NUnit classic assertions

```csharp
var result = "foo";

// (1)
Assert.IsTrue(result == "foox");

// (2)
Assert.AreEqual(result, "foox");
```

- Both assertions fail.

---

Error message from (1) is useless:

```text
Expected: True
But was:  False
```

Error message from (2):

```text
Expected string length 3 but was 4. Strings differ at index 3.
Expected: "foo"
But was:  "foox"
--------------^
```

---

## Problem with all assertion equal tests

```csharp
Assert.AreEqual(result, "foox");
```

I can never remember the order of parameters, because each framework is different. 

- some use `(actual, expected)`
- others use `(expected, actual)`

This makes reading the error message difficult.

---

## NUnit constraint model

- always uses the `Assert.That(...)` syntax

Example:

```csharp
var result = "foo";
Assert.That(result, Is.EqualTo("foox"));
```

- readability improvement
- sane error message

---

## Why are error message important?

- local machine: Quick feedback
  - continous testing
  - just read the error message and know what's wrong
- CI server
  - Fail email: why?

- Test naming & error message should tell a story

---

## Test naming conventions

- always name test so that error message is clear
- readability tip: use snake case for tests
  - examples:
    - `Adding_1_and_1_returns_2`
    - `Creating_customer_with_missing_name_throws`
- use inner classes for methods needing multiple tests
  - example:
    - `CustomerProvider` with method `GetCustomerById`:

----

Example

```csharp
[TestFixture]
public class CustomerProviderTests
{
    private class GetById
    {
        [Test]
        public void With_valid_id()
        {
            // ...
        }

        [TestCase(null)]
        [TestCase(0)]
        [TestCase(-1)]
        public void With_invalid_id_returns_null(int? customerId)
        {
            // ...
        }
    }
```

Error message:

```text
CustomerProviderTests
    -> With_valid_id
    -> With_invalid_id_returns_null
```

---

## Alternative assertion libraries

- FluentAssertions: [https://fluentassertions.com/](https://fluentassertions.com/)
- NFluent: [http://www.n-fluent.net/](http://www.n-fluent.net/) 

Goal: improve readability and error messages

```chsarp
// FluentAssertions
"foo".Should().Be("foox");
```

Pros: works with all test framework

---

## FluentAssertions

[https://fluentassertions.com/](https://fluentassertions.com/)

----

### Error message: Reason

TODO

----

### Collections

TODO

----

### Exceptions

TODO

----

### EquivalentTo

TODO

---

## Test anatomy

- Arrange, Act, Assert (AAA)
- Given, When, Then

```csharp
// Arrange
var num1 = 1;
var num2 = 1;
var sut = new Calculator();
var expectedResult = 2;

// Act
var result = sut.AddNumbers(num1, num2);

// Assert
result.Should().Be(expectedResult);
```

- `Arrange` can be very long!
  - redesign?
- `Act` should only be 1 line!
- `Assert` can be very long!
  - write dedicated assertion?
  - use `AssertionScope`

---

## Run code before / after each test

- Test code should be treated with the same care as production code
- Useful when code repeats itself

---

## Run code before / after each fixture

- Useful for integration tests
  - example: DB setup/teardown

---

## Parameterized tests

TODO

---

## What should we test?

- focus on user stories, not on technical details
- often evokes better design!
- when testing technical details:
  - focus on happy path
  - bug report: write a test demonstrating the bug; then fix the bug
  - make tests maintainable

---

FILE: 99-exit.md
