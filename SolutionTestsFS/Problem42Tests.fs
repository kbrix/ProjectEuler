module Problem42Tests

open NUnit.Framework

[<Test>]
let ``Coded triangle numbers: solution`` () =
    Assert.AreEqual(162, Solution.Problem42.solution())