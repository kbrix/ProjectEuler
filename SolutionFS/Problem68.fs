namespace Solution

module Problem68 =

    let isThreeGonRing (x : int[]) =
        let group1 = x.[0] + x.[1] + x.[2]
        let group2 = x.[3] + x.[2] + x.[4]
        let group3 = x.[5] + x.[4] + x.[1]
        
        let isFirstExternalNodeMinimumExternalNode = 
            x.[0] < x.[3] && x.[0] < x.[5]
        
        let isLineSumEqual = 
            group1 = group2 && group2 = group3
        
        if isFirstExternalNodeMinimumExternalNode && isLineSumEqual then true
        else false

    let getThreeGonRingNumber (x : int[]) =
        let digits = [| 
            x.[0]; x.[1]; x.[2]; 
            x.[3]; x.[2]; x.[4];
            x.[5]; x.[4]; x.[1]; 
        |]
        SolutionCS.Utility.LinqExtensions.ConcatenateDigits(digits)

    let threeGonRingSolution =
        let x = [| 1 .. 6 |]
        let permutations = SolutionCS.Utility.LinqExtensions.GetPermutations(x, x.Length)
        let maxThreeGonRingSolution =
            permutations 
            |> Seq.map (Seq.toArray)
            |> Seq.filter (isThreeGonRing)
            |> Seq.map (getThreeGonRingNumber)
            |> Seq.max
        maxThreeGonRingSolution

    let isFiveGonRing (x : int[]) =
        let group1 = x.[0] + x.[1] + x.[2]
        let group2 = x.[3] + x.[2] + x.[4]
        let group3 = x.[5] + x.[4] + x.[6]
        let group4 = x.[7] + x.[6] + x.[8]
        let group5 = x.[9] + x.[8] + x.[1]
        
        let isFirstExternalNodeMinimumExternalNode = 
            x.[0] < x.[3] && x.[0] < x.[5] && x.[0] < x.[7] && x.[0] < x.[9]
        
        let isLineSumEqual = 
            group1 = group2 && group2 = group3 && group3 = group4 && group4 = group5
        
        if isFirstExternalNodeMinimumExternalNode && isLineSumEqual then true
        else false

    let getFiveGonRingNumber (x : int[]) =
        let digits = [| 
            x.[0]; x.[1]; x.[2]; 
            x.[3]; x.[2]; x.[4];
            x.[5]; x.[4]; x.[6]; 
            x.[7]; x.[6]; x.[8]; 
            x.[9]; x.[8]; x.[1]; 
        |]
        let largeDigits = digits  |> Array.map (fun d -> (int64) d) 
        SolutionCS.Utility.LinqExtensions.ConcatenateDigits(largeDigits)

    let solution () =
        let x = [| 1 .. 10 |]
        let permutations = SolutionCS.Utility.LinqExtensions.GetPermutations(x, x.Length)
        let maxFiveGonRingSolution =
            permutations 
            |> Seq.toArray
            |> Array.Parallel.map (Seq.toArray)
            |> Array.filter (isFiveGonRing)
            |> Array.Parallel.map (getFiveGonRingNumber)
            |> Array.filter (fun n -> SolutionCS.Utility.Miscellaneous.DigitLength(n) = 16)
            |> Array.max
        maxFiveGonRingSolution