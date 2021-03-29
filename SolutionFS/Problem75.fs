namespace Solution

module Problem75 = 

    let solution() =
        
        let counters = SolutionCS.Problem39.TripletCounter(1_500_000)
        counters |> Seq.filter (fun c -> c = 1) |> Seq.length