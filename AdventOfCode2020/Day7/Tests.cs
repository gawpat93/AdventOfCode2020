using NUnit.Framework;
namespace Day7
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
            var result = Tools.GetNumberOfBagsAbleToContainMyBag(@"Data\simple.dat");
            Assert.AreEqual(4, result);
        }
    }
}