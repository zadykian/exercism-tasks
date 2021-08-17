module PerfectNumbers

type Classification = Perfect | Abundant | Deficient 

let private getPrimeFactors (number: uint): uint list =
    let rec getFactor num proposed acc =
        if   proposed = num      then num :: acc
        elif num % proposed = 0u then getFactor (num / proposed) proposed (proposed :: acc)
        else getFactor num (proposed + 1u) acc

    if   number = 1u then [1u]
    else getFactor number 2u []
    
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