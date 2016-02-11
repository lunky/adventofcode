module day12tests

open adventofcode
open Day12

open NUnit.Framework
open FsUnit

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4

[<Test>]
let ``Can call getNumbersFromJson with json``() = 
    let testJson = "{\"e\":-14,\"a\":\"red\"}"
    getNumbersFromJson testJson |> should equal -14
