module Problem45Tests

open NUnit.Framework

[<Test>]
let ``Triangular, pentagonal, and hexagonal: example`` () =
    Assert.AreEqual(40755L, Solution.Problem45.solution(50000L))

[<Test>]
let ``Triangular, pentagonal, and hexagonal: solution`` () =
    Assert.AreEqual(1_533_776_805L, Solution.Problem45.solution(5_000_000_000L))