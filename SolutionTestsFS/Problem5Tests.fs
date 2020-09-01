module Problem5Tests

open NUnit.Framework

[<Test>]
let ``Smallest multiple: solution`` () =
    Assert.AreEqual(232792560, Solution.Problem5.solution())