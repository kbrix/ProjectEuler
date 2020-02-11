module Problem42Tests

open Xunit

[<Fact>]
let ``Coded triangle numbers: solution`` () =
    Assert.Equal(200, Solution.Problem42.solution())