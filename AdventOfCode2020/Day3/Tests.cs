using NUnit.Framework;

namespace Day3
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result0 = Tools.CountEncounteredTrees(@"Data\input.dat",1,1);
            var result1 = Tools.CountEncounteredTrees(@"Data\input.dat");
            Assert.AreEqual(171, result1);
            var result2 = Tools.CountEncounteredTrees(@"Data\input.dat", 5, 1);
            var result3 = Tools.CountEncounteredTrees(@"Data\input.dat", 7, 1);
            var result4 = Tools.CountEncounteredTrees(@"Data\input.dat", 1, 2);
            Assert.AreEqual(1206576000, result0 * result1 * result2 * result3 * result4);
        }

        [Test]
        public void SimpleTest()
        {
            var result0 = Tools.CountEncounteredTrees(@"Data\testData0.dat", 1, 1);
            Assert.AreEqual(2, result0);
            var result1 = Tools.CountEncounteredTrees(@"Data\testData0.dat");
            Assert.AreEqual(7, result1);
            var result2 = Tools.CountEncounteredTrees(@"Data\testData0.dat", 5, 1);
            Assert.AreEqual(3, result2);
            var result3 = Tools.CountEncounteredTrees(@"Data\testData0.dat", 7, 1);
            Assert.AreEqual(4, result3);
            var result4 = Tools.CountEncounteredTrees(@"Data\testData0.dat", 1, 2);
            Assert.AreEqual(2, result4);
            Assert.AreEqual(336, result0 * result1 * result2 * result3 * result4);

        }
    }
}