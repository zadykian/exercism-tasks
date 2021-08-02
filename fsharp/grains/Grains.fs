module Grains

let (@) func x = func x

let private ifValidDo (func: int -> uint64) (n: int): Result<uint64,string> =
    if (n >= 1 && n <= 64)
    then Ok (func n)
    else Error "square must be between 1 and 64"

let private squareUnsafe (n: int): uint64 = pown 2UL (n - 1)

let square = ifValidDo @ squareUnsafe

let total: Result<uint64,string> =

    let totalCount =
        seq { for num in 1..64 -> num }
        |> Seq.map squareUnsafe
        |> Seq.sum

    Ok totalCount