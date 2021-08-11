module PhoneNumber

open FParsec

/// String parser without user state.
type private StrParser = Parser<string, unit>

let private countryCodeParser : StrParser = pstring "+1" <|> pstring "1" <|> pstring ""

let private parser : Parser<uint64, unit> = failwith "not implemented!"

let clean (input: string): Result<uint64, string> =
    match run parser input with
    | Success (num, _, _) -> Result.Ok    num
    | Failure (msg, _, _) -> Result.Error msg