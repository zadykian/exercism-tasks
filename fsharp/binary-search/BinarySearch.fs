module BinarySearch

type Index = int

let rec find (input: int array) (value: int) : Index option =

    let findUnsafe () =
        let index = input.Length / 2
        let middleValue = input.[index]

        if middleValue < value then
            if   index + 1 >= input.Length then None
            else find input.[index + 1..] value

        elif middleValue > value then
            if   index = 0 then None
            else find input.[..index - 1] value

        else Some index

    if   input.Length = 0 then None
    else findUnsafe ()