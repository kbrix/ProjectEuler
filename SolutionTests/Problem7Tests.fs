module Problem7Tests

open Xunit

[<Fact>]
let ``10001st prime: solution`` () =
    Assert.Equal(104743, Solution.Problem7.solution())