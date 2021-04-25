module Problem78Tests

open NUnit.Framework

[<Test>]
let ``Partition function: array values (example)`` () =
    let partitions = [| 1I; 1I; 2I; 3I; 5I; 7I |]
    let result = Solution.Problem78.partitionArrayValues 5
    CollectionAssert.AreEqual(partitions, result)

[<Test>]
let ``Coin partitions: solution`` () =
    let result = Solution.Problem78.solution 60_000
    Assert.AreEqual(55374, result)
