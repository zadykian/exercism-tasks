module BinarySearch

type Index = int

let rec private findImpl (offset: int) (input: int array) (value: int) : Index option =

    let findUnsafe () =
        let index = input.Length / 2
        let middleValue = input.[index]

        // go to right if possible
        if middleValue < value then
            if   index + 1 >= input.Length then None
            else findImpl (offset + index + 1) input.[index + 1..] value

        // go to left if possible
        elif middleValue > value then
            if   index = 0 then None
            else findImpl offset input.[..index - 1] value

        else Some (offset + index)

    if   input.Length = 0 then None
    else findUnsafe ()

let find = findImpl 0