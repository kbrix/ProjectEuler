namespace Solution

module Problem10 =
    
    let solution() =
        Utility.PrimeUtility.primes |> Seq.takeWhile (fun p -> p < 2000000) |> Seq.sumBy (int64)