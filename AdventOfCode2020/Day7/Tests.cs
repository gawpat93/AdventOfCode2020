using NUnit.Framework;
namespace Day7
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.GetNumberOfBagsAbleToContainMyBag(@"Data\input.dat");
            Assert.AreEqual(316, result);

            var result1 = Tools.GetNumberOfBagsContainableInMyBag(@"Data\input.dat");
            Assert.AreEqual(11310, result1);
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetNumberOfBagsAbleToContainMyBag(@"Data\simple.dat");
            Assert.AreEqual(4, result);

            var result1 = Tools.GetNumberOfBagsContainableInMyBag(@"Data\simple.dat");
            Assert.AreEqual(32, result1);

            var result2 = Tools.GetNumberOfBagsContainableInMyBag(@"Data\simple1.dat");
            Assert.AreEqual(126, result2);
        }
    }
}