module Day13

open System.Text.RegularExpressions

let permutations input = 
    /// Rotates a list by one place forward.
    let rotate lst =
        List.tail lst @ [List.head lst]

    /// Gets all rotations of a list.
    let getRotations lst =
        let rec getAll lst i = if i = 0 then [] else lst :: (getAll (rotate lst) (i - 1))
        getAll lst (List.length lst)

    /// Gets all permutations (without repetition) of specified length from a list.
    let rec getPerms n lst = 
        match n, lst with
        | 0, _ -> seq [[]]
        | _, [] -> seq []
        | k, _ -> lst |> getRotations |> Seq.collect (fun r -> Seq.map ((@) [List.head r]) (getPerms (k - 1) (List.tail r)))
    getPerms (List.length input) input

let circularPairs lst = 
    match lst with 
    | [] -> List.toSeq []
    | _ -> seq{ yield! (Seq.pairwise lst) ; yield! [(Seq.last lst , Seq.head lst)] }


// input e.g.     "Alice would gain 54 happiness units by sitting next to Bob.";
let parseRules input = 
    let groupValue (m: Group) =
        m.Value
    let firstMatch = Regex.Matches(input, "(\w+) would (gain|lose) (\d+) happiness units by sitting next to (\w+)\.") |> Seq.cast |> Seq.head
    let rules = Seq.cast (firstMatch : Match).Groups |> Seq.map groupValue |> Seq.tail  |> Seq.toList
    match rules with
    | [subject; "gain" ; units; observed] -> (subject, System.Int32.Parse units, observed)
    | [subject; "lose" ; units; observed] -> (subject,  -1 * System.Int32.Parse units, observed)
    | _ -> raise (System.ArgumentException "Bad syntax")

let calcSingle pair rules : int=
    let subject,observed = pair
    Seq.fold (fun acc rule -> 
        let  first, amt, second = rule
        match pair with
        | (l,r) when l=first && r=second -> acc + amt 
        | (l,r) when l=second && r=first  ->  acc + amt 
        | _ -> acc 
    ) 0 rules 

let calculateHappiness names rules = 
    let pairs = circularPairs names
    let res = Seq.fold (fun acc pair -> acc + (calcSingle pair rules)) 0  pairs
    res

let calculateMostChangeAddMe rulesRaw =
    let rules = Seq.map (fun el -> parseRules el) rulesRaw
    let names = Seq.map (fun el -> 
                let name, x, y = el
                name
                ) rules |> Seq.distinct |> Seq.toList |> List.append ["Me"]
    let most = Seq.maxBy (fun pairs -> 
                let res = calculateHappiness pairs rules
                res
                ) (permutations names)
    calculateHappiness most rules

let calculateMostChange rulesRaw =
    let rules = Seq.map (fun el -> parseRules el) rulesRaw
    let names = Seq.map (fun el -> 
                let name, x, y = el
                name
                ) rules |> Seq.distinct |> Seq.toList
    let most = Seq.maxBy (fun pairs -> 
                let res = calculateHappiness pairs rules
                abs res
                ) (permutations names)
    calculateHappiness most rules
    
