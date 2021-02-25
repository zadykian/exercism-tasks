module Clock

type Clock = { TotalMinutes: uint16 }

let midnight: Clock = { TotalMinutes = 0us }

let add (minutes: int) (clock: Clock): Clock =

    let newTotalMinutes: int = ((int) clock.TotalMinutes) + minutes

    let normalizedMinutes =
        if newTotalMinutes >= 0
        then newTotalMinutes % 1440
        else 1440 + newTotalMinutes % 1440

    { TotalMinutes = (uint16) normalizedMinutes }

let subtract (minutes: int) = add (-minutes)

let create (hours: int) (minutes: int): Clock =
    let inputMinutes: int = hours * 60 + minutes
    add inputMinutes midnight

let display (clock: Clock): string =
    let hours   = clock.TotalMinutes / 60us
    let minutes = clock.TotalMinutes % 60us
    $"%02i{hours}:%02i{minutes}"