module ScrabbleScore

let private letterScores: Map<Set<char>, byte> = failwith ""

let private getScore (char: char): byte = failwith ""

let score (word: string): uint =
    word
    |> Seq.map (getScore >> uint)
    |> Seq.sum