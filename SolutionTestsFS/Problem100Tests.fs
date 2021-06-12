module Problem100Tests

open NUnit.Framework

[<Test>]
let ``Arranged probability: example`` () =
    let result = Solution.Problem100.solution 10L
    Assert.AreEqual(15L, result)

[<Test>]
let ``Arranged probability: another example`` () =
    let result = Solution.Problem100.solution 25L
    Assert.AreEqual(85L, result)

[<Test>]
let ``Arranged probability: solution`` () =
    let result = Solution.Problem100.solution 1_000_000_000_000L
    Assert.AreEqual(756_872_327_473L, result)
