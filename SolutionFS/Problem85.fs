/// Counting rectangles, https://projecteuler.net/problem=85
module SolutionFS.Problem85

open System.Collections.Generic

/// Counts the number of rectangles contained in the 'n' by 'm' grid. The formula is the product of two series from 1 to
/// 'n' and 'm'.
let countRectanglesInGrid n m =
    (n * (n + 1) / 2) * (m * (m + 1) / 2)

let solution =
    let values = Dictionary<int * int, int>()
    for n in 1 .. 100 do
        for m in 1 .. 100 do
            if n >= m then
                let count = countRectanglesInGrid n m
                let distance = System.Math.Abs(2_000_000 - count)
                values.Add((n, m), distance)
    
    let minimumDistanceKvp = values |> Seq.minBy (fun kvp -> kvp.Value)
    let n, m = fst minimumDistanceKvp.Key, snd minimumDistanceKvp.Key
    let area = n * m
    printfn $"The grid is {n} by {m} and contains {countRectanglesInGrid n m} rectangles."
    area
    