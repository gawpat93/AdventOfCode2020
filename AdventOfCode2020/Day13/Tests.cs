using NUnit.Framework;

namespace Day13
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.GetResultPart1(@"Data\input.dat");
            Assert.AreEqual(3789, result);

            //var result2 = Tools.GetResultPart2(@"Data\input.dat");
            //Assert.AreEqual(0, result2);
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetResultPart1(@"Data\simple.dat");
            Assert.AreEqual(295, result);
            
            Assert.AreEqual(1068781, Tools.GetResultPart2(@"Data\simple.dat"));
            Assert.AreEqual(3417, Tools.GetResultPart2(@"Data\simple1.dat"));
            Assert.AreEqual(754018, Tools.GetResultPart2(@"Data\simple2.dat"));
            Assert.AreEqual(779210, Tools.GetResultPart2(@"Data\simple3.dat"));
            Assert.AreEqual(1261476, Tools.GetResultPart2(@"Data\simple4.dat"));
            Assert.AreEqual(1202161486, Tools.GetResultPart2(@"Data\simple5.dat"));
        }
    }
}