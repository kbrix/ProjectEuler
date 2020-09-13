module Problem55Tests

open NUnit.Framework

[<Test>]
let ``Lychrel numbers: solution`` () =
    Assert.AreEqual(249, Solution.Problem55.solution())