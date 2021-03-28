module Problem73Tests

open NUnit.Framework

[<Test>]
let ``Counting fractions in a range: example`` () =
    Assert.AreEqual(3, Solution.Problem73.solution 8)

[<Test>]
let ``Counting fractions in a range: solution`` () =
    Assert.AreEqual(7_295_372, Solution.Problem73.solution 12_000)
