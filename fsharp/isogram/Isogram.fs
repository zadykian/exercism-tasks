module Isogram

open System

let inline private (@) func x = func x

let isIsogram (str: string): bool =
    str.ToLower ()
    |> Seq.groupBy id
    |> Seq.filter @ fun (key, _) -> (Char.IsWhiteSpace >> not) key && key <> '-'
    |> Seq.forall @ fun (_, chs) -> chs |> Seq.length = 1