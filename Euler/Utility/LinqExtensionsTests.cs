using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace euler.Utility
{
    public class LinqExtensionsTests
    {
        [Fact]
        public void GetPermutations_ListOfIntegers_ReturnsListOfPermutations()
        {
            var set = new List<int> {1, 2, 3};
            
            var result = new List<List<int>>()
            {
                new List<int>() {1, 2, 3},
                new List<int>() {1, 3, 2},
                new List<int>() {2, 1, 3},
                new List<int>() {2, 3, 1},
                new List<int>() {3, 1, 2},
                new List<int>() {3, 2, 1},
            };

            var permutations = LinqExtensions.GetPermutations(set, 3);
            
            Assert.Equal(6, permutations.Count());
            Assert.Equal(result, permutations);
        }
        
        [Fact]
        public void GetPermutations_ListOfStrings_ReturnsListOfPermutations()
        {
            var set = new List<string> {"0", "1", "2"};
            
            var result = new List<List<string>>()
            {
                new List<string>() {"0", "1", "2"},
                new List<string>() {"0", "2", "1"},
                new List<string>() {"1", "0", "2"},
                new List<string>() {"1", "2", "0"},
                new List<string>() {"2", "0", "1"},
                new List<string>() {"2", "1", "0"},
            };

            var permutations = LinqExtensions.GetPermutations(set, 3);
            
            Assert.Equal(6, permutations.Count());
            Assert.Equal(result, permutations);
        }
    }
}