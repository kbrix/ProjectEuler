module Problem3Tests

open NUnit.Framework

[<Test>]
let ``Largest prime factor: solution`` () =
    Assert.AreEqual(6857L, Solution.Problem3.solution())