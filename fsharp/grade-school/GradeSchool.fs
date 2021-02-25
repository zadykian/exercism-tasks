module GradeSchool

open System.Collections.Generic

type Grade = KeyValuePair<int, string list>
type School = Map<int, string list>

let empty: School = Map.empty

let add (student: string) (grade: int) (school: School): School =

    let addStudentTo (gradeList : string list): string list =
        (student :: gradeList)
            |> Seq.sort
            |> Seq.toList

    let gradeChangeFunction =
        function
        | Some gradeList -> Some (addStudentTo gradeList)
        | None           -> Some [student]

    school.Change(grade, gradeChangeFunction)
        |> Seq.sortBy (fun (pair: Grade) -> pair.Key)
        |> Seq.map (fun key -> (key.Key, key.Value))
        |> Map.ofSeq

let roster (school: School): string list =
    school
        |> Seq.collect (fun (pair: Grade) -> pair.Value)
        |> Seq.toList

let grade (number: int) (school: School): string list =
    match school.TryFind(number) with
    | Some gradeList -> gradeList
    | None           -> []
