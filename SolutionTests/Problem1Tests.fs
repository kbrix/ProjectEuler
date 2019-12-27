module Tests

open System
open Xunit

[<Fact>]
let ``Multiples of 3 and 5: solution`` () =
    Assert.Equal(233168, Solution.Problem1.solution)
