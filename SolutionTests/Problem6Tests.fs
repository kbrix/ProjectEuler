module Problem6Tests

open Xunit

[<Fact>]
let ``Sum square difference: solution`` () =
    Assert.Equal(25164150, Solution.Problem6.solution(100))

