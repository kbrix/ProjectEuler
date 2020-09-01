module Problem1Tests

open NUnit.Framework

[<Test>]
let ``Multiples of 3 and 5: solution`` () =
    Assert.AreEqual(233168, Solution.Problem1.solution())
