using System;
using System.Diagnostics;

namespace euler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Kristoffer's solutions!");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Select a number, then press ENTER.");
                var input = Console.ReadLine();
                int number;
                try
                {
                    number = int.Parse(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"You typed: '{input}', which cannot be parsed into an integer.");
                    Console.WriteLine($"The exception message is: '{e.Message}'");
                    continue;
                }

                if (number < 1)
                {
                    Console.WriteLine("Please stop trolling my program.");
                    continue;
                }

                switch (number)
                {
                    case 1: WriteSolution("Problem 1: 'Multiples of 3 and 5'.", () => Problem1.Solution(1000)); break;
                    case 2: WriteSolution("Problem 2: 'Even Fibonacci numbers'.", Problem2.Solution); break;
                    case 3: WriteSolution("Problem 3: 'Largest prime factor'.", Problem3.Solution); break;
                    case 4: WriteSolution("Problem 4: 'Largest palindrome product'.", Problem4.Solution); break;
                    case 5: WriteSolution("Problem 5: 'Smallest multiple'.", Problem5.Solution); break; //slow
                    case 6: WriteSolution("Problem 6: 'Sum square difference'.", Problem6.Solution); break;
                    case 7: WriteSolution("Problem 7: '10001st prime'.", Problem7.Solution); break;
                    case 8: WriteSolution("Problem 8: 'Largest product in a series'.", Problem8.Solution); break;
                    case 9: WriteSolution("Problem 9: 'Special Pythagorean triplet'.", Problem9.Solution); break;
                    
                    case 10: WriteSolution("Problem 10: 'Summation of primes'.", Problem10.Solution); break;
                    case 11: WriteSolution("Problem 11: 'Largest product in a grid'.", Problem11.Solution); break;
                    case 12: WriteSolution("Problem 12: 'Highly divisible triangular number'.", Problem12.Solution); break; //slowish
                    case 13: WriteSolution("Problem 13: 'Large sum'.", Problem13.Solution); break;
                    case 14: WriteSolution("Problem 14: 'Longest Collatz sequence'.", Problem14.Solution); break; //slow
                    case 15: WriteSolution("Problem 15: 'Lattice paths'.", Problem15.Solution); break;
                    case 16: WriteSolution("Problem 16: 'Power digit sum'.", () => Problem16.GeneralizedSolution(1000)); break;
                    case 17: Console.WriteLine("Problem 17: 'Number letter counts'."); Console.WriteLine("Answer: '21124' (solved with pen & paper)."); break;
                    case 18: WriteSolution("Problem 18: 'Maximum path sum I'.", () => Problem18.GeneralizedSolution(Problem18.TriangleData)); break;
                    case 19: WriteSolution("Problem 19: 'Counting Sundays'.", Problem19.Solution); break;
                    
                    case 20: WriteSolution("Problem 20: 'Factorial digit sum'.", Problem20.Solution); break;
                    case 21: WriteSolution("Problem 21: 'Amicable numbers'.", Problem21.Solution); break;
                    case 22: WriteSolution("Problem 22: 'Names scores'.", Problem22.Solution); break;
                    case 23: WriteSolution("Problem 23: 'Non-abundant sums'.", Problem23.Solution); break;
                    case 24: WriteSolution("Problem 24: 'Lexicographic permutations'.", Problem24.Solution); break;
                    case 25: WriteSolution("Problem 25: '1000-digit Fibonacci number'.", Problem25.Solution); break;
                    case 26: WriteSolution("Problem 26: 'Reciprocal cycles'.", () => Problem26.Solution(1000)); break;
                    case 27: WriteSolution("Problem 27: 'Quadratic primes'.", Problem27.Solution); break;
                    case 28: WriteSolution("Problem 28: 'Number spiral diagonals'.", Problem28.Solution); break;
                    case 29: WriteSolution("Problem 29: 'Distinct powers'.", Problem29.Solution); break;
                    
                    case 30: WriteSolution("Problem 30: 'Digit fifth powers'.", () => Problem30.Solution(5)); break;
                    case 31: WriteSolution("Problem 31: 'Coin sums'.", () => Problem31.Solution(200)); break;
                    case 32: WriteSolution("Problem 32: 'Pandigital products'.", Problem32.Solution); break;
                    case 33: WriteSolution("Problem 33: 'Digit cancelling fractions'.", Problem33.Solution); break;
                    case 34: WriteSolution("Problem 34: 'Digit factorials'.", Problem34.Solution); break;
                    case 35: WriteSolution("Problem 35: 'Circular primes'.", Problem35.Solution); break;
                    case 36: WriteSolution("Problem 36: 'Double-base palindromes'.", Problem36.Solution); break;
                    case 37: WriteSolution("Problem 37: 'Truncatable primes'.", Problem37.Solution); break;
                    case 38: WriteSolution("Problem 38: 'Pandigital multiples'.", Problem38.Solution); break;
                    case 39: WriteSolution("Problem 39: 'Integer right triangles'.", Problem39.Solution); break;
                    
                    case 40: WriteSolution("Problem 40: 'Champernowne's constant'.", Problem40.Solution); break;
                    
                    case 67: WriteSolution("Problem 67: 'Maximum path sum II'.", () => Problem18.GeneralizedSolution(Problem67_Tests.TriangleData)); break;

                    case 641: WriteSolution("Problem 641: 'A Long Row of Dice'.", Problem641.Solution); break;
                    
                    default: Console.WriteLine("Problem not currently solved."); break;
                }
            }
        }
        
        private static void WriteSolution<T>(string text, Func<T> solution)
        {
            Console.WriteLine(text);
            var stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Answer: '{solution.Invoke()}'.");
            Console.WriteLine($"Computation time (in mm.ss.ffff): {stopwatch.Elapsed:mm\\:ss\\.ffff}.");
        }
    }
}