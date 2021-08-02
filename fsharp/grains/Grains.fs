module Grains

let private ifValidDo (n: int) (func: int -> uint64): Result<uint64,string> =
    if (n >= 1 && n <= 64)
    then Ok (func n)
    else Error "square must be between 1 and 64"

let square (n: int): Result<uint64,string> =
    if (n >= 1 && n <= 64)
    then Ok 0UL
    else Error "square must be between 1 and 64"

let total: Result<uint64,string> = failwith "You need to implement this function."