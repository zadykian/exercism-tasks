module DifferenceOfSquares

/// Get sequence of first {count} natural numbers.
let private naturalNumbers (count: int): int seq =
    seq { for num in 1..count do yield num }

/// Get square of sum of first {number} natural numbers.
let squareOfSum (number: int): int =
    number
    |> naturalNumbers
    |> Seq.sum
    |> (fun num -> pown num 2)

/// Get sum of squares of first {number} natural numbers.
let sumOfSquares (number: int): int =
    number
    |> naturalNumbers
    |> Seq.map (fun num -> pown num 2)
    |> Seq.sum

/// Get difference between square of sum and sum of squares
/// of first {number} natural numbers.
let differenceOfSquares (number: int): int = (squareOfSum number) - (sumOfSquares number)