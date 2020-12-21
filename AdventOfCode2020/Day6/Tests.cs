using NUnit.Framework;
namespace Day6
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.QuestionsAnsweredYes(@"Data\input.dat");
            Assert.AreEqual(6443, result);

            var result1 = Tools.QuestionsAnsweredYesByAllPersonsInSameGroup(@"Data\input.dat");
            Assert.AreEqual(3232, result1);
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.QuestionsAnsweredYes(@"Data\simple.dat");
            Assert.AreEqual(11, result);
            var result1 = Tools.QuestionsAnsweredYesByAllPersonsInSameGroup(@"Data\simple.dat");
            Assert.AreEqual(6, result1);
        }
    }
}