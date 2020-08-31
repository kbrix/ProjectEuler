module Problem42Tests

open Xunit

[<Fact>]
let ``Coded triangle numbers: solution`` () =
    Assert.Equal(162, Solution.Problem42.solution())