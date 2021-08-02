module Hamming

let inline private (@) func x = func x

let private distanceUnsafe (strand1: string) (strand2: string): int =
    strand1
    |> Seq.zip strand2
    |> Seq.filter @ fun (l, r) -> l <> r
    |> Seq.length

let distance (strand1: string) (strand2: string): int option =
    if strand1.Length <> strand2.Length
    then None
    else Some @ distanceUnsafe strand1 strand2