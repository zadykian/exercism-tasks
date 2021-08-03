module NucleotideCount

let inline private (@) func x = func x

let private tryAdd key value map =
    match Map.tryFind key map with
    | Some _ -> map
    | None   -> Map.add key value map

let nucleotideCountsUnsafe (strand: string): Map<char, int> =
    strand
    |> Seq.groupBy id
    |> Seq.map @ fun (key, chars) -> (key, chars |> Seq.length)
    |> Map.ofSeq
    |> tryAdd 'A' 0
    |> tryAdd 'T' 0
    |> tryAdd 'G' 0
    |> tryAdd 'C' 0

let nucleotideCounts (strand: string): Option<Map<char, int>> =
    let validate char = ['A'; 'T'; 'G'; 'C'] |> Seq.contains char
    if Seq.exists (validate >> not) strand then None
    else Some @ nucleotideCountsUnsafe strand