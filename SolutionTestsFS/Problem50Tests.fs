module Problem50Tests

open NUnit.Framework

[<Test>]
let ``Consecutive prime sum: example under 1000`` () =
    Assert.AreEqual(953, Solution.Problem50.solution 1000)

[<Test>]
let ``Consecutive prime sum: solution`` () =
    Assert.AreEqual(997651, Solution.Problem50.solution 1000000)

[<Test>]
let ``Brute force primes up to 100 within window range 2 and 10`` () =
    Assert.AreEqual(6, Solution.Problem50.maximumConsecutivePrimeSum 99 2 10)

[<Test>]
let ``Brute force primes up to 1000 within window range 2 and 50`` () =
    Assert.AreEqual(21, Solution.Problem50.maximumConsecutivePrimeSum 999 2 50)