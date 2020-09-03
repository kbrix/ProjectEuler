namespace Solution

module Problem45 =
    
    let solution (max: int64) =

        let toSet s = s |> Seq.takeWhile (fun n -> n <= max) |> Set.ofSeq

        //let triangleNumberSet = 
        //    1L 
        //    |> Seq.unfold (fun n -> Some((n * (n + 1L) / 2L), n + 1L)) |> toSet

        let pentagonNumberSet = 
            1L 
            |> Seq.unfold (fun n -> Some((n * (3L * n - 1L) / 2L), n + 1L)) |> toSet

        let hexagonNumberSet = 
            1L 
            |> Seq.unfold (fun n -> Some((n * (2L * n - 1L)), n + 1L)) |> toSet

        let numberSetSequence = seq {
            //yield triangleNumberSet // all hexagon numbers are triangle numbers
            yield pentagonNumberSet
            yield hexagonNumberSet
        }

        let intersection = Set.intersectMany numberSetSequence

        intersection |> Set.maxElement

