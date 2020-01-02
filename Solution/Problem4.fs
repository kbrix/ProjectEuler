namespace Solution

module Problem4 =

    let getDigits (n: int32) =
        let baseNumber = 10
        n 
        |> Seq.unfold (fun x -> 
            if (x = 0) then None 
            else Some(x % baseNumber, x / baseNumber))
        |> Seq.toList
        |> List.rev
    
    let isPalindrome n =
        let digits = n |> getDigits
        digits = (digits |> List.rev)

    let solution =
        let sequence = seq {
            for i in 100..999 do
                for j in 100..999 do
                    if (i <= j) then
                        yield (i*j)
        }
        sequence |> Seq.filter isPalindrome |> Seq.max
