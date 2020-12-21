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
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.QuestionsAnsweredYes(@"Data\simple.dat");
            Assert.AreEqual(11, result);
        }
    }
}