namespace Solution

module Problem41 =
    
    let solution() =
        Utility.PrimeUtility.primes 
        |> Seq.takeWhile (fun p -> p <= 87654321) 
        |> Seq.filter (Utility.NumberUtility.isPandigital)
        |> Seq.max