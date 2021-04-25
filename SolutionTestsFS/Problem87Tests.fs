module Problem87Tests

open NUnit.Framework

[<Test>]
let ``Prime power triples: example`` () =
    let result = Solution.Problem87.solution 50L
    Assert.AreEqual(4, result)

[<Test>]
let ``Prime power triples: solution`` () =
    let result = Solution.Problem87.solution 50_000_000L
    Assert.AreEqual(1097343, result)