namespace Solution

module Problem73 =
    
    let solution n =

        let fstv struct (a, _) =  a
        let sndv struct (_, b) =  b

        let farleySequence = SolutionCS.Problem71.FarleySequence(n) |> Seq.toArray
        
        let length = 
            farleySequence
            |> Array.filter (fun x -> sndv x < 3 * fstv x && 2 * fstv x < sndv x) // 1/3 < fst/snd < 1/2
            |> Array.length
        
        length