module day11tests

open adventofcode
open Day11

open NUnit.Framework
open FsUnit

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4


[<Test>]
let ``The next password after abcd is abce``() = 
    let currentPassword = "abcd"
    let expectedNextPassword = "abce"
    incSeries currentPassword |> should equal expectedNextPassword

[<Test>]
let ``Passes complexity rules``() = 
    let currentPassword = "eeaabcd"
    passesComplexityRules currentPassword |> should equal true

[<Test>]
let ``three letter but contains i run fails complexity rules``() = 
    let currentPassword = "hijklmmn"
    passesComplexityRules currentPassword |> should equal false

[<Test>]
let ``fewer than 2 pair fails complexity rules``() = 
    let currentPassword = "dcabhhjrst"
    passesComplexityRules currentPassword |> should equal false

[<Test>]
let ``The next password after abcz is abda``() = 
    let currentPassword = "abcz"
    let expectedNextPassword = "abda"
    incSeries currentPassword |> should equal expectedNextPassword

[<Test>]
let ``The next password after faz is fbz``() = 
    let currentPassword = "aaa"
    let expectedNextPassword = "aab"
    incSeries currentPassword |> should equal expectedNextPassword

[<Test>]
let ``The next password after abcdefgh is abcdffaa``() = 
    let currentPassword = "abcdefgh"
    let expectedNextPassword = "abcdffaa"
    getNextPassword currentPassword |> should equal expectedNextPassword

[<Test>]
let ``The next password after ghijklmn is ghjaabcc``() = 
    let currentPassword = "ghijklmn"
    let expectedNextPassword = "ghjaabcc"
    getNextPassword currentPassword |> should equal expectedNextPassword