module PhoneNumber

open System
open System.Text.RegularExpressions

type private acc = Result<byte, string> list

let sequence list =
    let folder result current =
        result
        |> Result.bind (fun list ->
                        match current with
                        | Ok ok -> Ok (Seq.append list [ok])
                        | Error error -> Error error)

    list |> Seq.fold folder (Ok Seq.empty)

let clean (input: string): Result<uint64, string> =
    let refined = Regex.Replace(input, "(^(\+?)1)|\s+|\(|\)\.|-", "")

    let folder (digits: acc) (char: char): acc =
        if Char.IsPunctuation char
        then Error "punctuations not permitted"

    
    let res =
        refined
        |> Seq.fold folder []

    match sequence res with
    | Ok digits -> digits |> Seq.map char |> Seq.toArray |> String |> uint64 |> Ok
    | Error error -> Error error