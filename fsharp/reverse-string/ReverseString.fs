module ReverseString

open System

/// Reverse {input} string.
let reverse (input: string): string =
    input
    |> Seq.rev
    |> Seq.toArray
    |> String