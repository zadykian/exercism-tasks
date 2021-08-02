module DifferenceOfSquares

/// Get sequence of first {count} natural numbers.
let private naturalNumbers (count: int): int seq =
    seq { for num in 1..count do yield num }

/// Get square of a {number}.
let inline private square number = pown number 2

/// Get square of sum of first {number} natural numbers.
let squareOfSum (number: int): int =
    number
    |> naturalNumbers
    |> Seq.sum
    |> square

/// Get sum of squares of first {number} natural numbers.
let sumOfSquares (number: int): int =
    number
    |> naturalNumbers
    |> Seq.map square
    |> Seq.sum

/// Get difference between square of sum and sum of squares
/// of first {number} natural numbers.
let differenceOfSquares (number: int): int = (squareOfSum number) - (sumOfSquares number)