namespace Solution

module Problem47 =
    
    let indexFinder max n =
        let index = 
            [1 .. max]
            |> List.map (SolutionCS.Utility.PrimeUtility.PrimeFactors)
            |> List.map (fun ie -> List.ofSeq ie)
            |> List.map (fun l -> List.distinct l)
            |> List.windowed (n)
            |> List.map (fun l -> l |> List.forall (fun x -> List.length x = n))
            |> List.findIndex (fun l -> l = true)
        index + 1

    let solution() =
        indexFinder 150_000 4