module OcrNumbers

open System

type DigitCell = string list

type DigitRow = DigitCell list

let private intersperse (item: 'T) (sequence: seq<'T>): seq<'T> =
    sequence
    |> Seq.collect (fun currentItem -> [item; currentItem])
    |> Seq.mapi (fun index item -> index, item)
    |> Seq.choose (fun (index, item) -> if index = 0 then None else Some item)

let private parseSingleRow (row: string list): DigitRow = failwith "not implemented!"

let private parseCell (digitCell: DigitCell): char = failwith "not implemented!"

let convert (input: string list): string option =
    let rawDigitRows =
        input
        |> Seq.chunkBySize 4
        |> Seq.map Seq.toList
        |> Seq.toList

    let hasInvalidRows =
        rawDigitRows
        |> Seq.exists (fun row ->
            row |> Seq.length <> 4 ||
            row |> Seq.exists (fun line -> line.Length % 3 <> 0))

    let digitsString =
        rawDigitRows
            |> Seq.map parseSingleRow
            |> Seq.map (Seq.map parseCell)
            |> intersperse (List.toSeq [','])
            |> Seq.collect id
            |> String.Concat

    if hasInvalidRows then None
    else Some digitsString