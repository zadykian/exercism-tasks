module RobotName

type RobotName = string

type Robot = { Name: RobotName }

let private generateName (): RobotName = failwith "not implemented!"

let mkRobot (): Robot = { Name = generateName () }

let name (robot: Robot): string = robot.Name

let reset (robot: Robot): Robot = { robot with Name = generateName () }