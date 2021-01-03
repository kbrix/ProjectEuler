module Problem63Tests

open NUnit.Framework

[<Test>]
let ``Powerful digit counts: solution`` () =
    Assert.AreEqual(49, Solution.Problem63.solution())
