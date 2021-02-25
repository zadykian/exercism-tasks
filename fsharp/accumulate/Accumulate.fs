module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =

    let rec accumulateImpl (inputList: 'a list) (acc: 'b list): 'b list =
        match inputList with
        | head :: tail -> accumulateImpl tail (func head :: acc)
        | [] -> acc

    accumulateImpl input [] |> List.rev