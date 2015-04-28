module StreamStuff

open System
open System.IO

let streamReaderUnfold (sr : StreamReader) = 
    match sr.ReadLine() with
    | str when str = null -> 
        sr.Dispose()
        None
    | str when str.Length = 0 -> 
        sr.Dispose()
        None
    | str when str.Length = 1 && Char.IsControl(str.[0]) -> 
        sr.Dispose()
        None
    | str -> Some(str, sr)

let loadLines (stream : Stream) = 
    stream
    |> (fun stdIn -> new StreamReader(stdIn))
    |> Seq.unfold streamReaderUnfold

