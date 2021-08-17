module PerfectNumbers

type Classification = Perfect | Abundant | Deficient 

let private (@) func x = func x

let  getFactors (number: uint): uint seq =
    seq { for i in 1u..number -> i }
    |> Seq.filter @ fun i -> number % i = 0u

let private classifyUnsafe (number: uint): Classification =
    let aliquotSum =
        number
        |> getFactors
        |> Seq.filter ((<>) number)
        |> Seq.sum

    if   aliquotSum = number then Perfect
    elif aliquotSum > number then Abundant
    else Deficient

let classify number : Classification option =
    if number > 0
    then number |> uint |> classifyUnsafe |> Some
    else None