module ScrabbleScore

let inline private (@) func x = func x

let private letterScores: (Set<char> * byte) list =
    [
        ['a'; 'e'; 'i'; 'o'; 'u'; 'l'; 'n'; 'r'; 's'; 't'], 1uy
        ['d'; 'g']                                        , 2uy
        ['b'; 'c'; 'm'; 'p']                              , 3uy
        ['f'; 'h'; 'v'; 'w'; 'y']                         , 4uy
        ['k']                                             , 5uy
        ['j'; 'x']                                        , 8uy
        ['q'; 'z']                                        , 10uy
    ]
    |> Seq.map @ fun (chars, score) -> (chars |> Set, score)
    |> Seq.toList

let private getScore (char: char): byte =
    let lower = char |> System.Char.ToLower
    let _, score = letterScores |> List.find (fun (chars, _) -> chars |> Set.contains lower)
    score

let score (word: string): int =
    word
    |> Seq.map (getScore >> int)
    |> Seq.sum