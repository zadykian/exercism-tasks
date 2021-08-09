module Sieve

let rec private primesIn (range: int seq): int seq =
    seq {
        for head in Seq.tryHead range |> Option.toList do 
        yield head
        yield! range |> Seq.filter (fun num -> num % head <> 0) |> primesIn
    }

let primes limit =
    seq { for i in [2..limit] -> i }
    |> primesIn
    |> Seq.toList