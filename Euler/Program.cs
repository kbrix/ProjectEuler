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
                    case 5: WriteSolution("Problem 5: 'Smallest multiple'.", Problem5.Solution); break;
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