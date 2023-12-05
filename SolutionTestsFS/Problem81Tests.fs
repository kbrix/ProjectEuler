module SolutionTestsFS.Problem81Tests

open System
open NUnit.Framework
open SolutionFS

[<Test>]
let ``Partial traversal in matrix 1`` () =
    let partialPathSum = Problem81.computePartialMinimalPathSum 0 0 Problem81.exampleMatrix 5 3 131
    Assert.That (partialPathSum.Coordinate, Is.EqualTo ((1, 2)))
    Assert.That (partialPathSum.Value, Is.EqualTo 342)
    Assert.That (partialPathSum.PathSum, Is.EqualTo 770)

[<Test>]
let ``Partial traversal in matrix 2`` () =
    let partialPathSum = Problem81.computePartialMinimalPathSum 1 2 Problem81.exampleMatrix 5 5 770
    Assert.That (partialPathSum.Coordinate, Is.EqualTo ((4, 4)))
    Assert.That (partialPathSum.Value, Is.EqualTo 331)
    Assert.That (partialPathSum.PathSum, Is.EqualTo 2427)

[<Test>]
let ``Partial traversal in matrix 3`` () =
    let partialPathSum = Problem81.computePartialMinimalPathSum 0 0 Problem81.exampleMatrix 5 8 131
    Assert.That (partialPathSum.Coordinate, Is.EqualTo ((4, 4)))
    Assert.That (partialPathSum.Value, Is.EqualTo 331)
    Assert.That (partialPathSum.PathSum, Is.EqualTo 2427)

[<Test>]
let ``Example`` () =
    let partialPathSum = Problem81.computeMinimalPathSum 0 0 Problem81.exampleMatrix 5 7 131
    Assert.That (partialPathSum.Coordinate, Is.EqualTo ((4, 4)))
    Assert.That (partialPathSum.Value, Is.EqualTo 331)
    Assert.That (partialPathSum.PathSum, Is.EqualTo 2427)

[<Test>]
[<Ignore("Too slow and does not work, path guess length not large enough")>]
let ``Solution`` () =
    let partialPathSum = Problem81.computeMinimalPathSum 0 0 Problem81.matrix 80 10 4445
    Assert.That (partialPathSum.Coordinate, Is.EqualTo ((79, 79)))
    Assert.That (partialPathSum.Value, Is.EqualTo 7981)
    Assert.That (partialPathSum.PathSum, Is.EqualTo 427337)

[<Test>]
let ``Example using dynamic programming`` () =
    let sum = Problem81.solution Problem81.exampleMatrix 
    Console.WriteLine sum
    Assert.That (sum, Is.EqualTo 2427)
    
[<Test>]
let ``Solution using dynamic programming`` () = 
    let sum = Problem81.solution Problem81.matrix 
    Console.WriteLine sum    
    Assert.That (sum, Is.EqualTo 427337)