module AffineCipher

open System

let inline private (@) func x = func x

let private letters = ['a' .. 'z'] |> List.toArray

let private failIfNotCoPrime a =

    let isCoPrime: bool =
        let rec gcd x y = if y = 0 then x else gcd y (x % y)

        let aToSize = gcd a letters.Length = 1
        let sizeToA = gcd letters.Length a = 1
        aToSize && sizeToA

    if not isCoPrime
    then raise @ invalidArg (nameof a) $"'{nameof a}' value is not mutually prime with alphabet size ({letters.Length})"

let private mmi (a: int) (n: int) =
    let rec loop t r newt newr =
        match newr with
        | 0 -> if r > 1 then failwith "a is not invertible"
               else
                   if t < 0 then t + n
                   else t
        | _ -> loop newt newr (t - (r / newr) * newt) (r - (r / newr) * newr)
    loop 0 n 1 a

let private decodeChar a b char =

    let encodedCharIndex () = Array.findIndex ((=) char) letters

    let decodedDefault () = ((mmi a letters.Length) * (encodedCharIndex () - b)) % letters.Length

    let decodedCharIndex () =

        match encodedCharIndex () with
        | i when i > b -> decodedDefault ()
        | _ -> decodedDefault () + letters.Length

    if Char.IsDigit char
    then char
    else letters[decodedCharIndex ()]

let decode (a: int) (b: int) (cipheredText: string) : string =
    failIfNotCoPrime a

    cipheredText
    |> String.filter @ (<>) ' '
    |> String.map (decodeChar a b)

let private encodeChar (a: int) (b: int) (char: char): char =
    let plainCharIndex () = Array.findIndex ((=) char) letters
    let encodedCharIndex () = (a * plainCharIndex () + b) % letters.Length

    if Char.IsDigit char
    then char
    else letters[encodedCharIndex ()]

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
