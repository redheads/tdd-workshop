const fizzbuzz = require('./fizzbuzz');

describe ('Testing the test framework', () => {
    test('greet Homer Simpson', () => {
        expect(fizzbuzz.greet("Homer Simpson"))
            .toBe("Hello Homer Simpson");
    })
})

describe ('FizzBuzz', () => {
    test('1 returns 1', () => {
        expect(fizzbuzz.fizzbuzz(1)).toBe("1");
    })
})
