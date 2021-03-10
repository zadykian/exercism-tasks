module PigLatin

type Word =
    | Translated of string
    | Untranslated of string

let private translateIfSatisfies (predicate: string -> bool) (translator: string -> string) (word: Word): Word =

    match word with
    | Translated translated -> Translated translated
    | Untranslated untranslated ->
        if predicate untranslated
        then Translated   (translator untranslated)
        else Untranslated untranslated

let startsWithVowelSound (word: string): bool =
    match word |> Seq.toList with
    | fst :: (snd :: _) ->
        [ 'a'; 'e'; 'i'; 'o'; 'u' ] |> Seq.contains fst
        || ["xr"; "yt"] |> Seq.contains $"{fst}{snd}" 
    | _ -> false

let tryGetConsonantFromBeginning (word: string): string option =
    
    let consonantTrigraphs =
        [
            "nth"; "sch"; "scr"; "shr"; "spl"
            "spr"; "squ"; "str"; "thr"
        ]

    let consonantDigraphs =
        [
            "bl"; "br"; "ch"; "ck"; "cl"; "cr"; "dr"; "fl"
            "fr"; "gh"; "gl"; "gr"; "ng"; "ph"; "pl"; "pr"
            "qu"; "rh"; "sc"; "sh"; "sk"; "sl"; "sm"; "sn"
            "sp"; "st"; "sw"; "th"; "tr"; "tw"; "wh"; "wr"
        ]

    let consonantLetters =
        [
            "b"; "c"; "d"; "f"; "g"; "h"; "j"; "k"
            "l"; "m"; "n"; "p"; "q"; "r"; "s"; "t"
            "v"; "w"; "x"; "y"; "z"
        ]

    [ consonantTrigraphs; consonantDigraphs; consonantLetters ]
        |> Seq.concat 
        |> Seq.tryFind word.StartsWith

let private translateWord (inputWord: string): string =
    let handledWord =
        inputWord
        |> Untranslated
        |> translateIfSatisfies startsWithVowelSound (fun w -> $"{w}ay")
        |> translateIfSatisfies
            (fun w -> (tryGetConsonantFromBeginning w).IsSome)
            (fun w ->
                match tryGetConsonantFromBeginning w with
                | Some consonant -> w.Replace(consonant, "") + consonant + "ay"
                | None -> w)

    match handledWord with
    | Translated word -> word
    | Untranslated word -> word

let translate (input: string): string =
    input.Split(' ')
    |> Seq.map translateWord
    |> String.concat " "