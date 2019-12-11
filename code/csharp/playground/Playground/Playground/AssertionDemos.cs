using FluentAssertions;
using NUnit.Framework;

namespace Playground
{
    [TestFixture]
    public class AssertionDemos
    {
        [Test]
        public void Classic_simple_string_comparison()
        {
            var result = "foo";
            
            // 1
            Assert.IsTrue(result == "foox");
            
            // 2
//            Assert.AreEqual(result, "foox");
        }

        [Test]
        public void Constraint_model_simple_string_comparison()
        {
            var result = "foo";

            // using Assert.That with `Is.`
            Assert.That(result, Is.EqualTo("foox"));
        }

        [Test]
        public void FluentAssertions()
        {
            "foo".Should().Be("foox");
        }
    }
}