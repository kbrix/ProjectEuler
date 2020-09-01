module Problem10Tests

open NUnit.Framework

[<Test>]
let ``Summation of primes: solution`` () =
    Assert.AreEqual(142913828922L, Solution.Problem10.solution())