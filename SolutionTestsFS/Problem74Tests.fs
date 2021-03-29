module Problem74Tests

open NUnit.Framework

[<Test>]
let factorial_largeNumber_returnsFactorial () =
    Assert.AreEqual(2432902008176640000I , Solution.Problem74.factorial 20I)

[<Test>]
let factorialDigitSum_number_returnsSum () =
    Assert.AreEqual(145, Solution.Problem74.factorialDigitSum 145)

[<Test>]
let factorialDigitSumLoopLength_69_returnsCount () =
    Assert.AreEqual(5 , Solution.Problem74.factorialDigitSumLoopLength 69)

[<Test>]
let factorialDigitSumLoopLength_78_returnsCount () =
    Assert.AreEqual(4 , Solution.Problem74.factorialDigitSumLoopLength 78)

[<Test>]
let factorialDigitSumLoopLength_145_returnsCount () =
    Assert.AreEqual(1 , Solution.Problem74.factorialDigitSumLoopLength 145)

[<Test>]
let ``Digit factorial chains: solution`` () =
    let result = Solution.Problem74.solution ()
    Assert.AreEqual(402 , result)