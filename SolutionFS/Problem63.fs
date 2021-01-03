namespace Solution

module Problem63 =

    let solution() =

        let condition n p =
            let m = bigint.Pow(n, p)
            p = SolutionCS.Utility.Miscellaneous.DigitLength(m)

        let mutable counter = 0

        for i in 1I..9I do
                for j in 1..999 do
                    if (condition i j) then
                        counter <- counter + 1
        
        counter