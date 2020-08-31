module Problem10Tests

open Xunit

[<Fact>]
let ``Summation of primes: solution`` () =
    Assert.Equal(142913828922L, Solution.Problem10.solution())