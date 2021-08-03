module Darts

let inline private (@) func x = func x

/// Darts board which is represented as 'circle radius to score' map.
let private board =
    [
        (1f , 10)
        (5f , 5 )
        (10f, 1 )
    ]

let score (x: double) (y: double): int =
    let distance = float32 @ sqrt @ (pown x 2) + (pown y 2)
    let zone = List.tryFind (fun (radius, _) -> distance <= radius) board
    match zone with
    | Some (_, score) -> score
    | None            -> 0