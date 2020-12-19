using NUnit.Framework;

namespace Day1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SimpleTest()
        {
            var result1 = Tools.MultiplyTwoElementsOfSearchedSum(@"Data\testData0.dat");
            Assert.AreEqual(514579, result1);
        }

        [Test]
        public void FinalTest()
        {
            var result2 = Tools.MultiplyTwoElementsOfSearchedSum(@"Data\input.dat");
            Assert.AreEqual(55776, result2);
        }
    }
}