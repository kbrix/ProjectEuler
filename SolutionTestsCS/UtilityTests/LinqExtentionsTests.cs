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
        public void CartesianProduct_BooleanEnumerablesOfLengthTwo_ReturnsCartesianProduct()
        {
            var enumerables = new List<List<int>>
            {
                new List<int> {0, 1},
                new List<int> {0, 1},
            };

            var expected = new List<List<int>>
            {
                new List<int> {0, 0},
                new List<int> {1, 0},
                new List<int> {0, 1},
                new List<int> {1, 1},
            };

            var cartesianProduct = LinqExtensions.CartesianProduct(enumerables);
            CollectionAssert.AreEquivalent(expected, cartesianProduct);
        }

        [Test]
        public void CartesianProduct_BooleanEnumerablesOfLengthThree_ReturnsCartesianProduct()
        {
            var enumerables = new List<List<int>>
            {
                new List<int> {0, 1},
                new List<int> {0, 1},
                new List<int> {0, 1},
            };

            var expected = new List<List<int>>
            {
                new List<int> {0, 0, 0},
                new List<int> {1, 0, 0},
                new List<int> {0, 1, 0},
                new List<int> {0, 0, 1},
                new List<int> {1, 1, 0},
                new List<int> {1, 0, 1},
                new List<int> {0, 1, 1},
                new List<int> {1, 1, 1},
            };

            var cartesianProduct = LinqExtensions.CartesianProduct(enumerables);
            CollectionAssert.AreEquivalent(expected, cartesianProduct);
        }

        [Test]
        public void CartesianProduct_BooleanEnumerablesOfLengthThree1_ReturnsCartesianProduct()
        {
            var enumerables = new List<List<bool>>
            {
                new List<bool> {false, true},
                new List<bool> {false, true},
                new List<bool> {false, true},
            };

            var expected = new List<List<bool>>
            {
                new List<bool> {false, false, false},
                new List<bool> {true,  false, false},
                new List<bool> {false, true,  false},
                new List<bool> {false, false, true},
                new List<bool> {true,  true,  false},
                new List<bool> {true,  false, true},
                new List<bool> {false, true,  true},
                new List<bool> {true,  true,  true},
            };

            var cartesianProduct = LinqExtensions.CartesianProduct(enumerables);
            CollectionAssert.AreEquivalent(expected, cartesianProduct);
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

        [Test]
        public void Window_WindowLengthTooSmall_ThrowsException()
        {
            var n = new[] { 1, 2, 3, 4 };
            TestDelegate action = () => n.Window(0);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.AreEqual("Window length must be a natural number. (Parameter 'n')", ex.Message);
        }

        [Test]
        public void Window_WindowLengthTooBig_ThrowsException()
        {
            var n = new[] {1, 2, 3, 4};
            TestDelegate action = () => n.Window(5);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.AreEqual("Window length is larger than array. (Parameter 'n')", ex.Message);
        }

        [Test]
        public void Window_ArrayOfNumbers_ReturnsCollectionOfArrays()
        {
            var n = new[] {1, 2, 3, 4};
            var actualResult = n.Window(2);
            var expectedResult = new List<int[]> { new[] { 1, 2 }, new []{2, 3}, new []{3, 4} };
            Assert.AreEqual(3, actualResult.Count);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}