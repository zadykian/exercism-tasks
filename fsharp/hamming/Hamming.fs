module Hamming

let inline private (@) func x = func x

let private distanceNonEmpty (strand1: string) (strand2: string): int =
    failwith "not implemented!"

let distance (strand1: string) (strand2: string): int option =
    match (strand1, strand2) with
    | "", "" -> Some 0
    | _ , "" -> None
    | "", _  -> None
    | _ , _  -> Some @ distanceNonEmpty strand1 strand2