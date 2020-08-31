namespace Solution

module Problem4 =

    let solution() =
        let sequence = seq {
            for i in 100..999 do
                for j in 100..999 do
                    if (i <= j) then
                        yield (i*j)
        }
        sequence |> Seq.filter Utility.NumberUtility.isPalindrome |> Seq.max
