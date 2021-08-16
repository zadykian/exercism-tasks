module PhoneNumber

open System
open System.Text.RegularExpressions

let areaCodeFst     (refined: string): byte = refined.[0] |> string |> Byte.Parse

let exchangeCodeFst (refined: string): byte = refined.[3] |> string |> Byte.Parse

let private rules: ((string -> bool) * string) list =
    [
        (fun r -> r |> Seq.exists Char.IsPunctuation   ), "punctuations not permitted"
        (fun r -> r |> Seq.exists Char.IsLetter        ), "letters not permitted"
        (fun r -> r |> Seq.exists (Char.IsDigit >> not)), "invalid characters"
        (fun r -> r.Length = 11                        ), "11 digits must start with 1"
        (fun r -> r.Length > 11                        ), "more than 11 digits"
        (fun r -> r.Length < 10                        ), "incorrect number of digits"
        (fun r -> r |> areaCodeFst     = 0uy           ), "area code cannot start with zero"
        (fun r -> r |> areaCodeFst     = 1uy           ), "area code cannot start with one"
        (fun r -> r |> exchangeCodeFst = 0uy           ), "exchange code cannot start with zero"
        (fun r -> r |> exchangeCodeFst = 1uy           ), "exchange code cannot start with one"
    ]

let clean (input: string): Result<uint64, string> =
    let refined = Regex.Replace(input, @"(^(\+?)1)|\s+|\(|\)|\.|\-", "")
    match rules |> List.tryFind (fun tuple -> refined |> (fst tuple)) with
    | Some (_, error) -> Error error
    | None            -> Ok (uint64 refined)