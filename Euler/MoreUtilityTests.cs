using System;
using System.Linq;
using Xunit;

namespace euler
{
    public class MoreUtilityTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(64, 2)]
        [InlineData(729, 3)]
        [InlineData(1296, 4)]
        [InlineData(4096, 5)]
        [InlineData(10000, 6)]
        [InlineData(15625, 7)]
        [InlineData(38416, 8)]
        [InlineData(46656, 9)]
        [InlineData(50625, 10)]
        [InlineData(82944, 11)]
        [InlineData(117649, 12)]
        [InlineData(194481, 13)]
        [InlineData(234256, 14)]
        [InlineData(262144, 15)]
        [InlineData(456976, 16)]
        [InlineData(531441, 17)]
        [InlineData(640000, 18)]
        [InlineData(944784, 19)]
        [InlineData(1000000, 20)]
        [InlineData(1185921, 21)]
        [InlineData(1336336, 22)]
        [InlineData(1500625, 23)]
        [InlineData(1771561, 24)]
        [InlineData(2085136, 25)]
        [InlineData(2313441, 26)]
        [InlineData(2458624, 27)]
        [InlineData(2985984, 28)]
        [InlineData(3240000, 29)]
        [InlineData(4477456, 30)]
        [InlineData(4826809, 31)]
        [InlineData(5308416, 32)]
        [InlineData(6765201, 33)]
        [InlineData(7290000, 34)]
        [InlineData(7529536, 35)]
        [InlineData(9150625, 36)]
        [InlineData(10556001, 37)]
        [InlineData(11316496, 38)]
        [InlineData(11390625, 39)]
        [InlineData(12446784, 40)]
        [InlineData(14776336, 41)]
        [InlineData(14992384, 42)]
        [InlineData(16777216, 43)]
        [InlineData(17850625, 44)]
        [InlineData(20250000, 45)]
        [InlineData(22667121, 46)]
        [InlineData(24137569, 47)]
        [InlineData(28005264, 48)]
        [InlineData(29246464, 49)]
        [InlineData(29986576, 50)]
        [InlineData(34012224, 51)]
        [InlineData(35153041, 52)]
        [InlineData(36905625, 53)]
        [InlineData(40960000, 54)]
        [InlineData(45212176, 55)]
        [InlineData(47045881, 56)]
        [InlineData(52200625, 57)]
        [InlineData(54700816, 58)]
        [InlineData(57289761, 59)]
        [InlineData(60466176, 60)]
        [InlineData(64000000, 61)]
        [InlineData(68574961, 62)]
        [InlineData(74805201, 63)]
        [InlineData(75898944, 64)]
        [InlineData(78074896, 65)]
        [InlineData(81450625, 66)]
        [InlineData(85525504, 67)]
        [InlineData(85766121, 68)]
        [InlineData(96040000, 69)]
        public void ttt(int n, int x)
        {
            var result = MoreUtility.Mp(n);
            Assert.Equal(x, result);
        }

        [Theory]
        [InlineData(120996588, 0)] // 5 sec
        //[InlineData(159054145, 0)]
        //[InlineData(222284926, -1)]
        //[InlineData(342230032, 0)] // 13 sec
        //[InlineData(628716714, -1)] // 26 sec 
        //[InlineData(1778279410, -1)]  // 1 min 20 sec
        public void k(int n, int x)
        {
            var result = MoreUtility.MobiusSieve(n);
            Assert.Equal(x, result.Last());
        }

        [Fact] // 55 sec
        public void s()
        {
            var result = MoreUtility.MpBIG();
            Assert.Equal(793525366, result);
        }
    }
}