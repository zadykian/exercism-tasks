module OcrNumbers

type DigitCell = string list

type DigitRow = DigitCell list

let private parseToDigitCells (input: string list): option<DigitRow list> = failwith "not implemented!"

let convert (input: string list): string option = failwith "You need to implement this function."