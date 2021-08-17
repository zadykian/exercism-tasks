module PerfectNumbers

type Classification = Perfect | Abundant | Deficient 

let private getPrimeFactors (number: uint): uint seq = failwith "not implemented!"

let private classifyUnsafe (number: uint): Classification =
    let aliquotSum =
        number
        |> getPrimeFactors
        |> Seq.filter ((<>) number)
        |> Seq.sum

    if aliquotSum = number   then Perfect
    elif aliquotSum > number then Abundant
    else Deficient

let classify number : Classification option =
    if number > 0
    then number |> uint |> classifyUnsafe |> Some
    else None