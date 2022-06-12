namespace Solution

module Problem59 =

    let convertToAscii i =
        match i with
        | i when i >= 0 && i < 128 
            -> System.Convert.ToChar i
        | _ 
            -> failwith $"Integer '{i}' out of range."

    let encryptedAsciiNumbers =
        System.IO.File.ReadAllText "../../../../SolutionFS/Data/p059_numbers.txt"
        |> fun s -> s.Split ','
        |> Array.map (fun s -> System.Int32.Parse s)

    let alphabet = "abcdefghijklmnopqrstuvqxyz";

    let triplets =
        seq { for a in alphabet do for b in alphabet do for c in alphabet -> a, b, c }

    let generateKey (triplet : char * char * char) = 
        match triplet with
        | (a, b, c)
            -> [| a; b; c |]
                |> Array.map (fun x -> System.Convert.ToInt32(x))

    let decryptMessage message (key : int[]) =
        message 
        |> Array.mapi (fun i x -> x ^^^ key[i % 3])

    let solution =
        let decriptedAsciiNumbers =
            triplets
            |> Seq.map generateKey
            |> Seq.map (fun key -> decryptMessage encryptedAsciiNumbers key)
            |> Seq.toArray

        let index = 
            decriptedAsciiNumbers
            |> Array.map (fun numbers ->
                numbers
                // The decrypted message with the most spaces (ASCII code = 32)
                // is probably the correct decrypted message.
                |> Array.filter (fun number -> number = 32)
                |> Array.length)
            |> Array.mapi (fun i c -> i, c)
            |> Array.maxBy snd
            |> fst

        let key = triplets |> Seq.item index

        let decryptedMessage =
            decriptedAsciiNumbers[index]
            |> Array.map convertToAscii
            |> fun x -> System.String x

        printfn $"Decrypted key: '{key}'."
        printfn $"Decrypted message: {decryptedMessage}"

        decriptedAsciiNumbers |> Array.item index |> Array.sum