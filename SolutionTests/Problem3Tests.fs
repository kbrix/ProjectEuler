module Problem3Tests

open Xunit

[<Fact>]
let ``Largest prime factor: solution`` () =
    Assert.Equal(6857L, Solution.Problem3.solution)