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

[<Test>]
let ``1 becomes 11 (1 copy of digit 1).``() = 
        let words = seeNSay "1"
        words |> should equal "11"

let ``11 becomes 21 (2 copies of digit 1).``() = 
        let words = seeNSay "11"
        words |> should equal "21"

let ``21 becomes 1211 (one 2 followed by one 1).``() = 
        let words = seeNSay "21"
        words |> should equal "1211"

let ``1211 becomes 111221 (one 1, one 2, and two 1s).``() = 
        let words = seeNSay "1211"
        words |> should equal "111221"

let ``111221 becomes 312211 (three 1s, two 2s, and one 1).``() = 
        let words = seeNSay "1112211"
        words |> should equal "312211"
