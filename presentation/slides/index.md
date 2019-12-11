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
  - the "IE" of testing frameworks
- NUnit
  - port of JUnit
  - very stable & actively maintained
- xUnit
  - successor of NUnit
  - modern, stable & very modular
  - Microsoft uses xUnit

---

## NUnit basics

- `TestFixture` attribute on test class
- `Test` attribute on method

```csharp
[TestFixture] // <--
public class CustomerRepositoryTests
{
    [Test]    // <--
    public void GetById_bla(){}
}
```

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

```text
Adding_1_and_1_returns_2
Creating_customer_with_missing_name_throws
```

- use inner classes for methods needing multiple tests

```text
CustomerProvider with method GetCustomerById
```

live coding

----

Example

```csharp
[TestFixture]
public class CustomerProviderTests
{
    private class GetById
    {
        [Test]
        public void With_valid_id() {}

        [Test]
        public void With_invalid_id_returns_null() {}
    }
```

Error message:

```text
CustomerProviderTests
    -> GetById
        -> With_valid_id
        -> With_invalid_id_returns_null
```

---

## Alternative assertion libraries

- FluentAssertions: [https://fluentassertions.com/](https://fluentassertions.com/)
- NFluent: [http://www.n-fluent.net/](http://www.n-fluent.net/) 

Goal: improve readability and error messages

```csharp
// FluentAssertions
"foo".Should().Be("foox");
```

Bonus: works with all test framework

---

## FluentAssertions

[https://fluentassertions.com/](https://fluentassertions.com/)

----

### Error message: Reason

Most methods have an optional "reason" string

```csharp
[Test]
// wrong implementation
private static IEnumerable<int> GetEvenNumbers(IEnumerable<int> input) 
    => input.Where(x => x % 2 != 0).ToList();
}

public void Parse_even_numbers()
{
    var input = new List<int>{0, 1, 2, 3, 4};
    var result = GetEvenNumbers(input);
    result.Should()
        .BeEquivalentTo(
            new List<int>{0, 2, 4}, 
            "odd numbers are wrong");
}
```

```text
Expected result to be a collection with 3 item(s) 
because odd numbers are wrong, but {1, 3}
contains 1 item(s) less than {0, 2, 4}.
```

----

### Collections

```csharp
var list = new List<string>
{
    "foo",
    "bar",
    "baz"
};

list.Should()
    .HaveCount(3)
    .And.Contain("foo")
    .And.Contain("bar")
    .And.Contain("baz")
    .And.NotContain("42");
```

----

### Exceptions

```csharp
private static void Throws() 
    => throw new Exception("Ups");

[Test]
public void Exceptions_tests()
{
    Action action = () => Throws();
    action.Should()
        .Throw<Exception>()
        .WithMessage("Ups");
}
```

----

### EquivalentTo

Shameless self plug:

[http://draptik.github.io/blog/2016/05/09/testing-objects-have-same-properties/](http://draptik.github.io/blog/2016/05/09/testing-objects-have-same-properties/)

---

## Test anatomy

- Arrange, Act, Assert (AAA)
- Given, When, Then

---

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

- Test code should be treated with the same care as production code

---

## Arrange: Parameterized tests (1/2)

```csharp
[TestCase(-1, Bar.Undefined)]
[TestCase(0, Bar.All)]
[TestCase(1, Bar.Beer)]
[TestCase(2, Bar.Whiskey)]
[TestCase(3, Bar.Water)]
[TestCase(4, Bar.Undefined)]
[TestCase(99, Bar.Undefined)]
public void MapIntToBar(int input, Bar expected)
{
    MapIntToBar(input).Should().Be(expected);
}
```

---

## Arrange: Parameterized tests (2/2)

- [https://github.com/nunit/docs/wiki/TestCaseSource-Attribute](https://github.com/nunit/docs/wiki/TestCaseSource-Attribute)

```csharp
[TestCaseSource(typeof(CustomerTestData))]
public void CustomerIsValid(Customer customer, bool expected)
{
    customer.IsValid().Should().Be(expected);
}

private class CustomerTestData : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] {
            new Customer {FirstName = null, LastName = null}, false};
        yield return new object[] {
            new Customer {FirstName = "a", LastName = "b"}, true};
    }
}
```

---

## Run code before / after each test

- Useful when code repeats itself

---

## Run code before / after each fixture

- Useful for integration tests
  - example: DB setup/teardown

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
