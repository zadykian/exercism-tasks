﻿module SumOfMultiples

open System

let sum (numbers: int list) (upperBound: int): int =
    let multiplesOf (number: int): seq<int> =
        seq {
            if number = 0 then yield 0
            else for multiplier in 1..Int32.MaxValue -> number * multiplier;
        }
        |> Seq.takeWhile ((>) upperBound)

    numbers
            |> Seq.collect multiplesOf
            |> Seq.distinct
            |> Seq.sum