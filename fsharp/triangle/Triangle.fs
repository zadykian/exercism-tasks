module Triangle

let private tryGetSides triangle =
    match triangle with
    | [fst; snd; trd]
        when (fst + snd > trd
            && snd + trd > fst
            && trd + fst > snd) -> Some (fst, snd, trd)
    | _ -> None

let equilateral (triangle: float list) =
    match tryGetSides triangle with
    | Some (fst, snd, trd) -> fst = snd && snd = trd
    | None                 -> false

let isosceles (triangle: float list) =
    match tryGetSides triangle with
    | Some (fst, snd, trd) -> fst = snd || snd = trd || trd = fst
    | None                 -> false

let scalene (triangle: float list) =
    match tryGetSides triangle with
    | Some (fst, snd, trd) -> fst <> snd && snd <> trd && trd <> fst
    | None                 -> false