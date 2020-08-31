module Problem5Tests

open Xunit

[<Fact>]
let ``Smallest multiple: solution`` () =
    Assert.Equal(232792560, Solution.Problem5.solution())