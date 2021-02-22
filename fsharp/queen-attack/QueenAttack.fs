module QueenAttack

let create (position: int * int) =
    let inRange value = value >= 0 && value <= 7
    let row, column = position

    inRange row && inRange column

let canAttack (queen1: int * int) (queen2: int * int) =
    let firstRow, firstColumn = queen1
    let secondRow, secondColumn = queen2

    firstRow = secondRow
    || firstColumn = secondColumn
    || abs (secondRow - firstRow) = abs (secondColumn - firstColumn) 