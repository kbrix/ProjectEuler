namespace Solution

module Problem78 =

    // See literature: Calculating the unrestricted partition function [...], 
    // Theorem 12 (Euler's Recurrence) and  the recurrence algorithm, p. 13-14.
    let partitionArrayValues n =
        if n < 0 then 
            [| 0I |]
        elif n = 0 then 
            [| 1I |]
        else
            let sq = sqrt(1.0 + 24.0 * double(n))
            let max_k = 1 + int(floor((sq - 1.0) / 6.0))
            let pentagonals = Array.zeroCreate (2 * max_k)
            let partitions = Array.create (n + 1) 1I

            for m in 1 .. max_k do // compute generalized pentagonal numbers
                pentagonals.[2 * m - 2]     <- m * (3 * m - 1) / 2
                pentagonals.[2 * m - 2 + 1] <- m * (3 * m + 1) / 2
            
            for i in 1 .. n do
                let mutable partialSum = 0I
                let mutable j = 1
                while pentagonals.[j - 1] <= i do
                    let summand = partitions.[i - pentagonals.[j - 1]]
                    if (j % 4) = 1 || (j % 4) = 2 then
                        partialSum <- partialSum + summand
                    else
                        partialSum <- partialSum - summand
                    j <- j + 1
                partitions.[i] <- partialSum
            partitions

    let solution n =
        let partitionValues = partitionArrayValues n
        let result = 
            partitionValues
            |> Array.findIndex (fun p -> (p % 1_000_000I) = 0I)
        result