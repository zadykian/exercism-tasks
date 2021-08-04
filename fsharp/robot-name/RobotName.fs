module RobotName

type RobotName = string

type Robot = { Name: RobotName }

let private random = System.Random ()

let private generateName (): RobotName =
    let chars = seq { for char in 'A'..'Z' -> char } |> Seq.toArray
    let randomChar () = chars.[random.Next chars.Length]
    let randomDigit () = random.Next 10
    $"{randomChar ()}{randomChar ()}{randomDigit ()}{randomDigit ()}{randomDigit ()}"

let mkRobot (): Robot = { Name = generateName () }

let name (robot: Robot): string = robot.Name

let reset (robot: Robot): Robot = { robot with Name = generateName () }