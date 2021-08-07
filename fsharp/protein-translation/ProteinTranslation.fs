module ProteinTranslation

let inline private (@) func x = func x

/// Codon - sequence of three characters.
type Codon = string

/// Amino acid which is represented by its' name.
type AminoAcid = string

let private codonsToAcids =
    [
        ["AUG"]                     , "Methionine"
        ["UUU"; "UUC"]              , "Phenylalanine"
        ["UUA"; "UUG"]              , "Leucine"
        ["UCU"; "UCC"; "UCA"; "UCG"], "Serine"
        ["UAU"; "UAC"]              , "Tyrosine"
        ["UGU"; "UGC"]              , "Cysteine"
        ["UGG"]                     , "Tryptophan"
    ]

let private toAminoAcid (codon: Codon): AminoAcid =
    codonsToAcids
    |> List.find @ fun (codons, _) -> codons |> List.contains codon
    |> snd

let private isStopCodon (codon: Codon): bool =
    ["UAA"; "UAG"; "UGA"]
    |> List.contains codon

let proteins rna =
    rna
    |> Seq.chunkBySize 3
    |> Seq.map @ Codon
    |> Seq.takeWhile (isStopCodon >> not)
    |> Seq.map toAminoAcid
    |> Seq.toList