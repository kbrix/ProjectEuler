namespace Solution

module Problem42 =
    
    let filePath = "../../../../Solution/Data/p042_words.txt"

    let triangleNumberSequence = (1) |> Seq.unfold (fun n -> Some(1/2 * n * (n + 1), n + 1))

    let solution() =
        let wordScores = seq {
            use reader = new System.IO.StreamReader (filePath)
            while not reader.EndOfStream do
            yield reader.ReadLine() |> euler.Utility.Miscellaneous.ConvertWordToNumber
        }
        let max = wordScores |> Seq.max
        let triangleNumbers = triangleNumberSequence |> Seq.takeWhile (fun x -> x <= max)
        let wordNumbers = wordScores |> Seq.toArray
        let mutable counter = 0
        for i in 1 .. (wordNumbers.Length - 1) do
            let word = wordNumbers.[i]
            if triangleNumbers |> Seq.contains word then counter <- counter + 1 
        counter