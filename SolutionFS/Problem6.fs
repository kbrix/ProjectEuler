namespace Solution

module Problem6 =
    
    let solution n =
        let sumOfSquares n = n * (n + 1) * (2*n + 1) / 6
        let squareOfSum n = [1..n] |> List.sum |> fun x -> x * x
        squareOfSum(n) - sumOfSquares(n)