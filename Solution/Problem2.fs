namespace Solution

module Problem2 = 
    
    let solution() =
        let sequence = (1, 1) |> Seq.unfold (fun (a, b) -> Some(a + b, (b, a + b)))
        let fibonacciSequence = seq { yield 1; yield 1; yield! sequence }
        fibonacciSequence |> Seq.takeWhile (fun x -> x <= 4000000) |> Seq.filter (fun x -> x % 2 = 0) |> Seq.sum

    let fibonacci n =
        if (n < 1) then 
            raise (System.ArgumentOutOfRangeException("Index must be a natural number."))
        let cache = Array.create (n + 2) 0
        let rec f = fun x ->
            match x with
            | 1 | 2 -> 1
            | x ->
                match cache.[x] with
                | 0 ->
                    cache.[x] <- f(x-1) + f(x-2)
                    cache.[x]
                | x -> x
        f(n + 1)