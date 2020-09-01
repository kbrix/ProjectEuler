module Problem8Tests

open NUnit.Framework

[<Test>]
let ``Largest product in a series: solution`` () =
    Assert.AreEqual(23514624000L, Solution.Problem8.solution())