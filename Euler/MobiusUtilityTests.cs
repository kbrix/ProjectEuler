using System.Linq;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace euler
{
    public class MoreUtilityTests
    {
        [Fact]
        public void MobiusSieve_SmallNumberOfDice_ReturnsArrayOfValues()
        {
            var result = MobiusUtility.MobiusSieve(75); // 0:75 (\mu(0):=0)
            var value = new int[]
            {
                0, 1, -1, -1, 0, -1, 1, -1, 0, 0, 1, -1, 0, -1, 1, 1, 0, -1, 0, -1, 0, 1, 1, -1, 0, 0, 1, 0, 0, -1, -1,
                -1, 0, 1, 1, 1, 0, -1, 1, 1, 0, -1, -1, -1, 0, 0, 1, -1, 0, 0, 0, 1, 0, -1, 0, 1, 0, 1, 1, -1, 0, -1, 1,
                0, 0, 1, -1, -1, 0, 1, -1, -1, 0, -1, 1, 0
            };
            CollectionAssert.AreEqual(value, result);
        }
        
        [Fact] // 42 sec
        public void MobiusSieve_VeryLargeNumberOfDice_ReturnsLastValueInArray()
        {
            var result = MobiusUtility.MobiusSieve((int)1e9);
            Assert.Equal(0, result.Last());
        }
    }
}