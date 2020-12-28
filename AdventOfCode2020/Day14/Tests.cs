using NUnit.Framework;

namespace Day14
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            //Assert.AreEqual(0, Tools.GetResultPart1(@"Data\input.dat"));
        }

        [Test]
        public void SimpleTest()
        {
            Assert.AreEqual(165, Tools.GetResultPart1(@"Data\simple.dat"));
        }
    }
}