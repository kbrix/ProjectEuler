namespace Solution

module Problem1 =

    let solution =
        let multiples x = (x % 3 = 0) || (x % 5 = 0)
        [1..999] 
        |> List.filter (multiples) 
        |> List.sum