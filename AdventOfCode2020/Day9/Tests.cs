using NUnit.Framework;
namespace Day9
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.GetNotSumNumberAfterPreamble(@"Data\input.dat", 25);
            Assert.AreEqual(375054920, result);

            var result1 = Tools.GetSumMinMAxOfContiguousSetOfAtLeastTwoNumbersThatSumToWeaknessNumber(@"Data\input.dat", 25);
            Assert.AreEqual(54142584, result1);
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetNotSumNumberAfterPreamble(@"Data\simple.dat", 5);
            Assert.AreEqual(127, result);

            var result1 = Tools.GetSumMinMAxOfContiguousSetOfAtLeastTwoNumbersThatSumToWeaknessNumber(@"Data\simple.dat", 5);
            Assert.AreEqual(62, result1);
        }
    }
}