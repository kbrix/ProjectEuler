namespace Solution

module Problem3 =

    let solution() =
        let rec largestPrimeFactor (n: int64) (divisor: int64) =
            match System.Math.DivRem(n, divisor) with
            | (x, 0L) -> largestPrimeFactor x divisor
            | _       -> if (divisor * divisor > n) then n else largestPrimeFactor n (divisor + 2L)
        largestPrimeFactor 600851475143L 3L