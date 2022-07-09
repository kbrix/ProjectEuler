module SolutionTestsFS.Problem85Tests

open NUnit.Framework

[<Test>]
let ``Counting rectangles: example`` () =
    let count = SolutionFS.Problem85.countRectanglesInGrid 3 2
    Assert.AreEqual(18, count)
    
[<Test>]
let ``Counting rectangles: solution`` () =
    let count = SolutionFS.Problem85.solution
    Assert.AreEqual(2772, count)