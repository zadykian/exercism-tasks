module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position }

let create (direction: Direction) (position: Position): Robot = failwith "You need to implement this function."

let move (instructions: string) (robot: Robot): Robot = failwith "You need to implement this function."