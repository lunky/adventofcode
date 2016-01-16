namespace adventofcode

module Day10 =
    let lookNSay(strz: string) = 
        let next (count, c) acc = 
            let tail = List.tail
            match acc with
            | (n,ch)::tail when c=ch -> (n+1,ch)::tail
            | _ -> (1, c)::acc
        strz|> Seq.fold (fun acc c  -> next (1, c) acc) []
        |> List.rev
        |> Seq.collect (fun (n,x) -> sprintf "%d%c" n x ) 
        |> fun c -> System.String.Join("", c) 
