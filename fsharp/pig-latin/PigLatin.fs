module PigLatin

type Word =
    | Translated of string
    | Untranslated of string

let private translateIfSatisfies
    (predicate: string -> bool)
    (translator: string -> string)
    (word: Word): Word =

    match word with
    | Translated translated     -> Translated translated
    | Untranslated untranslated ->
        if predicate untranslated then Translated (translator untranslated)
        else Untranslated untranslated

let startsWithVowelSound (word: string): bool =
    match word |> Seq.toList with
    | fst :: (snd :: _) -> ['a'; 'e'; 'i'; 'o'; 'u'] |> Seq.contains fst || [fst; snd] = ['x'; 'r']
    | _                 -> false

let tryGetConsonant (word: string): string option = failwith "not implemented!"

let private translateWord (inputWord: string): string =
    let handledWord =
        inputWord
        |> Untranslated
        |> translateIfSatisfies startsWithVowelSound (fun w -> $"{w}ay")

    match handledWord with
    | Translated word   -> word
    | Untranslated word -> word

let translate (input: string): string =
    input.Split(' ')
        |> Seq.map translateWord
        |> String.concat " "