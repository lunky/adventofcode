module day14tests
open adventofcode
open Day14

open NUnit.Framework
open FsUnit

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4

[<Test>]
let ``readReindeerRules parses message`` () = 
    let msg = "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds."
    readReindeerRules msg |> should equal {name="Comet"; speed=14; duration=10; rest=127}

[<Test>]
let ``readReindeerRules parses second message`` () = 
    let msg = "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds."
    readReindeerRules msg |> should equal {name="Dancer"; speed=16; duration=11; rest=162}

[<Test>]
let ``calculate flying distance in given seconds`` () = 
    let comet = {name="Comet"; speed=14; duration=10; rest=127}
    calculateDistance comet 1000|>  should equal 1120

[<Test>]
let ``calculate flying distance in given seconds of second reindeer`` () = 
    let comet = {name="Dancer"; speed=16; duration=11; rest=162}
    calculateDistance comet 1000|> should equal 1056

[<Test>]
let ``calculate flying distance in given one second reindeer 1`` () = 
    let comet = readReindeerRules "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds."
    calculateDistance comet 1|> should equal 14

[<Test>]
let ``calculate flying distance in given one second reindeer 2`` () = 
    let comet = readReindeerRules "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds."
    calculateDistance comet 1|> should equal 16

[<Test>]
let ``After 10+127+9 seconds, Comet has gone 266 km`` () = 
    let comet = readReindeerRules "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds."
    calculateDistance comet 146|> should equal 266

[<Test>]
let ``After 10+127+10 seconds, Comet has gone 280 km`` () = 
    let comet = readReindeerRules "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds."
    calculateDistance comet 147|> should equal 280

[<Test>]
let ``After 1 seconds, Vixen has gone 8 km`` () = 
    let vixen = readReindeerRules "Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds."
    calculateDistance vixen 1|> should equal 8

[<Test>]
let ``After 11 seconds, Vixen has gone 64 km`` () = 
    let vixen = readReindeerRules "Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds."
    calculateDistance vixen 11|> should equal 64

[<Test>]
let ``After 61 seconds, Vixen has gone 64 km`` () = 
    let vixen = readReindeerRules "Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds."
    calculateDistance vixen 61|> should equal 64

[<Test>]
let ``After 62 seconds, Vixen has gone 72 km`` () = 
    let vixen = readReindeerRules "Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds."
    calculateDistance vixen 62|> should equal 72

[<Test>]
let ``After 0 seconds, Vixen has gone 0 km`` () = 
    let vixen = readReindeerRules "Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds."
    calculateDistance vixen 0|> should equal 0

