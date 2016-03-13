module day13tests
open adventofcode
open Day13

open NUnit.Framework
open FsUnit

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4

[<Test>]
let ``GetPermutations works with input of three``() =
    let lst = ['a'; 'b'; 'c']
    let res = permutations lst
    Seq.length res |> should equal 6

[<Test>]
let ``GetPermutations works with input of four``() =
    let lst = ['a'; 'b'; 'c'; 'd']
    let res = permutations lst
    Seq.length res |> should equal 24

let testRules = [
    "Alice would gain 54 happiness units by sitting next to Bob.";
    "Alice would lose 79 happiness units by sitting next to Carol.";
    "Alice would lose 2 happiness units by sitting next to David.";
    "Bob would gain 83 happiness units by sitting next to Alice.";
    "Bob would lose 7 happiness units by sitting next to Carol.";
    "Bob would lose 63 happiness units by sitting next to David.";
    "Carol would lose 62 happiness units by sitting next to Alice.";
    "Carol would gain 60 happiness units by sitting next to Bob.";
    "Carol would gain 55 happiness units by sitting next to David.";
    "David would gain 46 happiness units by sitting next to Alice.";
    "David would lose 7 happiness units by sitting next to Bob.";
    "David would gain 41 happiness units by sitting next to Carol.";]

let testRules2 = [
    "Alice would gain 54 happiness units by sitting next to Bob.";
    "Alice would lose 79 happiness units by sitting next to Carol.";
    "Alice would lose 2 happiness units by sitting next to David.";
    "Alice would gain 0 happiness units by sitting next to Me.";
    "Bob would gain 83 happiness units by sitting next to Alice.";
    "Bob would lose 7 happiness units by sitting next to Carol.";
    "Bob would lose 63 happiness units by sitting next to David.";
    "Bob would gain 0 happiness units by sitting next to Me.";
    "Carol would lose 62 happiness units by sitting next to Alice.";
    "Carol would gain 60 happiness units by sitting next to Bob.";
    "Carol would gain 55 happiness units by sitting next to David.";
    "Carol would gain 0 happiness units by sitting next to Me.";
    "David would gain 46 happiness units by sitting next to Alice.";
    "David would lose 7 happiness units by sitting next to Bob.";
    "David would gain 41 happiness units by sitting next to Carol.";
    "David would gain 0 happiness units by sitting next to Me.";
    "Me would gain 0 happiness units by sitting next to Alice.";
    "Me would gain 0 happiness units by sitting next to Bob.";
    "Me would gain 0 happiness units by sitting next to Carol.";
    "Me would gain 0 happiness units by sitting next to David.";
    ]

[<Test>]
let ``Alice Bob Carol = 49 ``() =
    let names = ["Alice"; "Bob"; "Carol"]
    let rules = Seq.map (fun el -> parseRules el) testRules
    let res = calculateHappiness names rules
    res |> should equal (54 - 79 + 83 - 7 + 60 - 62 )

[<Test>]
let ``calcSingle Alice Bob = 137 ``() =
    let rules = Seq.map (fun f -> parseRules f) testRules
    let res = calcSingle ("Alice","Bob") rules
    res |> should equal (54 + 83)

[<Test>]
let ``Alice Bob David = 111 ``()=
    let names = ["Alice"; "Bob"; "David"]
    let rules = Seq.map (fun el -> parseRules el) testRules
    let res = calculateHappiness names rules
    res |> should equal (54 - 2 + 83 - 63 - 7 + 46 )

[<Test>]
let ``Carol David Alice Bob = 330 ``()=
    let names = ["Carol"; "David"; "Alice"; "Bob"; ]
    let rules = Seq.map (fun el -> parseRules el) testRules
    let res = calculateHappiness names rules
    res |> should equal (41 + 46 - 2 + 54  + 83 - 7 + 60 + 55)

[<Test>]
let ``Bob Carol David Alice - lowest = 330 ``()=
    let names = ["Carol"; "David"; "Alice"; "Bob"; ]
    let res = calculateMostChange testRules
    res |> should equal 330

[<Test>]
let ``Bob Carol David Alice Different order - lowest = 330 ``()=
    let names = ["Alice"; "Carol"; "David"; "Bob"; ]
    let res = calculateMostChange testRules
    res |> should equal 330
