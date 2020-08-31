using System;
using System.Collections.Generic;
using SolutionCS.Utility;
using Xunit;

namespace SolutionTestsCS.UtilityTests
{
    public class ArrayExtensionsTests
    {
        [Fact]
        public void Sum_Array_ReturnsSum()
        {
            var a = new int[] {1, 2, 3, 4};
            var result = a.Product();
            Assert.Equal(24, result);
        }

        [Fact]
        public void ExtractDiagonals_SquareTwoDimensionalArray_ThrowsArgumentException()
        {
            var matrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            Action result = () => matrix.ExtractDiagonals();

            var ex = Record.Exception(result);
            
            Assert.NotNull(ex);
            Assert.Equal("The two-dimensional array must be square. The array has 2 row(s) and 3 column(s).", ex.Message);
            Assert.IsType<ArgumentException>(ex);
            //Assert.Throws<ArgumentException>(result);
        }

        [Fact]
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
            
            Assert.Equal(value, result);
        }

        [Fact]
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
            Assert.Equal(value, result);
        }
        
        [Fact]
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
            Assert.Equal(value, result);
        }
    }
}
