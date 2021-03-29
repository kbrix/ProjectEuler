namespace Solution

module Problem74 =

    let factorial (n : bigint) =
        if n = 0I || n = 1I then 1I
        else [|1I .. n|] |> Array.reduce (*)

    let fastFactorial n =
        match n with
        | 0 | 1 -> 1 
        | 2     -> 2
        | 3     -> 6
        | 4     -> 24
        | 5     -> 120
        | 6     -> 720
        | 7     -> 5040
        | 8     -> 40320
        | 9     -> 362880
        | _     -> raise(System.ArgumentOutOfRangeException())

    let factorialDigitSum (n : int) =
        SolutionCS.Utility.Miscellaneous.Digits(n)
            |> Seq.map (fastFactorial) 
            |> Seq.sum

    let factorialDigitSumLoopLength n =
        let rec f (x : int) (cache : Set<int>) =
            if cache |> Set.contains x then 
                cache
            else 
                let updatedCache = Set.add x cache
                let element = factorialDigitSum x
                f element updatedCache
        
        // todo another cache could be implemented here where we have the elements
        let elements = f n Set.empty
        elements |> Set.count

    // a better solution would also cache the loops
    let solution () = 
        [|1 .. 1_000_000|]
        |> Array.Parallel.map (factorialDigitSumLoopLength)
        |> Array.filter (fun l -> l = 60)
        |> Array.length