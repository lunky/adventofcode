﻿open adventofcode
open Day9
open Day10
open Day11
open Day12
open Day13
open Day14
open System.IO
open System.Text.RegularExpressions

let runDay12() = 
//    sumNumbersFromJson "[1,[4,5],{\"c\":\"red\",\"b\":2},{\"q\":10}, 3]" 
//    sumNoRedNumbersFromJson "[1,[4,5],{\"c\":\"red\",\"b\":2},{\"q\":10}, 3]" 
    File.ReadAllText("day12data.txt") |> sumNumbersFromJson |> ignore //"[1,[4,5],{\"c\":\"red\",\"b\":2},{\"q\":10}, 3]" 
    File.ReadAllText("day12data.txt") |> sumNoRedNumbersFromJson  |> ignore //"[1,[4,5],{\"c\":\"red\",\"b\":2},{\"q\":10}, 3]" 
    ()

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
        | _ -> raise (System.ArgumentException "Bad syntax")


    let linz = lines |> List.collect (fun l -> [testRegex l])
    shortestDistance linz |> printfn "Shortest %A" 
    longestDistance linz |> printfn "Longest %A" 
    0

let runDay14() =
    printfn "Day14 :" 
    let puzzleValue = 2503
    let rules = File.ReadAllLines("day14data.txt") |> Array.toList 
    let fastest = getFastest rules puzzleValue |> Seq.head
    printfn "*****"
    printfn "Furthest was %d km by %s" (fst fastest) (snd fastest).name
    let results = getWinner rules puzzleValue 
    let (winner,count) = 
        results
        |> Seq.groupBy (fun x->x) |> Seq.sortBy (fun (key,vals) -> -1* Seq.length vals)  
        |> Seq.map (fun (winner,wins) -> winner, (Seq.length wins))
        |> Seq.head 

    printfn "*****"
    printfn "Winner %A with %d wins" winner count

let runDay13() = 
//        File.ReadAllLines("day13data.txt") |> Array.toList |> calculateMostChange |> printfn "response = %A"
        File.ReadAllLines("day13data.txt") |> Array.toList |> calculateMostChangeAddMe |> printfn "response = %A"

let runDay11() = 
    getNextPasswords "hepxcrrq" passesComplexityRules |> Seq.take 2 |> printfn "next: %A"

let runDay1() = 
    getNextPasswords "hepxcrrq" passesComplexityRules |> Seq.take 2 |> printfn "next: %A"

let runDay10() =

    let now = System.DateTime.Now

    let compute acc el =
         let newVal = lookNSay acc
         printfn "%A %d  %A" (System.DateTime.Now.Subtract now) el (Seq.length newVal )
         let acc=newVal
         newVal

    List.fold compute "3113322113" [1..50]
//

[<EntryPoint>]
let main argv = 
    printfn "main => "
//    runDay9()
//    runDay10()
//    runDay11()
//    runDay12()
//    runDay13()
    runDay14()
    System.Console.WriteLine("\n~~~ Press Enter ~~~")
    let ignoring = System.Console.ReadLine()
    0 // return an integer exit code
