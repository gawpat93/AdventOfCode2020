using NUnit.Framework;

namespace Day4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result1 = Tools.ValidPassports(@"Data\input.dat");
            Assert.AreEqual(250, result1);
        }

        [Test]
        public void SimpleTest()
        {
            var result1 = Tools.ValidPassports(@"Data\testData0.dat");
            Assert.AreEqual(2, result1);
        }
    }
}