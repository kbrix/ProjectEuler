module Problem9Tests

open NUnit.Framework

[<Test>]
let ``Special Pythagorean triplet: solution`` () =
    Assert.AreEqual(31875000, Solution.Problem9.solution())