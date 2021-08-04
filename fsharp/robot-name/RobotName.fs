module RobotName

open System.Collections.Concurrent

type RobotName = string

type Robot = { Name: RobotName }

let private names = ConcurrentDictionary<RobotName, unit> ()

let private random = System.Random ()

let rec private getRandom (max: byte): byte =
    let value = max |> int |> random.Next
    byte value

let private chars = seq { for char in 'A'..'Z' -> char } |> Seq.toArray

let rec private generateName (): RobotName =
    let randomChar () = chars.[chars.Length |> byte |> getRandom |> int]
    let randomDigit () = getRandom 10uy
    let name = $"{randomChar ()}{randomChar ()}{randomDigit ()}{randomDigit ()}{randomDigit ()}"

    if names.ContainsKey name
    then generateName ()
    else names.[name] <- (); name

let mkRobot (): Robot = { Name = generateName () }

let name (robot: Robot): string = robot.Name

let reset (robot: Robot): Robot =
    names.TryRemove robot.Name |> ignore
    { robot with Name = generateName () }