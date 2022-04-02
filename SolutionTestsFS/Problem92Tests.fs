module Problem92Tests

open NUnit.Framework

[<Test>]
let ``Square digit chains: example, 42`` () =
    let result = Solution.Problem92.digitChain 44
    Assert.AreEqual(1, result)

[<Test>]
let ``Square digit chains: example, 85`` () =
    let result = Solution.Problem92.digitChain 85
    Assert.AreEqual(89, result)

[<Test>]
let ``Square digit chains: solution`` () =
    let result = Solution.Problem92.solution
    Assert.AreEqual(8581146, result)