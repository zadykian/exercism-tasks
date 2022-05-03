module AffineCipher

open System

let inline private (@) func x = func x

let private alphabetSize = 26

let private failIfNotCoPrime a =

    let isCoPrime: bool =
        let rec gcd x y = if y = 0 then x else gcd y (x % y)

        let aToSize = gcd a alphabetSize = 1
        let sizeToA = gcd alphabetSize a = 1
        aToSize && sizeToA

    if not isCoPrime
    then raise @ invalidArg (nameof a) $"'{nameof a}' value is not mutually prime with alphabet size ({alphabetSize})"

let private letters = ['a' .. 'z'] |> List.toArray

let private decodeChar a b char = failwith "not implemented!"

let decode (a: int) (b: int) (cipheredText: string) : string =
    failIfNotCoPrime a

    cipheredText
    |> String.filter @ (<>) ' '
    |> String.map (decodeChar a b)

let private encodeChar (a: int) (b: int) (char: char): char =
    let charIndex () = Array.findIndex ((=) char) letters
    let encodedIndex () = (a * charIndex () + b) % alphabetSize

    if Char.IsDigit char
    then char
    else letters[encodedIndex ()]

let encode (a: int) (b: int) (plainText: string): string =
    failIfNotCoPrime a

    let asChunkedString (chars: seq<char>): string =
        chars
        |> Seq.chunkBySize 5
        |> Seq.map String
        |> String.concat " "

    plainText
    |> Seq.filter (fun c -> Char.IsDigit c || Char.IsLetter c)
    |> Seq.map (Char.ToLower >> (encodeChar a b))
    |> asChunkedString
