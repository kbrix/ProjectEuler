using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    public class Problem64Tests
    {
        [Test]
        public void GetSolution()
        {
            Assert.AreEqual(1322, Problem64.Solution());
        }
    }
}
