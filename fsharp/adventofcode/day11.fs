namespace adventofcode

open System.Text.RegularExpressions

module Day11 =
    
    let alphabet = Seq.toList "abcdefghijklmnopqrstuvwxyz"
    let incChar (input: char) =
        match input with
        | a when a='z' -> 'a'
        |_ -> alphabet.[List.findIndex (fun alpha -> alpha=input) alphabet+1]

    let implode (xs:char list) =
        let sb = System.Text.StringBuilder(xs.Length)
        xs |> List.iter (sb.Append >> ignore)
        sb.ToString()

    let rec incSeries (input: string) =
        let rev = List.rev( Seq.toList input )
        let tail = List.tail rev 
        let newhead = incChar( List.head rev )
        if (newhead = 'a') then
           List.rev( newhead::List.rev (incSeries( implode( List.rev tail ))) )
        else
            List.rev (newhead::tail)

     
    let passesComplexityRules (input: string) = 
        let n = Regex.Match(input, "abc|bcd|cde|def|efg|fgh|ghi|hij|ijk|jkl|klm|lmn|mno|nop|opq|pqr|qrs|rst|stu|tuv|uvw|vwx|wxy|xyz") in
        let m = Regex.Match(input, "^[^iol]*$") in
        let o = Regex.Matches(input, "(?:(\w)\1)") |> Seq.cast
        let p = Seq.toList (Seq.distinct o)

        m.Success && n.Success && true  && p.Length >= 2


    let rec getNextPassword (input: string) = 
        let next = incSeries input 
        if passesComplexityRules(  implode next ) then
           next
        else  getNextPassword( implode next )
