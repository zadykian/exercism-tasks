module GradeSchool

open System.Collections.Generic

type Grade = KeyValuePair<int, string list>
type School = Map<int, string list>

let empty: School = Map.empty

let add (student: string) (grade: int) (school: School): School =    
    let gradeChangeFunction =
        function
        | Some gradeList -> Some (student :: gradeList)
        | None           -> Some [student]

    school.Change(grade, gradeChangeFunction)
let roster (school: School): string list =
    school
        |> Seq.sortBy (fun (pair: Grade) -> pair.Key)
        |> Seq.collect (fun (pair: Grade) -> Seq.sort pair.Value)
        |> Seq.toList

let grade (number: int) (school: School): string list =
    match school.TryFind(number) with
    | Some gradeList -> gradeList
    | None           -> []
