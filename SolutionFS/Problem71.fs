namespace Solution

module Problem71 =
    
    let solution() =
        // continuously updates the mediant fraction until the denominator becomes too large
        let rec f a b c d n =
            if b + d <= n then
                let _a = a + c
                let _b = b + d
                f _a _b c d n
            else (a, b)

        let fraction = f 2 5 3 7 1_000_000
        fraction
