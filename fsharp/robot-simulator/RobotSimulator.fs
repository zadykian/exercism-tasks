module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position }

let create (direction: Direction) (position: Position): Robot =
    {
        direction = direction
        position = position
    }

let move (instructions: string) (robot: Robot): Robot = failwith "You need to implement this function."