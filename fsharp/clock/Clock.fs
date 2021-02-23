module Clock

type Clock = { TotalMinutes: uint16 }

let midnight: Clock = { TotalMinutes = 0us }

let add (minutes: int) (clock: Clock): Clock =
    let newTotalMinutes: int = ((int) clock.TotalMinutes) + minutes

    { TotalMinutes =
          if   newTotalMinutes >= 1440 then (uint16) (newTotalMinutes % 1440)
          elif newTotalMinutes < 0     then (uint16) (1440 + newTotalMinutes % 1440)
          else                              (uint16) newTotalMinutes }

let subtract (minutes: int) = add (-minutes)

let create (hours: int) (minutes: int): Clock =
    let inputMinutes: int = hours * 60 + minutes
    add inputMinutes midnight

let display (clock: Clock): string =
    let hours   = clock.TotalMinutes / 60us
    let minutes = clock.TotalMinutes % 60us
    $"%02i{hours}:%02i{minutes}"