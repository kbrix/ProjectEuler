namespace Solution

module Problem9 =
    
    let isPythagoreanTriplet triple = 
        match List.sort triple with
        | [a; b; c] -> a*a + b*b = c*c 
        | _         -> false

    let solution() =
        let sequence = seq {
            for a in 1 .. 1000 do
                for b in 1 .. 1000 do
                    for c in 1.. 1000 do
                        if a + b + c = 1000 && isPythagoreanTriplet [a; b; c] then
                            yield a*b*c
        }
        sequence |> Seq.item 0