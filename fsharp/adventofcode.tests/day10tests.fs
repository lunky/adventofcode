module day10tests

open adventofcode
open Day10

open NUnit.Framework
open FsUnit

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4


[<Test>]
let ``breakIntoGroups 1 gives you [[1]]``() = 
        let words = groupCharacters "1"
        words |> should equal [['1']]
let ``breakIntoGroups 1 gives you [[1]] 2``() = 
        let words = groupCharacters "1"
        words |> should equal [['1']]
[<Test>]
let ``breakIntoGroups 12 gives you [[1]; [2]]``() = 
        let words = groupCharacters "12"
        words |> should equal [['1'];['2']]
[<Test>]
let ``breakIntoGroups 112 gives you [[1;1]; [2]]``() = 
        let words = groupCharacters "112"
        words |> should equal [['1'; '1'];['2']]
[<Test>]
let ``breakIntoGroups 11233 gives you [[1;1]; [2]; ['3';'3';]]``() = 
        let words = groupCharacters "11233"
        words |> should equal [['1'; '1']; ['2']; ['3';'3']]
[<Test>]
let ``seeNSay 11233 gives you "21123"``() = 
        let words = seeNSay "11233"
        words |> should equal "211223"
