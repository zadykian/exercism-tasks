module NucleotideCount

let inline private (>>=) r f = Option.bind f r

let private rtn v = Some v

let private sequenceList ls =
    let folder head tail = head >>= (fun h -> tail >>= (fun t -> h::t |> rtn))
    List.foldBack folder ls (rtn List.empty)

let nucleotideCounts (strand: string): Option<Map<char, int>> =

    let groupToOption (key, chars) =
        if ['A'; 'T'; 'G'; 'C'] |> Seq.contains key
        then Some (key, chars |> Seq.length)
        else None

    strand
    |> Seq.groupBy id
    |> Seq.map groupToOption
    |> Seq.toList
    |> sequenceList
    >>= (Map.ofList >> Some)