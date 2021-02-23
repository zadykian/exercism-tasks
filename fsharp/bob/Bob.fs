module Bob

type ResponseResult =
    | Responded of string
    | NotResponded of string

let ifNotRespondedDo (func: string -> ResponseResult) (result: ResponseResult) =
    match result with
    | Responded responseText -> Responded responseText
    | NotResponded inputText -> func inputText

let respondIfSatisfies (predicate: string -> bool) (response: string) (input: string) =
    if predicate input
    then Responded response
    else NotResponded input

let allCapitals (input: string) =
    let capitals =
        input
            |> Seq.filter System.Char.IsLetter
            |> Seq.toList

    capitals.Length <> 0
    && capitals |> Seq.forall System.Char.IsUpper

let endsWithQuestionMark =
    Seq.filter (System.Char.IsWhiteSpace >> not)
    >> Seq.tryLast
    >> function
        | Some char -> char = '?'
        | None      -> false

let respondToCalmQuestion =
    respondIfSatisfies
        (fun input -> not (allCapitals input) && (endsWithQuestionMark input))
        "Sure."

let respondToYell =
    respondIfSatisfies
        (fun input -> (allCapitals input) && not (endsWithQuestionMark input))
        "Whoa, chill out!"

let respondToYelledQuestion =
    respondIfSatisfies
        (fun input -> (allCapitals input) && (endsWithQuestionMark input))
        "Calm down, I know what I'm doing!"

let respondToSilence =
    respondIfSatisfies
        (Seq.forall System.Char.IsWhiteSpace)
        "Fine. Be that way!"

let defaultResponse = function
    | Responded responseText -> responseText
    | NotResponded _         -> "Whatever."

let response (input: string): string =
    input
    |> respondToCalmQuestion
    |> ifNotRespondedDo respondToYell
    |> ifNotRespondedDo respondToYelledQuestion
    |> ifNotRespondedDo respondToSilence
    |> defaultResponse
