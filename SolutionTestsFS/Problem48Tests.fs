module Problem48Tests

open NUnit.Framework

[<Test>]
let ``Self powers: example`` () =
    Assert.AreEqual(10405071317I, Solution.Problem48.solution(10))

[<Test>]
let ``Self powers: solution`` () =
    Assert.AreEqual(9110846700I, Solution.Problem48.solution(1000) % bigint.Pow(10I, 10))