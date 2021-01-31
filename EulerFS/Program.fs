open System

let solutionPrinter text solution = 
    printfn text
    let stopwatch = System.Diagnostics.Stopwatch.StartNew();
    let result = solution()
    printfn "Answer: %A" result
    let time = stopwatch.Elapsed.ToString("mm\\:ss\\.ffff")
    printfn "Computation time (in mm.ss.ffff): %s." time

[<EntryPoint>]
let main argv =
    printfn "Welcome to Kristoffer's solutions!"
    
    while true do
        Console.WriteLine("")
        Console.WriteLine("Select a number, then press ENTER.");            
        
        let program() =
            let input = Console.ReadLine()
            let formatExceptionMessage input message =
                printfn "You typed '%s', which cannot be parsed into an integer." input
                printfn "The exception message is: '%s'" message

            let number =
                try
                    Some(input |> int32)
                with
                    | :? System.FormatException as ex -> formatExceptionMessage input ex.Message; None
            
            if number < Some(1) then
                printfn "Please stop trolling my program."
            else
                match number with
                | None     -> printfn ""
                | Some(1)  -> solutionPrinter "Problem 1: 'Multiples of 3 and 5'." Solution.Problem1.solution
                | Some(2)  -> solutionPrinter "Problem 2: 'Even Fibonacci numbers'." Solution.Problem2.solution
                | Some(3)  -> solutionPrinter "Problem 3: 'Largest prime factor'." Solution.Problem3.solution
                | Some(4)  -> solutionPrinter "Problem 4: 'Largest palindrome product'." Solution.Problem4.solution
                | Some(5)  -> solutionPrinter "Problem 5: 'Smallest multiple'." Solution.Problem5.solution
                | Some(6)  -> solutionPrinter "Problem 6: 'Sum square difference'." (fun _ -> Solution.Problem6.solution(100))
                | Some(7)  -> solutionPrinter "Problem 7: '10001st prime'." (Solution.Problem7.solution)
                | Some(8)  -> solutionPrinter "Problem 8: 'Largest product in a series'." (Solution.Problem8.solution)
                | Some(9)  -> solutionPrinter "Problem 9: 'Special Pythagorean triplet'." (Solution.Problem9.solution)
                | Some(10) -> solutionPrinter "Problem 10: 'Summation of primes'." (Solution.Problem10.solution)
                | Some(11) -> solutionPrinter "Problem 11: 'Largest product in a grid'."  SolutionCS.Problem11.Solution
                | Some(12) -> solutionPrinter "Problem 12: 'Highly divisible triangular number'."  SolutionCS.Problem12.Solution
                | Some(13) -> solutionPrinter "Problem 13: 'Large sum'."  SolutionCS.Problem13.Solution
                | Some(14) -> solutionPrinter "Problem 14: 'Longest Collatz sequence'."  SolutionCS.Problem14.Solution
                | Some(15) -> solutionPrinter "Problem 15: 'Lattice paths'."  SolutionCS.Problem15.Solution
                | Some(16) -> solutionPrinter "Problem 16: 'Power digit sum'." (fun _ -> SolutionCS.Problem16.GeneralizedSolution(1000))
                | Some(17) -> printfn "Problem 17: 'Number letter counts'. \nAnswer: '21124' (solved with pen & paper)."
                | Some(18) -> solutionPrinter "Problem 18: 'Maximum path sum I'." (fun _ -> SolutionCS.Problem18.GeneralizedSolution(SolutionCS.Problem18.TriangleData))
                | Some(19) -> solutionPrinter "Problem 19: 'Counting Sundays'."  SolutionCS.Problem19.Solution
                | Some(20) -> solutionPrinter "Problem 20: 'Factorial digit sum'."  SolutionCS.Problem20.Solution
                | Some(21) -> solutionPrinter "Problem 21: 'Amicable numbers'."  SolutionCS.Problem21.Solution
                | Some(22) -> solutionPrinter "Problem 22: 'Names scores'."  SolutionCS.Problem22.Solution
                | Some(23) -> solutionPrinter "Problem 23: 'Non-abundant sums'."  SolutionCS.Problem23.Solution
                | Some(24) -> solutionPrinter "Problem 24: 'Lexicographic permutations'."  SolutionCS.Problem24.Solution
                | Some(25) -> solutionPrinter "Problem 25: '1000-digit Fibonacci number'."  SolutionCS.Problem25.Solution
                | Some(26) -> solutionPrinter "Problem 26: 'Reciprocal cycles'." (fun _ -> SolutionCS.Problem26.Solution(1000))
                | Some(27) -> solutionPrinter "Problem 27: 'Quadratic primes'."  SolutionCS.Problem27.Solution
                | Some(28) -> solutionPrinter "Problem 28: 'Number spiral diagonals'."  SolutionCS.Problem28.Solution
                | Some(29) -> solutionPrinter "Problem 29: 'Distinct powers'."  SolutionCS.Problem29.Solution
                | Some(30) -> solutionPrinter "Problem 30: 'Digit fifth powers'." (fun _ -> SolutionCS.Problem30.Solution(5))
                | Some(31) -> solutionPrinter "Problem 31: 'Coin sums'." (fun _ -> SolutionCS.Problem31.Solution(200))
                | Some(32) -> solutionPrinter "Problem 32: 'Pandigital products'."  SolutionCS.Problem32.Solution
                | Some(33) -> solutionPrinter "Problem 33: 'Digit cancelling fractions'."  SolutionCS.Problem33.Solution
                | Some(34) -> solutionPrinter "Problem 34: 'Digit factorials'."  SolutionCS.Problem34.Solution
                | Some(35) -> solutionPrinter "Problem 35: 'Circular primes'."  SolutionCS.Problem35.Solution
                | Some(36) -> solutionPrinter "Problem 36: 'Double-base palindromes'."  SolutionCS.Problem36.Solution
                | Some(37) -> solutionPrinter "Problem 37: 'Truncatable primes'."  SolutionCS.Problem37.Solution
                | Some(38) -> solutionPrinter "Problem 38: 'Pandigital multiples'."  SolutionCS.Problem38.Solution
                | Some(39) -> solutionPrinter "Problem 39: 'Integer right triangles'."  SolutionCS.Problem39.Solution
                | Some(40) -> solutionPrinter "Problem 40: 'Champernowne's constant'."  SolutionCS.Problem40.Solution
                | Some(41) -> solutionPrinter "Problem 41: 'Pandigital prime'." (Solution.Problem41.solution)
                | Some(42) -> solutionPrinter "Problem 42: 'Coded triangle numbers'." (Solution.Problem42.solution)
                | Some(43) -> solutionPrinter "Problem 43: 'Sub-string divisibility'."  SolutionCS.Problem43.Solution
                | Some(44) -> solutionPrinter "Problem 44: 'Pentagon numbers'."  SolutionCS.Problem44.Solution
                | Some(45) -> solutionPrinter "Problem 45: 'Triangular, pentagonal, and hexagonal'." (fun _ -> Solution.Problem45.solution(5_000_000_000L))
                | Some(46) -> solutionPrinter "Problem 46: 'Goldbach's other conjecture'." (fun _ -> SolutionCS.Problem46.Solution(10000))
                | Some(47) -> solutionPrinter "Problem 47: 'Distinct primes factors'." Solution.Problem47.solution
                | Some(48) -> solutionPrinter "Problem 48: 'Self powers'." (fun _ -> Solution.Problem48.solution(1000) % bigint.Pow(10I, 10))
                | Some(49) -> solutionPrinter "Problem 49: 'Prime permutations'." SolutionCS.Problem49.Solution
                | Some(50) -> solutionPrinter "Problem 50: 'Consecutive prime sum'." (fun _ -> Solution.Problem50.solution 1_000_000)
                | Some(51) -> solutionPrinter "Problem 51: 'Prime digit replacements'." SolutionCS.Problem51.Solution
                | Some(52) -> solutionPrinter "Problem 52: 'Permuted multiples'." (fun _ -> SolutionCS.Problem52.Solution 150_000)
                | Some(53) -> solutionPrinter "Problem 53: 'Combinatoric selections'." SolutionCS.Problem53.Solution
                | Some(54) -> solutionPrinter "Problem 54: 'Poker hands.'." Solution.Problem54.solution
                | Some(55) -> solutionPrinter "Problem 55: 'Lychrel numbers'." Solution.Problem55.solution
                | Some(56) -> solutionPrinter "Problem 56: 'Powerful digit sum'." SolutionCS.Problem56.Solution
                | Some(57) -> solutionPrinter "Problem 57: 'Square root convergents'." SolutionCS.Problem57.Solution
                | Some(58) -> solutionPrinter "Problem 58: 'Spiral primes'." SolutionCS.Problem58.Solution
                
                | Some(60) -> solutionPrinter "Problem 60: 'Prime pair sets'." (fun _ -> SolutionCS.Problem60.Solution(5, 8389))
                
                | Some(62) -> solutionPrinter "Problem 62: 'Cubic permutations'." (fun _ -> SolutionCS.Problem62.Solution 5)
                | Some(63) -> solutionPrinter "Problem 63: 'Powerful digit counts'." Solution.Problem63.solution


                | Some(67) -> solutionPrinter "Problem 67: 'Maximum path sum II'."  SolutionCS.Problem67.Solution

                | Some(69) -> solutionPrinter "Problem 69: 'Totient maximum'."  (fun _ -> SolutionCS.Problem69.Solution 1_000_000)
                | Some(70) -> solutionPrinter "Problem 70: 'Totient permutation'."  (fun _ -> SolutionCS.Problem70.Solution 10_000_000)
                
                | Some(641) -> solutionPrinter "Problem 641: 'A Long Row of Dice'."  SolutionCS.Problem641.Solution
                
                | _        -> printfn "Problem not currently solved."
        
        program()
    0 // return an integer exit code

