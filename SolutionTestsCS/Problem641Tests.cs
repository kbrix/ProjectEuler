using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem641Tests
    {
        [TestCase(1, 1)]
        [TestCase(64, 2)]
        [TestCase(729, 3)]
        [TestCase(1296, 4)]
        [TestCase(4096, 5)]
        [TestCase(10000, 6)]
        [TestCase(15625, 7)]
        [TestCase(38416, 8)]
        [TestCase(46656, 9)]
        [TestCase(50625, 10)]
        [TestCase(82944, 11)]
        [TestCase(117649, 12)]
        [TestCase(194481, 13)]
        [TestCase(234256, 14)]
        [TestCase(262144, 15)]
        [TestCase(456976, 16)]
        [TestCase(531441, 17)]
        [TestCase(640000, 18)]
        [TestCase(944784, 19)]
        [TestCase(1000000, 20)]
        [TestCase(1185921, 21)]
        [TestCase(1336336, 22)]
        [TestCase(1500625, 23)]
        [TestCase(1771561, 24)]
        [TestCase(2085136, 25)]
        [TestCase(2313441, 26)]
        [TestCase(2458624, 27)]
        [TestCase(2985984, 28)]
        [TestCase(3240000, 29)]
        [TestCase(4477456, 30)]
        [TestCase(4826809, 31)]
        [TestCase(5308416, 32)]
        [TestCase(6765201, 33)]
        [TestCase(7290000, 34)]
        [TestCase(7529536, 35)]
        [TestCase(9150625, 36)]
        [TestCase(10556001, 37)]
        [TestCase(11316496, 38)]
        [TestCase(11390625, 39)]
        [TestCase(12446784, 40)]
        [TestCase(14776336, 41)]
        [TestCase(14992384, 42)]
        [TestCase(16777216, 43)]
        [TestCase(17850625, 44)]
        [TestCase(20250000, 45)]
        [TestCase(22667121, 46)]
        [TestCase(24137569, 47)]
        [TestCase(28005264, 48)]
        [TestCase(29246464, 49)]
        [TestCase(29986576, 50)]
        [TestCase(34012224, 51)]
        [TestCase(35153041, 52)]
        [TestCase(36905625, 53)]
        [TestCase(40960000, 54)]
        [TestCase(45212176, 55)]
        [TestCase(47045881, 56)]
        [TestCase(52200625, 57)]
        [TestCase(54700816, 58)]
        [TestCase(57289761, 59)]
        [TestCase(60466176, 60)]
        [TestCase(64000000, 61)]
        [TestCase(68574961, 62)]
        [TestCase(74805201, 63)]
        [TestCase(75898944, 64)]
        [TestCase(78074896, 65)]
        [TestCase(81450625, 66)]
        [TestCase(85525504, 67)]
        [TestCase(85766121, 68)]
        [TestCase(96040000, 69)]
        public void SolutionForArbitraryNumberOfDice_SmallNumberOfDice_ReturnsResult(int n, int x)
        {
            var result = Problem641.SolutionForArbitraryNumberOfDice(n);
            Assert.AreEqual(x, result);
        }

        [Test] // 55 sec
        public void Solution_SolutionForProblem641_ReturnsResult()
        {
            var result = Problem641.Solution();
            Assert.AreEqual(793525366, result);
        }
    }
}