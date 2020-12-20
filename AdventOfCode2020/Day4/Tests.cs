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
            var result2 = Tools.ValidPassports(@"Data\input.dat", true);
            Assert.AreEqual(158, result2);
        }

        [Test]
        public void SimpleTest()
        {
            var result1 = Tools.ValidPassports(@"Data\testData0.dat");
            Assert.AreEqual(2, result1);

            var result2 = Tools.ValidPassports(@"Data\invalidPassports.dat", true);
            Assert.AreEqual(0, result2);
            var result3 = Tools.ValidPassports(@"Data\validPassports.dat", true);
            Assert.AreEqual(4, result3);
        }
    }
}