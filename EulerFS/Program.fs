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
    printfn "Welcome to Kristoffer's solutions in F#!"
    
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
                printfn "Please stop trolling my program"
            else
                match number with
                | None     -> printfn ""
                | Some(1)  -> solutionPrinter "Problem 1: 'Multiples of 3 and 5'." Solution.Problem1.solution
                | Some(2)  -> solutionPrinter "Problem 2: 'Even Fibonacci numbers'." Solution.Problem2.solution
                | Some(3)  -> solutionPrinter "Problem 3: 'Largest prime factor'." Solution.Problem3.solution
                | Some(4)  -> solutionPrinter "Problem 4: 'Largest palindrome product'." Solution.Problem4.solution
                | Some(5)  -> solutionPrinter "Problem 5: 'Smallest multiple'." Solution.Problem5.solution
                | _        -> printfn "Problem not currently solved."
        
        program()
    0 // return an integer exit code

