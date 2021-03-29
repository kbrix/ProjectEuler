module Problem75Tests

open NUnit.Framework

[<Test>]
let ``Singular integer right triangles: solution`` () =
    let result = Solution.Problem75.solution ()
    Assert.AreEqual(161667 , result)
