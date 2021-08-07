module Seq

let keep (pred: 'T -> bool) (xs: 'T seq): 'T seq =
    seq {
        for item in xs do
            if pred item then yield item else ()
    }

let discard (pred: 'T -> bool) (xs: 'T seq): 'T seq =
    seq {
        for item in xs do
            if (pred >> not) item then yield item else ()
    }