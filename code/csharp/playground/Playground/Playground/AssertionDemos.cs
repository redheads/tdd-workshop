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
    }
}