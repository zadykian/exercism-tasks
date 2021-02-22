module Raindrops

open System

let convert (number: int): string =
    let append (textToAppend: string) (divisor: int) (input: string): string =
        if number % divisor = 0 then input + textToAppend else input

    let lastStep (input: string): string =
        if String.IsNullOrWhiteSpace input then number.ToString() else input

    ""
    |> append "Pling" 3
    |> append "Plang" 5
    |> append "Plong" 7
    |> lastStep