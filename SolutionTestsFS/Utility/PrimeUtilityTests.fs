module PrimeUtilityTests

open NUnit.Framework

let readLines (filePath : string) =
    seq {
        use reader = new System.IO.StreamReader (filePath)
        while not reader.EndOfStream do
            yield reader.ReadLine() |> int
    }

[<Test>]
let ``Prime seqeunce test`` () =
    let filepath = "../../../Utility/Data/primes1million.txt"
    let data = filepath |> readLines |> Seq.toArray
    let primes = Utility.PrimeUtility.primes |> Seq.take 1000000 |> Seq.toArray
    

    for i = 0 to primes.Length - 1 do
        Assert.AreEqual(data.[i], primes.[i])