module Problem48Tests

open Xunit

[<Fact>]
let ``Self powers: example`` () =
    Assert.Equal(10405071317I, Solution.Problem48.solution(10))

[<Fact>]
let ``Self powers: solution`` () =
    Assert.Equal(9110846700I, Solution.Problem48.solution(1000) % bigint.Pow(10I, 10))