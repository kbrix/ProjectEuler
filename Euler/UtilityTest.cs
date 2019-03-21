using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using euler;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace UtilityTests
{
    public class UnitTest1
    {
        [Xunit.Theory]
        [InlineData(1, 1)]
        [InlineData(2, -1)]
        [InlineData(3, -1)]
        [InlineData(4, 0)]
        [InlineData(5, -1)]
        [InlineData(6, 1)]
        [InlineData(7, -1)]
        [InlineData(8, 0)]
        [InlineData(9, 0)]
        [InlineData(10, 1)]
        [InlineData(11, -1)]
        [InlineData(12, 0)]
        [InlineData(13, -1)]
        [InlineData(14, 1)]
        [InlineData(15, 1)]
        [InlineData(16, 0)]
        [InlineData(17, -1)]
        [InlineData(18, 0)]
        [InlineData(19, -1)]
        [InlineData(20, 0)]
        [InlineData(21, 1)]
        [InlineData(22, 1)]
        [InlineData(23, -1)]
        [InlineData(24, 0)]
        [InlineData(25, 0)]
        [InlineData(26, 1)]
        [InlineData(27, 0)]
        [InlineData(28, 0)]
        [InlineData(29, -1)]
        [InlineData(30, -1)]
        [InlineData(31, -1)]
        [InlineData(32, 0)]
        [InlineData(33, 1)]
        [InlineData(34, 1)]
        [InlineData(35, 1)]
        [InlineData(36, 0)]
        [InlineData(37, -1)]
        [InlineData(38, 1)]
        [InlineData(39, 1)]
        [InlineData(40, 0)]
        [InlineData(41, -1)]
        [InlineData(42, -1)]
        [InlineData(43, -1)]
        [InlineData(44, 0)]
        [InlineData(45, 0)]
        [InlineData(46, 1)]
        [InlineData(47, -1)]
        [InlineData(48, 0)]
        [InlineData(49, 0)]
        [InlineData(50, 0)]
        [InlineData(51, 1)]
        [InlineData(52, 0)]
        [InlineData(53, -1)]
        [InlineData(54, 0)]
        [InlineData(55, 1)]
        [InlineData(56, 0)]
        [InlineData(57, 1)]
        [InlineData(58, 1)]
        [InlineData(59, -1)]
        [InlineData(60, 0)]
        [InlineData(61, -1)]
        [InlineData(62, 1)]
        [InlineData(63, 0)]
        [InlineData(64, 0)]
        [InlineData(65, 1)]
        [InlineData(66, -1)]
        [InlineData(67, -1)]
        [InlineData(68, 0)]
        [InlineData(69, 1)]
        [InlineData(70, -1)]
        [InlineData(71, -1)]
        [InlineData(72, 0)]
        [InlineData(73, -1)]
        [InlineData(74, 1)]
        [InlineData(75, 0)]
        public void MobiusFunction_Integers_ReturnsValue(int n, int value)
        {
            var result = Utility.Mobius(n);
            Assert.Equal(value, result);
        }
        
        [Xunit.Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 2)]
        [InlineData(7, 2)]
        [InlineData(8, 2)]
        [InlineData(9, 2)]
        [InlineData(10, 3)]
        [InlineData(11, 3)]
        [InlineData(12, 3)]
        [InlineData(13, 3)]
        [InlineData(14, 4)]
        [InlineData(15, 5)]
        [InlineData(16, 5)]
        [InlineData(17, 5)]
        [InlineData(18, 5)]
        [InlineData(19, 5)]
        [InlineData(20, 5)]
        [InlineData(21, 6)]
        [InlineData(22, 7)]
        [InlineData(23, 7)]
        [InlineData(24, 7)]
        [InlineData(25, 7)]
        [InlineData(26, 8)]
        [InlineData(27, 8)]
        [InlineData(28, 8)]
        [InlineData(29, 8)]
        [InlineData(30, 8)]
        [InlineData(31, 8)]
        [InlineData(32, 8)]
        [InlineData(33, 9)]
        [InlineData(34, 10)]
        [InlineData(35, 11)]
        [InlineData(36, 11)]
        [InlineData(37, 11)]
        [InlineData(38, 12)]
        [InlineData(39, 13)]
        [InlineData(40, 13)]
        [InlineData(41, 13)]
        [InlineData(42, 13)]
        [InlineData(43, 13)]
        [InlineData(44, 13)]
        [InlineData(45, 13)]
        [InlineData(46, 14)]
        [InlineData(47, 14)]
        [InlineData(48, 14)]
        [InlineData(49, 14)]
        [InlineData(50, 14)]
        [InlineData(51, 15)]
        [InlineData(52, 15)]
        [InlineData(53, 15)]
        [InlineData(54, 15)]
        [InlineData(55, 16)]
        [InlineData(56, 16)]
        [InlineData(57, 17)]
        [InlineData(58, 18)]
        [InlineData(59, 18)]
        [InlineData(60, 18)]
        [InlineData(61, 18)]
        [InlineData(62, 19)]
        [InlineData(63, 19)]
        [InlineData(64, 19)]
        [InlineData(65, 20)]
        [InlineData(66, 20)]
        [InlineData(67, 20)]
        [InlineData(68, 20)]
        [InlineData(69, 21)]
        [InlineData(70, 21)]
        [InlineData(71, 21)]
        [InlineData(72, 21)]
        [InlineData(73, 21)]
        [InlineData(74, 22)]
        [InlineData(75, 22)]
        public void Mplus_Integers_ReturnsValue(int n, int value)
        {
            var result = Utility.Mplus(n);
            Assert.Equal(value, result);
        }

        [Xunit.Theory]
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
        public void f_test(int n, int value)
        {
            var result = Utility.f(n);
            Assert.Equal(value, result);
        }
        
        [Fact]
        public void f_solution()
        {
            var result = Utility.fBIG();
            Assert.Equal(793525366, result);
        }

        [Fact]
        public void hmm()
        {
            var csv = new StringBuilder();
            
            for (int i = 1; i <= 10; i++)
            {
                var first = i.ToString();
                var second = Utility.Mobius(i).ToString();
                var newLine = $"{first};{second}";
                csv.AppendLine(newLine);

            }

            var filePath = @"/home/brix/Documents/m.csv";
            File.WriteAllText(filePath, csv.ToString());
            
            var result = Utility.Mobius(1778279410);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void TestMo()
        {
            var result = MoreUtility.MobiusSieve(75); // 0:75 (\mu(0):=0)
            var value = new int[]
            {
                0, 1, -1, -1, 0, -1, 1, -1, 0, 0, 1, -1, 0, -1, 1, 1, 0, -1, 0, -1, 0, 1, 1, -1, 0, 0, 1, 0, 0, -1, -1, -1,
                0, 1, 1, 1, 0, -1, 1, 1, 0, -1, -1, -1, 0, 0, 1, -1, 0, 0, 0, 1, 0, -1, 0, 1, 0, 1, 1, -1, 0, -1, 1, 0,
                0, 1, -1, -1, 0, 1, -1, -1, 0, -1, 1, 0
            };
            CollectionAssert.AreEqual(value, result);
        }
    }
}