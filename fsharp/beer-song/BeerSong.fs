module BeerSong

let intersperse (item: 'T) (sequence: seq<'T>): seq<'T> =
    sequence
    |> Seq.collect (fun currentItem -> [item; currentItem])
    |> Seq.mapi (fun index item -> index, item)
    |> Seq.choose (fun (index, item) -> if index = 0 then None else Some item)

let singleVerse (bottlesCount: int): seq<string> =
    let asString (bottlesLeft: int) =
        match bottlesLeft with
        | x when x > 1 -> $"{x} bottles"
        | x when x = 1 -> $"{x} bottle"
        | _ -> "no more bottles"

    let whatToTake = if bottlesCount = 1 then "it" else "one"

    let verse =
        if bottlesCount > 0
        then
            [ $"{asString bottlesCount} of beer on the wall, {asString bottlesCount} of beer."
              $"Take {whatToTake} down and pass it around, {asString (bottlesCount - 1)} of beer on the wall." ]
        else
            [ "No more bottles of beer on the wall, no more bottles of beer."
              "Go to the store and buy some more, 99 bottles of beer on the wall." ]

    verse |> List.toSeq

let recite (startBottles: int) (takeDown: int): string list =
    seq { (startBottles + 1 - takeDown) .. startBottles }
    |> Seq.rev
    |> Seq.map singleVerse
    |> intersperse (List.toSeq [""])
    |> Seq.collect id
    |> Seq.toList