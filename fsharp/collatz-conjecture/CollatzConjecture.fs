module CollatzConjecture

let rec private stepsWithCounter (number: uint) (stepsCounter: uint): uint =
    match number with
    | 1u                      -> stepsCounter
    | _ when number % 2u = 0u -> stepsWithCounter (number / 2u) (stepsCounter + 1u)
    | _                       -> stepsWithCounter (3u * number + 1u) (stepsCounter + 1u)

let steps (number: int): int option =
    match number with
    | _ when number > 0 -> Some ((stepsWithCounter (uint number) 0u) |> int)
    | _                 -> None