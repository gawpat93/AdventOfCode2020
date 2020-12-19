using NUnit.Framework;

namespace Day1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result1 = Tools.MultiplyTwoElementsOfSearchedSum(@"Data\input.dat");
            Assert.AreEqual(55776, result1);

            var result2 = Tools.MultiplyThreeElementsOfSearchedSum(@"Data\input.dat");
            Assert.AreEqual(223162626, result2);
        }

        [Test]
        public void SimpleTest()
        {
            var result1 = Tools.MultiplyTwoElementsOfSearchedSum(@"Data\testData0.dat");
            Assert.AreEqual(514579, result1);

            var result2 = Tools.MultiplyThreeElementsOfSearchedSum(@"Data\testData0.dat");
            Assert.AreEqual(241861950, result2);
        }
    }
}