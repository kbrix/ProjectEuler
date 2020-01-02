namespace Solution

module Problem5 =

    let solution =

        let condition n = [1..20] |> List.map (fun x -> n % x = 0) |> List.forall (fun x -> x = true)

        let sequence = 20 |> Seq.unfold (fun x -> Some(x, x + 20))
        
        sequence |> Seq.find (condition)

