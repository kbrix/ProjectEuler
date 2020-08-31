namespace Utility

module PrimeUtility =
    
    let isPrime = SolutionCS.Utility.PrimeUtility.IsPrime

    let primes =

        let rec getNextPrime n =
            if isPrime n then n
            else getNextPrime (n + 1)

        2 |> Seq.unfold (fun p -> Some(p, getNextPrime (p + 1)))