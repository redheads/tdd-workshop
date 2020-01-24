# Javascript FizzBuzz

I'll be using VS Code as editor in these examples.

But you can use any editor you like.

## Prerequisites

- `npm`: [https://www.npmjs.com/get-npm](https://www.npmjs.com/get-npm)
- `npx`: Install `npm` first, then install `npx`: `npm install -g npx`

## Useful VS Code extensions

- `Javascript`: standard javascript extension
- `Jest`: nice on-the-fly continous testing plugin
- `Bracket Pair Colorizer`: highlight brackets in different colors

## Initial setup

```sh
npm init -y
npm install -D jest
```

Create a file `fizzbuzz.js`:

```javascript
function hello(s) {
    return "Hello " + s;
}

function fizzbuzz(number) {
    return "1";
}

exports.hello = hello;
exports.fizzbuzz = fizzbuzz;
```

Create a file `fizzbuzz.test.js`:

```javascript
const fizzbuzz = require('./fizzbuzz');

describe ('Testing the test framework', () => {
    test('greet Homer Simpson', () => {
        expect (fizzbuzz.hello("Homer Simpson")).toBe("Hello Homer Simpson");
    })
})

describe ('FizzBuzz', () => {
    test('1 returns 1', () => {
        expect(fizzbuzz.fizzbuzz(1)).toBe("1");
    })
})
```

Initial check if everything works as expected:

```sh
npx jest
```

The output should look like this (with some colors in the terminal):

```sh
$ npx jest
 PASS  ./fizzbuzz.test.js
  Testing the test framework
    ✓ greet Homer Simpson (3ms)
  FizzBuzz
    ✓ 1 returns 1 (1ms)

Test Suites: 1 passed, 1 total
Tests:       2 passed, 2 total
Snapshots:   0 total
Time:        0.845s, estimated 1s
Ran all test suites.
```

## Continuous testing

### From the command line (CLI)

Open a terminal and run:

```sh
npx jest --watchAll
```

This command will run all tests. Then it waits for changes. As soon as changes are made, the tests will automatically run (without further user interaction!).

TODO Add gif showing how this looks like in practice.

### Within VS Code

The previously mentioned `Jest` plugin will automatically detect test changes and run tests in the background.

TODO Add gif showing how this looks like in practice.
