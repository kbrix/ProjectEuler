namespace Solution

module Problem42 =
    
    let filePath = "../../../../Solution/Data/p042_words.txt"

    let triangleNumberSequence = 1 |> Seq.unfold (fun n -> Some((n * (n + 1)) / 2, n + 1))

    let solution() =
        
        let wordValues = filePath |> System.IO.File.ReadAllLines |> Array.map (euler.Utility.Miscellaneous.ConvertWordToNumber)

        let maxWordValue = wordValues |> Array.max
        let triangleNumbers = triangleNumberSequence |> Seq.takeWhile (fun x -> x <= maxWordValue) |> Seq.toArray
        
        let mutable counter = 0
        for i in 0 .. (wordValues.Length - 1) do
            let word = wordValues.[i]
            if triangleNumbers |> Seq.contains word then counter <- counter + 1 
        
        counter