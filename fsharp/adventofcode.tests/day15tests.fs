module day15tests
open adventofcode
open Day15

open NUnit.Framework
open FsUnit

[<Test>]
let ``Test system runsz``() = 
    2 + 2 |> should equal 4

let Butterscotch = { name="Butterscotch"; capacity= -1; durability= -2; flavor= 6; texture= 3; calories= 8}
let Cinnamon = {name="Cinnamon"; capacity=2; durability=3; flavor= -2; texture= -1; calories=3}

[<Test>]
let ``Score Ingredients should work``() =
    let score,calories = scoreIngredients [(44,Butterscotch); (56,Cinnamon)]
    score |> should equal 62842880

[<Test>]
let ``test Ingredients which produce negative values should result in zeros``() =
    let testIngredients = [(50, {name = "Sprinkles";capacity = 2;durability = 0;flavor = -2;texture = 0;calories = 3;}); 
                            (0, {name = "Butterscotch";capacity = 0;durability = 5;flavor = -3;texture = 0;calories = 3;}); 
                            (0, {name = "Chocolate";capacity = 0;durability = 0;flavor = 5;texture = -1;calories = 8;});
                            (50, {name = "Candy";capacity = 0;durability = -1;flavor = 0;texture = 5;       calories = 8;})]

    let score,calories = scoreIngredients testIngredients
    score |> should equal 0

[<Test>]
let ``Score Ingredients and calories = 500 should work``() =
    let score,calories = scoreIngredients [(40,Butterscotch); (60,Cinnamon)]
    score |> should equal 57600000
    calories |> should equal 500

//[<Test>]
//let ``Score Ingredients should work``() =
//    let score = scoreIngredients [(44,Butterscotch); (56,Cinnamon)]
//    score |> should equal 62842880
//    ()



    