module Problem2Tests

open NUnit.Framework

[<Test>]
let ``Even Fibonacci numbers: solution`` () =
    Assert.AreEqual(4613732, Solution.Problem2.solution())

[<TestCase(-1)>]
[<TestCase(0)>]
let ``Fibonacci numbers with illegal index`` (n) =
    let action = TestDelegate(fun () -> Solution.Problem2.fibonacci(n) |> ignore)
    Assert.Throws<System.ArgumentOutOfRangeException>(action) |> ignore
    ()

[<TestCase(1, 1)>]
[<TestCase(2, 2)>]
[<TestCase(3, 3)>]
[<TestCase(4, 5)>]
[<TestCase(5, 8)>]
[<TestCase(6, 13)>]
[<TestCase(10, 89)>]
let ``Test Fibonacci numbers`` (n, x) =
    let result = Solution.Problem2.fibonacci(n)
    Assert.AreEqual(x, result)
    ()
