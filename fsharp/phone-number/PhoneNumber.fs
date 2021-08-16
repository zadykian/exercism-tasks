module PhoneNumber

open FParsec
open System
open System.Text.RegularExpressions

/// String parser without user state.
type private StrParser = Parser<string, unit>

let private isBetween<'T when 'T :> IComparable<'T>>
    (range: 'T * 'T) (value: 'T): bool =
    let leftBound, rightBound = range
    value.CompareTo(leftBound) >= 0 && value.CompareTo(rightBound)  <= 0

let private codeParser : StrParser =
    parse {
        let! codeFirstDigit = digit >>= fun char -> satisfy (isBetween ('2', '9'))
        let! codeEnd = manyMinMaxSatisfy 2 2 isDigit
        return $"{codeFirstDigit}{codeEnd}"
    }

let private parser : Parser<uint64, unit> =
    parse {
        do!  skipAnyOf [' '; '.'; '('; '-']
        let! areaCode = codeParser
        do!  skipAnyOf [' '; '.'; ')'; '-']
        let! exchangeCode = codeParser
        do!  skipAnyOf [' '; '.'; '-']
        let! numberEnd = manyMinMaxSatisfy 4 4 isDigit
        return [areaCode; exchangeCode; numberEnd] |> String.Concat |> uint64
    }

let clean (input: string): Result<uint64, string> =
    let withoutCountryCode = Regex.Replace(input, "^(\+?)1", "")
    match run parser withoutCountryCode with
    | Success (num, _, _) -> Result.Ok    num
    | Failure (msg, _, _) -> Result.Error msg