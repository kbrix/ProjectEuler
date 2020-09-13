namespace Solution

module Problem55 =

    let isPalindrome (n : bigint) = SolutionCS.Utility.NumberUtility.IsPalindrome(n)
    let reverse (n : bigint) = SolutionCS.Utility.NumberUtility.Reverse(n)

    let rec isLychel (n : bigint) k =
        if k >= 50 then true
        else if isPalindrome n && k >= 1 then false
        else isLychel (n + reverse n) (k + 1)
    
    let solution() =
        [|10I .. 10000I|] 
        |> Array.filter (fun n -> isLychel n 0)
        |> Array.length

