// This is the file you need to modify for your own solution.
// The unit tests will use this code, and it will be used by the benchmark tests
// for the "Mine" row of the summary table.

// Remember to not only run the unit tests for this exercise, but also the
// benchmark tests using `dotnet run -c Release`.
// Please refer to the instructions for more information about the benchmark tests.

module TreeBuilding

open TreeBuildingTypes

type Tree =
    | Branch of int * Tree list
    | Leaf of int

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
    let rootOption = List.tryFind (fun record -> record.RecordId = record.ParentId) records
    match rootOption with
    | Some root -> buildForRoot records root.RecordId
    | None      -> invalidArg (nameof records) "records list does not contain root!"