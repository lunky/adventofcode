namespace adventofcode
open System.Text.RegularExpressions
open FSharp.Data

module Day12 =

    let hasRed (el : (string * JsonValue)[]) =
        Array.exists (fun (kye, value) -> 
        match value with
        | JsonValue.String s when s = "red" -> true
        | _ -> false ) el 
        
    let rec sum  (el : JsonValue) =
        match el with
            | JsonValue.Number n -> int n
            | JsonValue.Record r -> Seq.sumBy (fun (key, value) -> sum  value) r
            | JsonValue.Array a ->  Seq.sumBy (fun e -> sum e) a
            | _ -> 0

    let rec sumNoRed  (el : JsonValue) =
        match el with
            | JsonValue.Number n -> int n
            | JsonValue.Record r when not (hasRed r) -> Seq.sumBy (fun (key, value) -> sumNoRed  value) r
            | JsonValue.Array a ->  Seq.sumBy (fun e -> sumNoRed e) a
            | _ -> 0

    let sumNumbersFromJson (input: string) = 
        let json = JsonValue.Parse (input)
        let resp = sum json
        printfn "All numbers:    %d" resp
        resp

    let sumNoRedNumbersFromJson (input: string) = 
        let json = JsonValue.Parse (input)
        let resp = sumNoRed json
        printfn "No Red numbers: %d" resp
        resp