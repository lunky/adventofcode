// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open adventofcode
open Day9
open System.IO
open System.Text.RegularExpressions

[<EntryPoint>]
let main argv = 

    let citysList  = [
        {city1= "London"; city2= "Dublin"; distance= 464};
        {city1= "London"; city2= "Belfast"; distance= 518};
        {city1= "Dublin"; city2= "Belfast"; distance= 141};
    ]

    shortestDistance citysList |> printfn "%A" 

    let lines = File.ReadAllLines("day9data.txt") |> Array.toList  
    //let items = parseFile lines


    let (|FirstRegexGroup|_|) pattern input =
       let m = Regex.Match(input,pattern) 
       if (m.Success) then Some( m.Groups.[1].Value, m.Groups.[2].Value, m.Groups.[2].Value ) else None 


    let (|Regex|_|) pattern input =
        let m = Regex.Match(input, pattern)
        if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
        else None
 
//    //Example:
//    let phone = "(555) 555-5555"
//    match phone with
//    | Regex @"\(([0-9]{3})\)[-. ]?([0-9]{3})[-. ]?([0-9]{4})" [ area; prefix; suffix ] ->
//    printfn "Area: %s, Prefix: %s, Suffix: %s" area prefix suffix
//    | _ -> printfn "Not a phone number"

         // create a function to call the pattern
    let testRegex str = 
        match str with
        | Regex "(.*?) to (.*) = (\d*)" [incity1; incity2; indistance] -> 
            {city1= incity1; city2= incity2; distance= System.Int32.Parse indistance}

    let linz = lines |> List.collect (fun l -> [testRegex l])
    shortestDistance linz |> printfn "Shortest %A" 
//    shortestRoute linz |> printfn "Shortest %A" 
    longestDistance linz |> printfn "Longest %A" 

    // test
//    for line in linz do
//        printfn "%A" line
//    let ctz = distinctCities citysList 
//    let permutations = citysList |> distinctCities |> getPerms ctz.Length
//
//    let test = citysList |> getPerms ((ctz.Length)-1)   |> printfn "%A" 
  
//    let mapped = getSegments permutations |> List.map (fun segment -> (Seq.map ( fun el -> (cityLookup el citysList) ) segment ))
//
//    for perm in mapped do
//        printfn "route = "
//        for j in perm do
//            printfn "from %A to %A = %A "  j.city1 j.city2 j.distance
//
//    let shortest = Seq.minBy (fun leg -> Seq.sumBy (fun  x ->  x.distance) leg ) mapped
//    printfn "Shortest distance = %A  %d" shortest (shortest |> Seq.sumBy (fun  x ->  x.distance))
//
//    citysList |> distinctCities |> printfn "%A" 

    let ignoring = System.Console.ReadLine()

    
    0 // return an integer exit code