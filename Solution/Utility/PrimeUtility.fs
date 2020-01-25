namespace Utility

module PrimeUtility =

    
    // Start with a table of numbers (e.g., 2, 3, 4, 5, ...).
    // Let the first number be 'p'.
    // 1. Declare 'p' to be prime, and cross off all the multiples of that number in the table, starting from 'p^2'.
    // 2. Find the next number in the table after 'p' that is not yet crossed off and set 'p' to that number;
    //    and then repeat from step 1.
    // See section 3 of https://www.cs.hmc.edu/~oneill/papers/Sieve-JFP.pdf and 
    // https://stackoverflow.com/questions/4629734/the-sieve-of-eratosthenes-in-f

    //let primes =
    //    let rec nextMultiple nKey pValue map =
    //        if map |> Map.containsKey nKey then
    //            nextMultiple (nKey + pValue) pValue map
    //        else
    //            map.Add(nKey, pValue)

    //    let rec primeSequence n map =
    //        seq {
    //            if map |> Map.containsKey n then
    //                let p = map.Item n
    //                yield! primeSequence (n + 1L) (nextMultiple (n + p) p (map.Remove n))
    //            else
    //                yield n
    //                yield! primeSequence (n + 1L) (map.Add(n * n, n))
    //        }
        
    //    primeSequence 2L Map.empty
    
    let primes =

        let isPrime n =
            if n < 1 then 
                false
            else
                let max = n |> double |> sqrt |> int
                {2 .. max} |> Seq.forall (fun i -> n % i <> 0) // check non-divisibility
        
        let rec getNextPrime n =
            if isPrime n then n
            else getNextPrime (n + 1)

        2 |> Seq.unfold (fun p -> Some(p, getNextPrime (p + 1)))