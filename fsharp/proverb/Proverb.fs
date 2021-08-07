module Proverb

let inline private uncurry func (a, b) = func a b

let inline private (@) func x = func x

let private singleSentence (cause: string) (consequence:string) =
    $"For want of a {cause} the {consequence} was lost."

let private final (cause: string) = $"And all for the want of a {cause}."

let recite (input: string list): string list =
    let causeAndConsequences =
        input
        |> Seq.pairwise
        |> Seq.map @ uncurry singleSentence

    seq {
        yield! causeAndConsequences
        match input with
        | head :: _ -> yield final head
        | _         -> ()
    }
    |> Seq.toList