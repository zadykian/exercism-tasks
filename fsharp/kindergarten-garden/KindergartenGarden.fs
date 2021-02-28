module KindergartenGarden

type Plant =
    | Grass    = 0
    | Clover   = 1
    | Radishes = 2
    | Violets  = 3

let plants (diagram: string) (student: string) : Plant list =
    let studentOffset =
        match student with
        | "Alice"   -> 00
        | "Bob"     -> 02
        | "Charlie" -> 04
        | "David"   -> 06
        | "Eve"     -> 08
        | "Fred"    -> 10
        | "Ginny"   -> 12
        | "Harriet" -> 14
        | "Ileana"  -> 16
        | "Joseph"  -> 18
        | "Kincaid" -> 20
        | "Larry"   -> 22
        | _         -> invalidArg (nameof student) "Unknown student."

    let charToPlant =
        function
        | 'G' -> Plant.Grass
        | 'C' -> Plant.Clover
        | 'R' -> Plant.Radishes
        | 'V' -> Plant.Violets
        | _   -> failwith "Invalid input char."

    (diagram.Split "\n")
        |> Array.toSeq
        |> Seq.toList
        |> Seq.collect (fun row -> row.[studentOffset .. studentOffset + 1])
        |> Seq.toList
        |> Seq.map charToPlant
        |> Seq.toList