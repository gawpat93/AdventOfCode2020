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
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetNotSumNumberAfterPreamble(@"Data\simple.dat", 5);
            Assert.AreEqual(127, result);
        }
    }
}