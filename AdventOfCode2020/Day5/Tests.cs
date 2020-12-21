using NUnit.Framework;
namespace Day5
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.GetHighestSeatIdFromFile(@"Data\input.dat");
            Assert.AreEqual(965,result);
            var result2 = Tools.FindMySeatId(@"Data\input.dat");
            Assert.AreEqual(524, result2);
        }

        [Test]
        public void SimpleTest()
        {
            var result0 = Tools.GetSeatId("FBFBBFFRLR");
            Assert.AreEqual(357, result0);

            Assert.AreEqual(567, Tools.GetSeatId("BFFFBBFRRR"));
            Assert.AreEqual(119, Tools.GetSeatId("FFFBBBFRRR"));
            Assert.AreEqual(820, Tools.GetSeatId("BBFFBBFRLL"));
        }
    }
}