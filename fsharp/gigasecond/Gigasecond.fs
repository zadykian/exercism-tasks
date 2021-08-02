module Gigasecond

open System

/// Add one gigasecond to {beginDate}
let add (beginDate: DateTime): DateTime =
    let gigasecond = 1_000_000_000ul
    let timeSpan = TimeSpan.FromSeconds (float gigasecond)
    beginDate + timeSpan