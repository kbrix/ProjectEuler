using System;
using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;
using NUnit.Framework;

namespace SolutionTestsCS.UtilityTests
{
    public class LinqExtensionsTests
    {
        [Test]
        public void GetPermutationsWithRepetition_ListOfIntegers_ReturnsListOfPermutationsWithRepetition()
        {
            var set = new List<int> {1, 2, 3};

            var result = new List<List<int>>()
            {
                new List<int>() { 1, 1, 1 },
                new List<int>() { 1, 1, 2 },
                new List<int>() { 1, 1, 3 },
                new List<int>() { 1, 2, 1 },
                new List<int>() { 1, 2, 2 },
                new List<int>() { 1, 2, 3 },
                new List<int>() { 1, 3, 1 },
                new List<int>() { 1, 3, 2 },
                new List<int>() { 1, 3, 3 },
                new List<int>() { 2, 1, 1 },
                new List<int>() { 2, 1, 2 },
                new List<int>() { 2, 1, 3 },
                new List<int>() { 2, 2, 1 },
                new List<int>() { 2, 2, 2 },
                new List<int>() { 2, 2, 3 },
                new List<int>() { 2, 3, 1 },
                new List<int>() { 2, 3, 2 },
                new List<int>() { 2, 3, 3 },
                new List<int>() { 3, 1, 1 },
                new List<int>() { 3, 1, 2 },
                new List<int>() { 3, 1, 3 },
                new List<int>() { 3, 2, 1 },
                new List<int>() { 3, 2, 2 },
                new List<int>() { 3, 2, 3 },
                new List<int>() { 3, 3, 1 },
                new List<int>() { 3, 3, 2 },
                new List<int>() { 3, 3, 3 },
            };

            var permutationsWithRepetition = LinqExtensions.GetPermutationsWithRepetition(set, 3);
            Assert.AreEqual(Math.Pow(3, 3), permutationsWithRepetition.Count());
            Assert.AreEqual(result, permutationsWithRepetition);
        }

        [Test]
        public void GetPermutationsWithRepetition_ListOfStrings_ReturnsListOfPermutationsWithRepetition()
        {
            var set = new List<string> { "1", "2", "3" };

            var result = new List<List<string>>()
            {
                new List<string>() { "1", "1", "1" },
                new List<string>() { "1", "1", "2" },
                new List<string>() { "1", "1", "3" },
                new List<string>() { "1", "2", "1" },
                new List<string>() { "1", "2", "2" },
                new List<string>() { "1", "2", "3" },
                new List<string>() { "1", "3", "1" },
                new List<string>() { "1", "3", "2" },
                new List<string>() { "1", "3", "3" },
                new List<string>() { "2", "1", "1" },
                new List<string>() { "2", "1", "2" },
                new List<string>() { "2", "1", "3" },
                new List<string>() { "2", "2", "1" },
                new List<string>() { "2", "2", "2" },
                new List<string>() { "2", "2", "3" },
                new List<string>() { "2", "3", "1" },
                new List<string>() { "2", "3", "2" },
                new List<string>() { "2", "3", "3" },
                new List<string>() { "3", "1", "1" },
                new List<string>() { "3", "1", "2" },
                new List<string>() { "3", "1", "3" },
                new List<string>() { "3", "2", "1" },
                new List<string>() { "3", "2", "2" },
                new List<string>() { "3", "2", "3" },
                new List<string>() { "3", "3", "1" },
                new List<string>() { "3", "3", "2" },
                new List<string>() { "3", "3", "3" },
            };

            var permutationsWithRepetition = LinqExtensions.GetPermutationsWithRepetition(set, 3);
            Assert.AreEqual(Math.Pow(3, 3), permutationsWithRepetition.Count());
            Assert.AreEqual(result, permutationsWithRepetition);
        }

        [Test]
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
            
            Assert.AreEqual(6, permutations.Count());
            Assert.AreEqual(result, permutations);
        }
        
        [Test]
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
            
            Assert.AreEqual(6, permutations.Count());
            Assert.AreEqual(result, permutations);
        }

        [Test]
        public void Rotate_ListOfNumbers_ReturnsRotatesList()
        {
            var arr = new[] { 1, 2, 3, 4, 5 };
            
            var result1 = arr.Rotate().ToArray();
            Assert.AreEqual(new[] {2, 3, 4, 5, 1}, result1);

            var result2 = arr.Rotate(3).ToArray();
            Assert.AreEqual(new[] { 4, 5, 1, 2, 3 }, result2);
        }

        [TestCase(new[] { 1, 2, 3 }, 123)]
        [TestCase(new[] { 1, 0, 1 }, 101)]
        [TestCase(new[] { 0, 0, 1 }, 001)]
        [TestCase(new[] { 6, 9, 0 }, 690)]
        public void ConcatenateDigits_ListOfDigits_ReturnsNumber(int[] digits, int result)
        {
            Assert.AreEqual(result, digits.ConcatenateDigits());
        }
    }
}