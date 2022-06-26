using System;
using System.Collections.Generic;
using SolutionCS.Utility;
using NUnit.Framework;

namespace SolutionTestsCS.Utility
{
    public class ArrayExtensionsTests
    {
        [Test]
        public void Sum_Array_ReturnsSum()
        {
            var a = new int[] {1, 2, 3, 4};
            var result = a.Product();
            Assert.AreEqual(24, result);
        }

        [Test]
        public void ExtractDiagonals_SquareTwoDimensionalArray_ThrowsArgumentException()
        {
            var matrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            TestDelegate result = () => matrix.ExtractDiagonals();

            var ex = Assert.Throws<ArgumentException>(result);
            
            Assert.NotNull(ex);
            Assert.AreEqual("The two-dimensional array must be square. The array has 2 row(s) and 3 column(s).", ex.Message);
        }

        [Test]
        public void ExtractDiagonals_SquareTwoDimensionalArray_ReturnsListOfDiagonals()
        {
            var matrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
            };
            
            var value = new List<List<int>>
            {
                new List<int>{ 1, 5, 9 },
                new List<int>{ 2, 6 },
                new List<int>{ 4, 8 },
                new List<int>{ 3 },
                new List<int>{ 7 },
            };

            var result = matrix.ExtractDiagonals();
            
            Assert.AreEqual(value, result);
        }

        [Test]
        public void Transpose_SquareTwoDimensionalArray_TransposedArray()
        {
            var matrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
            };
            
            var value = new int[,]
            {
                {1, 4, 7},
                {2, 5, 8},
                {3, 6, 9},
            };

            var result = matrix.Transpose();
            Assert.AreEqual(value, result);
        }
        
        [Test]
        public void Reverse_SquareTwoDimensionalArray_ReturnsReversedArray()
        {
            var matrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
            };
            
            var value = new int[,]
            {
                {3, 2, 1},
                {6, 5, 4},
                {9, 8, 7},
            };

            var result = matrix.Reverse();
            Assert.AreEqual(value, result);
        }
    }
}
