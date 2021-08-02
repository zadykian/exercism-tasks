module RnaTranscription

let toRna (dna: string): string =

    let replaceNucleotide (char: char) =
        match char with
        | 'G' -> 'C'
        | 'C' -> 'G'
        | 'T' -> 'A'
        | 'A' -> 'U'
        | _   -> invalidArg (nameof char) "invalid nucleotide!"

    dna
    |> Seq.map replaceNucleotide
    |> Seq.toArray
    |> System.String