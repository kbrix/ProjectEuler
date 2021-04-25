namespace Solution

open System.Collections.Generic

module Problem87 =

    let solution n =
        let max = n |> double |> sqrt |> int
        let primes = SolutionCS.Utility.PrimeUtility.PrimeSieveOfEratosthenes(max) |> Seq.toArray |> Array.map (int64)
        
        // first index is second power of primes, the second index is the thrid power of primes etc.
        let primePowers = Array2D.create 3 primes.Length 0L
        for p in 0 .. 2 do for i in 0 .. primes.Length - 1 do
            primePowers.[p, i] <- pown primes.[i] (p + 2)
        
        let values = new SortedSet<int64>()
        for i in 0 .. primes.Length - 1 do for j in 0 .. primes.Length - 1 do for k in 0 .. primes.Length - 1 do
            let value = primePowers.[0, i] + primePowers.[1, j] + primePowers.[2, k]
            if value <= n then 
                values.Add(value) |> ignore

        values.Count