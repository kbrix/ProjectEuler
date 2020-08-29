namespace Solution

module Problem48 =

    let solution(n) =
        [|1 .. n|] |> Array.map (fun x -> bigint.Pow(new bigint(x), x)) |> Array.sum