module Problem6Tests

open NUnit.Framework

[<Test>]
let ``Sum square difference: solution`` () =
    Assert.AreEqual(25164150, Solution.Problem6.solution(100))

