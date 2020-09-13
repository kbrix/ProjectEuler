namespace Solution

module Problem50 =

    // current solution does not work for the example under 100
    // this is because the solution assumes the first prime summand is equal to three
    // in the example under 100, the first prime summand is equal to two (use the brute force solution for that)
    
    let solution (max : int) =
        let primes = max |> SolutionCS.Utility.PrimeUtility.PrimeSieveOfEratosthenes |> Array.ofSeq |> Array.map (fun p -> (int64) p)
        let primeSet = primes |> Set.ofArray
        let cumulativeSum = primes |> SolutionCS.Utility.ArrayExtensions.CumulativeSum
        
        let mutable sum = 0L
        let mutable length = 0

        for i = 0 to Array.length primes - 1 do
            for j = i + 1 to Array.length primes - 1 do
                let primeSum = cumulativeSum.[j] - cumulativeSum.[i]
                let primeSumLength = j - i
                if primeSum <= (int64) max && primeSumLength >= length && Set.contains primeSum primeSet then 
                    sum <- primeSum
                    length <- primeSumLength
        sum

    let f (sum, length) primes =
        if primes |> Array.contains sum then length
        else 0

    let consecutivePrimeSumLength (max : int) window =
        let primes = 
            max 
            |> SolutionCS.Utility.PrimeUtility.PrimeSieveOfEratosthenes 
            |> Array.ofSeq

        let primeSumLengths = 
            primes 
            |> Array.windowed window 
            |> Array.map (fun x -> SolutionCS.Utility.ArrayExtensions.FastSum(x, (int) max), Array.length x) 
            |> Array.map (fun z -> f z primes)

        let maxPrimeSumLength = primeSumLengths |> Array.max
        maxPrimeSumLength

    let maximumConsecutivePrimeSum max minWindow maxWindow =
        let sumLengths = 
            [|minWindow .. maxWindow|] 
            |> Array.map (fun i -> consecutivePrimeSumLength max i)

        let maxSumLength = sumLengths |> Array.max
        maxSumLength