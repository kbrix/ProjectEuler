module Problem41Tests

open Xunit

[<Fact>]
let ``Pandigital prime: solution`` () =
    Assert.Equal(7652413, Solution.Problem41.solution())