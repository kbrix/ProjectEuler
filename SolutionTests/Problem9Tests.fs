module Problem9Tests

open Xunit

[<Fact>]
let ``Special Pythagorean triplet: solution`` () =
    Assert.Equal(31875000, Solution.Problem9.solution())