module Grains

let (@) func x = func x

let private ifValidDo (func: int -> uint64) (n: int): Result<uint64,string> =
    if (n >= 1 && n <= 64)
    then Ok (func n)
    else Error "square must be between 1 and 64"

let square = ifValidDo @ fun nw -> 0UL

let total: Result<uint64,string> = failwith "You need to implement this function."