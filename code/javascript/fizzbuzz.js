function greet(s) {
    return "Hello " + s;
}

// ES6 syntax (arrow notation)
const greetArrow = (s) => "Test " + s;

function fizzbuzz(number) {
    return "1";
}

// we use node's systemJs module notation, because it works out-of-the-box with VS-Code's "Jest" plugin
exports.greet = greet;
exports.greetArrow = greetArrow;
exports.fizzbuzz = fizzbuzz;
