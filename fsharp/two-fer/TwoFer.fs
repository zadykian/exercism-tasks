module TwoFer

let twoFer (input: string option): string =
    let inputName (): string =
        match input with
        | Some name -> name
        | None -> "you"

    $"One for {inputName()}, one for me."