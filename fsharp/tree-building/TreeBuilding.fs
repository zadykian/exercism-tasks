﻿// This is the file you need to modify for your own solution.
// The unit tests will use this code, and it will be used by the benchmark tests
// for the "Mine" row of the summary table.

// Remember to not only run the unit tests for this exercise, but also the
// benchmark tests using `dotnet run -c Release`.
// Please refer to the instructions for more information about the benchmark tests.

module TreeBuilding

open System
open TreeBuildingTypes

type Tree =
    | Branch of int * Tree list
    | Leaf of int

type ValidationMessage = string

let recordId t =
    match t with
    | Branch (id, _) -> id
    | Leaf id        -> id

let isBranch t =
    match t with
    | Branch _ -> true
    | Leaf _   -> false

let children t =
    match t with
    | Branch (_, c) -> c
    | Leaf _        -> []

let private rules =
    [
        (
            (fun records -> (records
                             |> Seq.filter (fun r -> r.RecordId = r.ParentId)
                             |> Seq.length
                             |> ((=) 1))),
            "there are not exactly one root-like record!"
        )

        (
            (fun (records: Record list) ->
                List.forall
                    (fun record -> record.RecordId < records.Length && record.RecordId >= record.ParentId)
                    records),
            "at least one record contains value which exceeds records count!"
        )
    ]

let private validate (records: Record list): Result<unit, ValidationMessage> =

    let failedRules =
        rules
        |> Seq.filter (fun (validationFunc, _) -> validationFunc records |> not)
        |> Seq.toArray

    if Seq.isEmpty failedRules
    then Ok ()
    else Error (failedRules |> Seq.fold (fun res (_, msg) -> res + Environment.NewLine + msg) String.Empty)

let rec private buildForRoot (records: Record list) (rootId: int): Tree =
    let children =
        records
        |> Seq.filter (fun record -> record.RecordId <> rootId && record.ParentId = rootId)
        |> Seq.map (fun record -> buildForRoot records record.RecordId)
        |> Seq.toList

    if Seq.isEmpty children
    then Leaf rootId
    else Branch (rootId, children)

let buildTree (records: Record list): Tree =

    let ordered = records |> List.sortBy (fun record -> record.RecordId)

    let buildTree () = buildForRoot ordered (List.head ordered).RecordId

    match validate ordered with
    | Ok _          -> buildTree ()
    | Error message -> failwith message 