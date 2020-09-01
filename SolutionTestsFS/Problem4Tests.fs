module Problem4Tests

open NUnit.Framework

[<Test>]
let ``Largest palindrome product: solution`` () =
    Assert.AreEqual(906609, Solution.Problem4.solution())