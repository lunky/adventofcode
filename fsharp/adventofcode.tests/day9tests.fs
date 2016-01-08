module day9tests

open adventofcode
open Day9

open NUnit.Framework
open FsUnit

let citysList  = [
        {city1= "London"; city2= "Dublin"; distance= 464};
        {city1= "London"; city2= "Belfast"; distance= 518};
        {city1= "Dublin"; city2= "Belfast"; distance= 141};
    ]

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4

[<Test>]
let ``distinctCities should pick out a unique list of cities ``() =
    distinctCities citysList |> Seq.sort |> should equal (Seq.toList ["Belfast"; "Dublin"; "London";])

[<Test>]
let ``shortestDistance should find the shortest overall distance ``() =
    shortestDistance citysList |> should equal 605

[<Test>]
let ``longestDistance should find the longest overall distance ``() =
    longestDistance citysList |> should equal 982

[<Test>]
let ``shortestRoute should find the correct # of cities``() =
    shortestRoute citysList |> Seq.length  |>  should equal  2

[<Test>]
let ``shortestRoute should find the correct cities in order ``() =
    shortestRoute citysList |> Seq.collect(fun city -> [city.city1; city.city2])  
        |>  should equal  ["London";"Dublin"; "Dublin"; "Belfast"]
    // ["London"; "Dublin"; "Belfast"]
