module SecretHandshake

open System.Collections.Specialized

let private events =
    [
        0b1   , "wink"
        0b10  , "double blink"
        0b100 , "close your eyes"
        0b1000, "jump"
    ]

let private commandsUnsafe (number: byte) =
    let vector = BitVector32(int number)

    let selected =
        events
        |> Seq.filter (fun (mask, _) -> vector.[mask])
        |> Seq.map snd

    let reverse = vector.[0b10000]
    if reverse then selected |> Seq.rev else selected

let commands number =
    if   number < 1 || number > 31
    then []
    else number |> byte |> commandsUnsafe |> Seq.toList