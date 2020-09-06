module Problem47Tests

open NUnit.Framework

[<Test>]
let ``Distinct primes factors: example (two consecutive primes)`` () =
    let result = Solution.Problem47.indexFinder 20 2
    Assert.AreEqual(14, result)
        
[<Test>]
let ``Distinct primes factors: example (three consecutive primes)`` () =
    let result = Solution.Problem47.indexFinder 1000 3
    Assert.AreEqual(644, result)

[<Test>]
let ``Distinct primes factors: solution`` () =
    let result = Solution.Problem47.solution()
    Assert.AreEqual(134043, result)