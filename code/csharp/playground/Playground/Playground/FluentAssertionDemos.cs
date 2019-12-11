using System;
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

        [Test]
        public void Collections_tests()
        {
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
        }

        [Test]
        public void Exceptions_tests()
        {
            Action action = () => Throws();
            action.Should()
                .Throw<Exception>()
                .WithMessage("Ups");
        }

        private static void Throws() 
            => throw new Exception("Ups");

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

        private static Bar MapIntToBar(int foo)
        {
            if (foo < 0)
            {
                return Bar.Undefined;
            }

            if (foo == 0)
            {
                return Bar.All;
            }

            if (foo == 1)
            {
                return Bar.Beer;
            }

            if (foo == 2)
            {
                return Bar.Whiskey;
            }
            
            if (foo == 3)
            {
                return Bar.Water;
            }

            return Bar.Undefined;
        }

        public enum Bar
        {
            Undefined,
            All,
            Water,
            Beer,
            Whiskey
        }
    }
}