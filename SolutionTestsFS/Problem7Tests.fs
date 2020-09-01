module Problem7Tests

open NUnit.Framework

[<Test>]
let ``10001st prime: solution`` () =
    Assert.AreEqual(104743, Solution.Problem7.solution())