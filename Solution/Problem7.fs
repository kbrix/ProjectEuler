namespace Solution

module Problem7 =
    
    let solution() =
        Utility.PrimeUtility.primes |> Seq.item (10001 - 1)