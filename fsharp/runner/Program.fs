﻿// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open adventofcode
open Day9
open System.IO
open System.Text.RegularExpressions

let runDay9() = 

    
    let citysList  = [
        {city1= "London"; city2= "Dublin"; distance= 464};
        {city1= "London"; city2= "Belfast"; distance= 518};
        {city1= "Dublin"; city2= "Belfast"; distance= 141};
    ]

    shortestDistance citysList |> printfn "%A" 

    let lines = File.ReadAllLines("day9data.txt") |> Array.toList  

    let (|FirstRegexGroup|_|) pattern input =
       let m = Regex.Match(input,pattern) 
       if (m.Success) then Some( m.Groups.[1].Value, m.Groups.[2].Value, m.Groups.[2].Value ) else None 


    let (|Regex|_|) pattern input =
        let m = Regex.Match(input, pattern)
        if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
        else None
 
    let testRegex str = 
        match str with
        | Regex "(.*?) to (.*) = (\d*)" [incity1; incity2; indistance] -> 
            {city1= incity1; city2= incity2; distance= System.Int32.Parse indistance}

    let linz = lines |> List.collect (fun l -> [testRegex l])
    shortestDistance linz |> printfn "Shortest %A" 
    longestDistance linz |> printfn "Longest %A" 
    0


let runDay10() =

    printfn "runDay10"
    let str = ['a'; 'a'; 'a'; 'b'; 'b'; 'c'; 'd'; 'd' ]


    let breakIntoGroups (acc : char list list) c =
        let revAcc = List.rev acc
        let lastElement = List.last acc

        // if the lastElement is empty or it matches the last character added
        if Seq.isEmpty lastElement ||  c = Seq.head lastElement then
            // And add this character at the end
            let likeGroup = lastElement @ [ c ]
            // Finally put this updated group of like characters at the end of our accumulator
            let updatedAcc = likeGroup :: (List.tail revAcc)
            List.rev updatedAcc
        else
            acc @ [ [c] ]

    let words = List.fold breakIntoGroups [ [] ] str

    words |> printfn "final # %A #"

    0

[<EntryPoint>]
let main argv = 
    printfn "entry"
    //runDay9()
    runDay10()
    System.Console.WriteLine("\n~~~ Press Enter ~~~")
    let ignoring = System.Console.ReadLine()
    0 // return an integer exit code