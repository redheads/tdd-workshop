// we use node's systemJs module notation, because it works out-of-the-box with VS-Code's "Jest" plugin
const fizzbuzz = require('./fizzbuzz');

describe ('Testing the test framework', () => {
    test('greet Homer Simpson', () => {
        expect(fizzbuzz.greet("Homer Simpson"))
            .toBe("Hello Homer Simpson");
    })
    test('greet using ES6 arrow notation', () => {
        expect(fizzbuzz.greetArrow("Bart Simpson"))
            .toBe("Test Bart Simpson");
    })
})

describe ('FizzBuzz', () => {
    test('1 returns 1', () => {
        expect(fizzbuzz.fizzbuzz(1)).toBe("1");
    })
})
