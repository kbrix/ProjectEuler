module Problem2Tests

open System
open Xunit

[<Fact>]
let ``Even Fibonacci numbers: solution`` () =
    Assert.Equal(4613732, Solution.Problem2.solution)

[<Theory>]
[<InlineData(-1)>]
[<InlineData(0)>]
let ``Fibonacci numbers with illegal index`` (n) =
    let action = fun () -> Solution.Problem2.fibonacci(n) |> ignore
    Assert.Throws<ArgumentOutOfRangeException>(action) |> ignore
    ()

[<Theory>]
[<InlineData(1, 1)>]
[<InlineData(2, 2)>]
[<InlineData(3, 3)>]
[<InlineData(4, 5)>]
[<InlineData(5, 8)>]
[<InlineData(6, 13)>]
[<InlineData(10, 89)>]
let ``Test Fibonacci numbers`` (n, x) =
    let result = Solution.Problem2.fibonacci(n)
    Assert.Equal(x, result)
    ()
