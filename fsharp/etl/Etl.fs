module Etl

open System

let inline private (@) func x = func x

let transform (scoresWithLetters: Map<int, char list>): Map<char, int> =
    scoresWithLetters
    |> Map.toSeq
    |> Seq.collect @ fun (score, chars) -> chars |> Seq.map @ fun char -> (Char.ToLower char, score)
    |> Map.ofSeq