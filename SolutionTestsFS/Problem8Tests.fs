module Problem8Tests

open Xunit

[<Fact>]
let ``Largest product in a series: solution`` () =
    Assert.Equal(23514624000L, Solution.Problem8.solution())