module PigLatin

type Word = string

let private translateWord (word: Word): Word = failwith "not implemented!"

let translate (input: string): string =
    input.Split(' ')
        |> Seq.map translateWord
        |> String.concat " "