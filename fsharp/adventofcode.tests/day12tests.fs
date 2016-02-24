module day12tests

open adventofcode
open Day12

open NUnit.Framework
open FsUnit

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4

[<Test>]
let ``Can call sumNumbersFromJson with json``() = 
    let testJson = "{\"e\":-14,\"a\":\"green\"}"
    sumNumbersFromJson testJson |> should equal -14

[<Test>]
let ``sumNumbersFromJson adds all postive numbers``() = 
    let testJson = "{\"e\":14,\"a\":\"green\", \"q\":30}"
    sumNumbersFromJson testJson |> should equal 44

[<Test>]
let ``sumNumbersFromJson adds all the numbers``() = 
    let testJson = "{\"e\":-14,\"a\":\"green\", \"q\":30}"
    sumNumbersFromJson testJson |> should equal 16

[<Test>]
let ``sumNoRedNumbersFromJson adds all the numbers ignore objects with property  'red' ``() = 
    let testJson = "[{\"e\":-14},{\"a\":\"red\", \"q\":30}]"
    sumNoRedNumbersFromJson testJson |> should equal -14
