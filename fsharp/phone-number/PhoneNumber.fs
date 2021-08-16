module PhoneNumber

open System
open System.Text.RegularExpressions

let private parseRefined (refined: string) =
    let areaCodeFst     = refined.[0] |> string |> Byte.Parse
    let exchangeCodeFst = refined.[3] |> string |> Byte.Parse

    if   areaCodeFst     = 0uy then Error "area code cannot start with zero"
    elif areaCodeFst     = 1uy then Error "area code cannot start with one"
    elif exchangeCodeFst = 0uy then Error "exchange code cannot start with zero"
    elif exchangeCodeFst = 1uy then Error "exchange code cannot start with one"
    else                            Ok (uint64 refined)

let clean (input: string): Result<uint64, string> =
    let refined = Regex.Replace(input, @"(^(\+?)1)|\s+|\(|\)|\.|\-", "")

    if   refined |> Seq.exists Char.IsPunctuation    then Error "punctuations not permitted"
    elif refined |> Seq.exists Char.IsLetter         then Error "letters not permitted"
    elif refined |> Seq.exists (Char.IsDigit >> not) then Error "invalid characters"
    elif refined.Length = 11                         then Error "11 digits must start with 1"
    elif refined.Length > 11                         then Error "more than 11 digits"
    elif refined.Length < 10                         then Error "incorrect number of digits"
    else refined |> parseRefined