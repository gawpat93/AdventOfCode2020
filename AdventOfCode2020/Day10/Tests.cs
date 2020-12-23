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

            Assert.AreEqual(113387824750592, Tools.GetNumberOfAllPossibleCombinations(@"Data\input.dat"));
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetOneJoltMultipliedByThreeJoltDifferences(@"Data\simple.dat");
            Assert.AreEqual(5 * 7, result);

            var result1 = Tools.GetOneJoltMultipliedByThreeJoltDifferences(@"Data\simple1.dat");
            Assert.AreEqual(22 * 10, result1);

            Assert.AreEqual(8, Tools.GetNumberOfAllPossibleCombinations(@"Data\simple.dat"));

            Assert.AreEqual(19208, Tools.GetNumberOfAllPossibleCombinations(@"Data\simple1.dat"));
        }
    }
}