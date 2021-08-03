module Pangram

open System

let inline private (@) func x = func x

let isPangram (input: string): bool =
    seq { for char in 'a'..'z' -> char }
    |> Seq.forall @ fun char -> input.Contains(char, StringComparison.InvariantCultureIgnoreCase)