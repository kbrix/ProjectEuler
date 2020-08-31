module Problem4Tests

open Xunit

[<Fact>]
let ``Largest palindrome product: solution`` () =
    Assert.Equal(906609, Solution.Problem4.solution())