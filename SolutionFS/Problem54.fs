namespace Solution

module Problem54 =

    type Quality =
        | HighCard =       1  // Highest value card
        | OnePair =        2  // Two cards of the same value
        | TwoPairs =       3  // Two different pairs
        | ThreeOfAKind =   4  // Three cards of the same value
        | Straight =       5  // All cards are consecutive values
        | Flush =          6  // All cards of the same suit
        | FullHouse =      7  // Three of a kind and a pair
        | FourOfAKind =    8  // Four cards of the same value
        | StraightFlush =  9  // All cards are consecutive values of same suit
        | RoyalFlush =    10  // Ten, Jack, Queen, King, Ace, in same suit.

    type Value =
        | Two =     2
        | Three =   3
        | Four =    4
        | Five =    5
        | Six =     6
        | Seven =   7
        | Eight =   8
        | Nine =    9
        | Ten =    10
        | Jack =   11
        | Queen =  12
        | King =   13
        | Ace =    14

    type Suit = Diamonds | Spades | Hearts | Clubs

    let parseCard (card : string) = 
        if card.Length <> 2 then failwith "Card expected to be a string of length two." 
        let value = 
            match card.[0] with
                | '2' -> Value.Two
                | '3' -> Value.Three
                | '4' -> Value.Four
                | '5' -> Value.Five
                | '6' -> Value.Six
                | '7' -> Value.Seven
                | '8' -> Value.Eight
                | '9' -> Value.Nine
                | 'T' -> Value.Ten
                | 'J' -> Value.Jack
                | 'Q' -> Value.Queen
                | 'K' -> Value.King
                | 'A' -> Value.Ace
                | _   -> failwith "Unknown card value."

        let suit =
            match card.[1] with
                | 'D' -> Suit.Diamonds
                | 'S' -> Suit.Spades
                | 'H' -> Suit.Hearts
                | 'C' -> Suit.Clubs
                | _   -> failwith "Unknown card suit."

        (value, suit)

    let parseHand (hand : string[]) =
        if hand |> Array.length <> 5 then failwith "Hand expected to be a string array of length two."
        if hand |> Array.map (fun x -> x.Length) |> Array.forall (fun x -> x <> 2) then failwith "All cards in hand expected to be strings of length two."
        hand |> Array.map (parseCard)

    let getValues (hand : (Value * Suit)[]) =
        hand |> Array.map (fst)

    let getSuits (hand : (Value * Suit)[]) =
        hand |> Array.map (snd)

    let isStraight (hand : (Value * Suit)[]) =
        hand |> getValues |> Array.sort |> Array.pairwise |> Array.forall (fun a -> 1 + LanguagePrimitives.EnumToValue (fst a) = LanguagePrimitives.EnumToValue (snd a))

    let isFlush (hand : (Value * Suit)[]) =
        hand |> getSuits |> Array.pairwise |> Array.forall (fun a -> fst a = snd a)

    let isRoyalFlush (hand : (Value * Suit)[]) =
        let royal = [| Value.Ten; Value.Jack; Value.Queen; Value.King; Value.Ace |]
        let sortedHand = hand |> getValues |> Array.sort
        (Array.compareWith Operators.compare royal sortedHand) = 0 && isFlush hand

    let containsDuplicateCards (hand : (Value * Suit)[]) count rep =
        hand |> getValues |> Array.groupBy (id) |> Array.map (fun x -> Array.length (snd x)) |> Array.filter (fun l -> l = count) |> Array.length = rep

    let getQuality (hand : (Value * Suit)[]) =
        let quality =
            if isRoyalFlush hand then Quality.RoyalFlush
            elif isStraight hand && isFlush hand then Quality.StraightFlush
            elif containsDuplicateCards hand 4 1 then Quality.FourOfAKind
            elif containsDuplicateCards hand 3 1 && containsDuplicateCards hand 2 1 then Quality.FullHouse
            elif isFlush hand then Quality.Flush
            elif isStraight hand then Quality.Straight
            elif containsDuplicateCards hand 3 1 then Quality.ThreeOfAKind
            elif containsDuplicateCards hand 2 2 then Quality.TwoPairs
            elif containsDuplicateCards hand 2 1 then Quality.OnePair
            else Quality.HighCard
        quality

    // sort by frequency then by value, largest first (decreasing)
    let getSortedValues (hand : (Value * Suit)[]) =
        hand |> getValues |> Array.groupBy (id) |> Array.sortByDescending (fun x -> Array.length(snd x), fst x) |> Array.map (fst)

    type CanonicalHand (name : string, quality : Quality, values : Value[]) = 
        member this.Name = name
        member this.Quality = quality
        member this.Values = values

    let getWinner (a : CanonicalHand) (b : CanonicalHand) =
        let x = a.Values
        let y = b.Values
        let index = min x.Length y.Length

        let rec f (x : Value[]) (y : Value[]) i max = 
            if i > max then failwith "Both hands are identical."
            elif x.[i] > y.[i] then a
            elif x.[i] < y.[i] then b
            else f x y (i+1) max
        
        let winner =
            if a.Quality > b.Quality then a
            elif a.Quality < b.Quality then b
            else f x y 0 index
        
        winner.Name

    let solution () =
        let filePath = "../../../../SolutionFS/Data/p054_poker.txt" // preprocess file, removed all spaces
        let lines = System.IO.File.ReadAllLines filePath

        let f (l : string) =

            let l1 = [|   l.[0..1];   l.[2..3];   l.[4..5];   l.[6..7];   l.[8..9] |]
            let l2 = [| l.[10..11]; l.[12..13]; l.[14..15]; l.[16..17]; l.[18..19] |]

            let hand1 = l1 |> parseHand
            let quality1 = getQuality hand1
            let values1 = getSortedValues hand1
            let player1 = CanonicalHand("Player1", quality1, values1)

            let hand2 = l2 |> parseHand
            let quality2 = getQuality hand2
            let values2 = getSortedValues hand2
            let player2 = CanonicalHand("Player2", quality2, values2)

            let winner = getWinner player1 player2
            winner

        lines |> Array.map (f) |> Array.filter (fun x -> x = "Player1") |> Array.length