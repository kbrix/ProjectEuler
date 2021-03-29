module Problem68Tests

open NUnit.Framework

[<Test>]
let isThreeGonRing_validRing_returnsTrue () =
    let ring = [| 4; 3; 2; 6; 1; 5 |]
    Assert.IsTrue(Solution.Problem68.isThreeGonRing ring)

[<Test>]
let threeGonRingSolution_returnsSolution () =
    Assert.AreEqual(432621513,  Solution.Problem68.threeGonRingSolution)

[<Test>]
let ``Magic 5-gon ring: solution`` () =
    let result = Solution.Problem68.solution ()
    Assert.AreEqual(6531031914842725L , result)