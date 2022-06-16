using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem61Tests
    {
        [Test]
        public void Example()
        {
            var numbers = SolutionCS.Problem61.Example().ToHashSet();
            CollectionAssert.Contains(numbers, (8128, 2882, 8281));
            Assert.AreEqual(1, numbers.Count);
        }

        [Test]
        public void Solution()
        {
            var solution = SolutionCS.Problem61.Solution();
            Assert.AreEqual(28684, solution);
        }
    }
}
