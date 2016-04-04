namespace adventofcode
open System

module Day15 =
    type Ingredient = {name: string; capacity: int; durability: int; flavor: int; texture: int; calories: int}

    let negativeEqualsZero value = 
        let ret = value
        if value<0 then
            0
        else
            ret
    let scoreIngredients ingredients = 
        let capacity = (ingredients |>Seq.sumBy (fun (count,i)->count * i.capacity) ) |> negativeEqualsZero
        let durability = (ingredients |>Seq.sumBy (fun (count,i)->count * i.durability) ) |> negativeEqualsZero
        let flavor = (ingredients |>Seq.sumBy (fun (count,i)->count * i.flavor) ) |> negativeEqualsZero
        let texture = (ingredients |>Seq.sumBy (fun (count,i)->count * i.texture) ) |> negativeEqualsZero
        let calories = (ingredients |>Seq.sumBy (fun (count,i)->count * i.calories) ) 
        (capacity * durability * flavor * texture, calories)

    let rec incSeries (max: int) targetTotal (input: int list) =
        let tail = List.tail input 
        let newhead =  (List.head input) + 1
        if (newhead = max) then
            let newhead = 0
            newhead::incSeries max targetTotal tail   
        else
            newhead::tail

    let getSet max targetTotal places = 
        let zeros = [ for i in 1..places -> 0 ]
        let limit = [for i in 1..places -> targetTotal-1]
        let rec getNext (input: int list)= 
            seq{
                if not(  input = limit ) then
                    let next = incSeries max targetTotal input 
                    yield next
                    yield! (getNext next)
            }
        getNext zeros |> Seq.where(fun l -> Seq.sum l = targetTotal)

    //       Sprinkles: capacity 2, durability 0, flavor -2, texture 0, calories 3
    let parseRawIngredients (ingredients)= 
        ingredients
        |>Seq.map (fun (rawLine:string) -> 
            let name = (rawLine.Split ':').[0].Trim()
            let rest  = (rawLine.Split ':').[1].Split( ',' ) |> Seq.map (fun i->i.Trim())
            let chunks = rest |> Seq.map (fun (el:string)-> Int32.Parse (el.Split ' ').[1])|> Seq.toArray
            {name=name; capacity=chunks.[0]; durability=chunks.[1]; flavor=chunks.[2]; texture=chunks.[3]; calories=chunks.[4]}
        )

    let findOptimal (ingredients: Ingredient list)  = 
        let count = ingredients.Length
        getSet 100 100 ingredients.Length
        |> Seq.map (fun l -> 
                let option = [ for i in 0..ingredients.Length - 1-> (l.[i],ingredients.[i]) ]
                let totes,calories = scoreIngredients option 
                printfn "totes %A %A" l totes
                (l,totes,calories)
                )
        |> Seq.filter(fun (set,total, calories) -> calories=500 && total>0)
        |> Seq.maxBy (fun (set,total, calories) -> total)
        |> (fun (set,total, calories) ->  // got it, just rerun to get the answer (could avoid this by adding to the input)
                let option = [ for i in 0..ingredients.Length - 1-> (set.[i],ingredients.[i]) ]
                printfn "%A" set
                scoreIngredients option )
