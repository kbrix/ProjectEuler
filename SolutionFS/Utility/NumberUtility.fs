namespace Utility

module NumberUtility =
    
    let getDigits n =
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

    let isPandigital n =
        let digits = n |> getDigits
        let digitLength = digits |> List.length
        let distinctDigits = digits |> List.distinct
        let distinctDigitLength = distinctDigits |> List.length
        digitLength = distinctDigitLength && 
        (digits |> List.sort = [1 .. digitLength])