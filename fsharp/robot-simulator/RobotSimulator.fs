module RobotSimulator

type Direction = North | East | South | West

type Position = int * int

type Robot = { direction: Direction; position: Position }

type Instruction =
    | TurnRight
    | TurnLeft
    | Advance

let parseInstruction (inputChar: char): Instruction =
    match inputChar with
    | 'R' -> TurnRight
    | 'L' -> TurnLeft
    | 'A' -> Advance
    | _   -> invalidArg (nameof inputChar) "Invalid input character."

let turnRight (direction: Direction): Direction =
    

let applyToRobot (robot: Robot) (instruction: Instruction): Robot =
    match instruction with
    | TurnRight -> 

let create (direction: Direction) (position: Position): Robot =
    {
        direction = direction
        position = position
    }

let move (instructions: string) (robot: Robot): Robot =
    instructions
    |> Seq.map parseInstruction