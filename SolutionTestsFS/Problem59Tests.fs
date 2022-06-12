module Problem59Tests

open NUnit.Framework

[<Test>]
let ``XOR decryption: solution`` () =
    Assert.AreEqual(129448, Solution.Problem59.solution)