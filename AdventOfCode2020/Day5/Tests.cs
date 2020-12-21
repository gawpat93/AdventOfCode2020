using NUnit.Framework;
namespace Day5
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
        }

        [Test]
        public void SimpleTest()
        {
            var result0 = Tools.GetSeatId("FBFBBFFRLR");
            Assert.AreEqual(357, result0);
        }
    }
}