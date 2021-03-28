module Problem71Tests

open NUnit.Framework

[<Test>]
let ``Ordered fractions: solution`` () =
    Assert.AreEqual(428_570, Solution.Problem71.solution() |> fst)
    Assert.AreEqual(999_997, Solution.Problem71.solution() |> snd)
