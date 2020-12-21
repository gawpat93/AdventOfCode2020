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
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetNumberOfBagsAbleToContainMyBag(@"Data\simple.dat");
            Assert.AreEqual(4, result);
        }
    }
}