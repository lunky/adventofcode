namespace adventofcode
open System.Text.RegularExpressions
open FSharp.Data

module Day12 =

    let noRed (el : (string * JsonValue)[]) =
        Seq.exists (fun (kye, value) -> 
        match value with
        | JsonValue.String s when s = "red" -> true
        | _ -> false ) el |> not
        
    let rec sum  (el : JsonValue) =
        match el with
            | JsonValue.Record r -> Seq.sumBy (fun (key, value) -> sum  value) r
            | JsonValue.Array a ->  Seq.sumBy (fun e -> sum e) a
            | JsonValue.Number n -> n
            | _ -> 0M

    let rec sumNoRed  (el : JsonValue) =
        match el with
            | JsonValue.Number n -> int n
            | JsonValue.Record r when (noRed r) -> Seq.sumBy (fun (key, value) -> sumNoRed  value) r
            | JsonValue.Array a ->  Seq.sumBy (fun e -> sumNoRed e) a
            | _ -> 0

    let sumNumbersFromJson (input: string) = 
        let json = JsonValue.Parse (input)
        let resp = sum json
        printfn "All numbers:    %A" resp
        resp

    let sumNoRedNumbersFromJson (input: string) = 
        let json = JsonValue.Parse (input)
        let resp = sumNoRed json
        printfn "No Red numbers: %d" resp
        resp