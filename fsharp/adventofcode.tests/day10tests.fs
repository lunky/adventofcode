module day10tests

open adventofcode
open Day10

open NUnit.Framework
open FsUnit

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4


[<Test>]
let ``lookNSay 11233 gives you "21123"``() = 
        let words = lookNSay "11233"
        words |> should equal "211223"

[<Test>]
let ``1 becomes 11 (1 copy of digit 1).``() = 
        let words = lookNSay "1"
        words |> should equal "11"

[<Test>]
let ``11 becomes 21 (2 copies of digit 1).``() = 
        let words = lookNSay "11"
        words |> should equal "21"

[<Test>]
let ``21 becomes 1211 (one 2 followed by one 1).``() = 
        let words = lookNSay "21"
        words |> should equal "1211"

[<Test>]
let ``1211 becomes 111221 (one 1, one 2, and two 1s).``() = 
        let words = lookNSay "1211"
        words |> should equal "111221"

[<Test>]
let ``111221 becomes 312211 (three 1s, two 2s, and one 1).``() = 
        let words = lookNSay "1112211"
        words |> should equal "312221"
