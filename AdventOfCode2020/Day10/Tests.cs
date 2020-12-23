using NUnit.Framework;

namespace Day10
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.GetOneJoltMultipliedByThreeJoltDifferences(@"Data\input.dat");
            Assert.AreEqual(1917, result);
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetOneJoltMultipliedByThreeJoltDifferences(@"Data\simple.dat");
            Assert.AreEqual(5 * 7, result);

            var result1 = Tools.GetOneJoltMultipliedByThreeJoltDifferences(@"Data\simple1.dat");
            Assert.AreEqual(22 * 10, result1);
        }
    }
}