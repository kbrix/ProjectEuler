namespace Solution

module Problem92 =

    let squares i =
        match i with
        | 0 -> 0
        | 1 -> 1
        | 2 -> 4
        | 3 -> 9
        | 4 -> 16
        | 5 -> 25
        | 6 -> 36
        | 7 -> 49
        | 8 -> 64
        | 9 -> 81
        | _ -> failwith $"Unsupported input: '{i}'."

    let sumDigitSquares (n : int) =
        SolutionCS.Utility.Miscellaneous.Digits(n)
        |> Seq.map squares
        |> Seq.sum

    let rec digitChain (n : int) =
        match n with 
        | 1  -> 1
        | 89 -> 89
        | _  -> n |> sumDigitSquares |> digitChain

    let solution =
        [| 1 .. 10_000_000|]
        |> Array.Parallel.map digitChain
        |> Array.filter (fun n -> n = 89)
        |> Array.length