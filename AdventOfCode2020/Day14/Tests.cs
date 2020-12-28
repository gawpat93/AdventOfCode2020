using NUnit.Framework;

namespace Day14
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            Assert.AreEqual(12512013221615, Tools.GetResultPart1(@"Data\input.dat"));
            Assert.AreEqual(3905642473893, Tools.GetResultPart2(@"Data\input.dat"));
        }

        [Test]
        public void SimpleTest()
        {
            Assert.AreEqual(165, Tools.GetResultPart1(@"Data\simple.dat"));
            Assert.AreEqual(208, Tools.GetResultPart2(@"Data\simple1.dat"));
        }
    }
}