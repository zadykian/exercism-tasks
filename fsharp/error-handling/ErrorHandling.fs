module ErrorHandling

open System

let handleErrorByThrowingException() = "failed!" |> Exception |> raise

let handleErrorByReturningOption (input: string): int option =
    match Int32.TryParse input with
    | true,  intValue -> Some intValue
    | false, _        -> None

let handleErrorByReturningResult (input: string): Result<int, string> =
    match Int32.TryParse input with
    | true,  intValue -> Ok intValue
    | false, _        -> Error "Could not convert input to integer"

let bind
    (switchFunction: 'TOk -> Result<'TOk, 'TError>)
    (twoTrackInput: Result<'TOk, 'TError>): Result<'TOk, 'TError> =
    match twoTrackInput with
    | Ok ok       -> switchFunction ok
    | Error error -> Error error

let cleanupDisposablesWhenThrowingException (resource: IDisposable) =
    try
        handleErrorByThrowingException ()
    finally
        resource.Dispose ()