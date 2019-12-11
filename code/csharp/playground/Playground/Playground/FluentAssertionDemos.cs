using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Playground
{
    public class FluentAssertionDemos
    {
        [Test]
        public void Parse_even_numbers()
        {
            var input = new List<int>{0, 1, 2, 3, 4};
            var result = GetEvenNumbers(input);
            result.Should()
                .BeEquivalentTo(
                    new List<int>{0, 2, 4}, 
                    "odd numbers are wrong");
        }

        // wrong implementation
        private static IEnumerable<int> GetEvenNumbers(IEnumerable<int> input) 
            => input.Where(x => x % 2 != 0).ToList();
    }
}