module ArmstrongNumbers

open System

let private digits (number: int): byte list =
    let lsd (num: int): byte = byte (num % 10)
    
    let rec getWithAcc (num: int) (acc: byte list) =
        if num >= 10 then getWithAcc (num / 10) (lsd num :: acc)
        else (lsd num :: acc)

    getWithAcc number []

let isArmstrongNumber (number: int): bool =
    let digits = digits number

    let summed =
        digits
        |> List.toSeq
        |> Seq.map int
        |> Seq.map (fun num -> pown num digits.Length)
        |> Seq.sum

    summed = number