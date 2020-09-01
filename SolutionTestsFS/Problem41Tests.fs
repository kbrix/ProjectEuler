module Problem41Tests

open NUnit.Framework

[<Test>]
let ``Pandigital prime: solution`` () =
    Assert.AreEqual(7652413, Solution.Problem41.solution())