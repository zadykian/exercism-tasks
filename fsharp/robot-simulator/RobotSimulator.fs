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
    match direction with
    | North -> East
    | East  -> South
    | South -> West
    | West  -> North

let turnLeft (direction: Direction): Direction =
    match direction with
    | North -> West
    | East  -> North
    | South -> East
    | West  -> South

let advance (robot: Robot): Robot =
    let (x, y) = robot.position
    match robot.direction with
    | North -> { robot with position = (x, y + 1) }
    | East  -> { robot with position = (x + 1, y) }
    | South -> { robot with position = (x, y - 1) }
    | West  -> { robot with position = (x - 1, y) }

let applyToRobot (robot: Robot) (instruction: Instruction): Robot =
    match instruction with
    | TurnRight -> { robot with direction = turnRight robot.direction }
    | TurnLeft  -> { robot with direction = turnLeft  robot.direction }
    | Advance   -> advance robot

let create (direction: Direction) (position: Position): Robot =
    {
        direction = direction
        position = position
    }

let move (instructions: string) (robot: Robot): Robot =
    instructions
    |> Seq.map parseInstruction
    |> Seq.fold applyToRobot robot