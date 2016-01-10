module day10tests

open adventofcode
open Day10

open NUnit.Framework
open FsUnit

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4


[<Test>]
let ``1 gives you [1]``() = 
    2 + 2 |> should equal 4
