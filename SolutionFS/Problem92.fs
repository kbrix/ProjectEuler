namespace Solution

module Problem92 =

    let memoize f =
        let cache = System.Collections.Concurrent.ConcurrentDictionary<int,int>()
        fun x ->
            cache.GetOrAdd(x, fun x -> f x)

    // This memoization handles recursive functions by defining mutually recursive functions 
    // g : 'a -> 'b and h : ('a -> 'b) -> 'a -> 'b, where g is the memoized form of f that will get passed to f itself,
    // and h does the actual work.
    let memoizeRec f =
      let mem = System.Collections.Concurrent.ConcurrentDictionary<int,int>();
      let rec g key = h g key
      and h r key =
        mem.GetOrAdd(key, fun key -> f g key)
      g

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

    // Extended version, allowing memoized recursion by passing a memoized version of itself
    let digitChainRec r (n : int) =
        match n with 
        | 1  -> 1
        | 89 -> 89
        | _  -> n |> sumDigitSquares |> r

    let solution =
        let memoizedDigitChain = memoizeRec digitChainRec
        [| 1 .. 10_000_000|]
        |> Array.Parallel.map memoizedDigitChain
        |> Array.filter (fun n -> n = 89)
        |> Array.length