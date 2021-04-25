module Problem78Tests

open NUnit.Framework

[<Test>]
let ``Partition function: array values (example)`` () =
    let partitions = [| 1; 1; 2; 3; 5; 7 |]
    let result = Solution.Problem78.partitionArrayValues 5
    CollectionAssert.AreEqual(partitions, result)

[<Test>]
let ``Coin partitions: solution`` () =
    let result = Solution.Problem78.solution 60_000
    Assert.AreEqual(55374, result)
